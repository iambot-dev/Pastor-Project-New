using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PASTORALISPROJECTNEW.EmailService;
using PASTORALISPROJECTNEW.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace PASTORALISPROJECTNEW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                var JwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "JWT Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",

                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(JwtSecurityScheme.Reference.Id, JwtSecurityScheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     { JwtSecurityScheme, Array.Empty<String>() }
                });
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPastorRepository, PastorRepository>();
            builder.Services.AddScoped<ICounseleeRepository, CounseleeRepository>();
            builder.Services.AddScoped<IServiceMailer, ServiceMailer>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<DBContext.PastoralisDBContext>(options =>
               options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            // Add JWT Authentication
            var key = Encoding.ASCII.GetBytes("pastoralisProjectKeypastoralisProjectKeypastoralisProjectKeypastoralisProjectKeypastoralisProjectKeypastoralisProjectKey"); // replace with your key
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            var app = builder.Build();

            app.UseAuthentication(); // Uncomment this line
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
