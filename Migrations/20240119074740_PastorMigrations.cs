using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PASTORALISPROJECTNEW.Migrations
{
    /// <inheritdoc />
    public partial class PastorMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookingstatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingstatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counselees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SurveyAttempted = table.Column<bool>(type: "boolean", nullable: true),
                    SubscriptionType = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counsellingtypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounsellingType1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counsellingtypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emailotps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailId = table.Column<string>(type: "text", nullable: true),
                    Otpgeneratedtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emailotps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entitytypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entitytypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PastorDescription = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanType = table.Column<string>(type: "text", nullable: true),
                    Plandate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlanName = table.Column<string>(type: "text", nullable: true),
                    PlanCode = table.Column<string>(type: "text", nullable: true),
                    PlanPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    PlanPeriod = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessionstatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessionstatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionPlan = table.Column<string>(type: "text", nullable: true),
                    SubscriptionPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Options = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CounselingType = table.Column<int>(type: "integer", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    CounselingTypeNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Counsellingtypes_CounselingTypeNavigationId",
                        column: x => x.CounselingTypeNavigationId,
                        principalTable: "Counsellingtypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    LoginAttempt = table.Column<int>(type: "integer", nullable: true),
                    TermsAndConditionsAccepted = table.Column<bool>(type: "boolean", nullable: true),
                    EntityTypeNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Entitytypes_EntityTypeNavigationId",
                        column: x => x.EntityTypeNavigationId,
                        principalTable: "Entitytypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favouritepastors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounseleeId = table.Column<int>(type: "integer", nullable: true),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favouritepastors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favouritepastors_Counselees_CounseleeId",
                        column: x => x.CounseleeId,
                        principalTable: "Counselees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favouritepastors_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    Rating1 = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    SlotDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: true),
                    AvailabilityTime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Surveyresponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounseleeId = table.Column<int>(type: "integer", nullable: true),
                    QuestionId = table.Column<int>(type: "integer", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true),
                    CounselingType = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CounselingTypeNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyresponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveyresponses_Counselees_CounseleeId",
                        column: x => x.CounseleeId,
                        principalTable: "Counselees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveyresponses_Counsellingtypes_CounselingTypeNavigationId",
                        column: x => x.CounselingTypeNavigationId,
                        principalTable: "Counsellingtypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveyresponses_Surveys_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blockreporthistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CounseleeId = table.Column<int>(type: "integer", nullable: true),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: true),
                    IsReported = table.Column<bool>(type: "boolean", nullable: true),
                    BlockReason = table.Column<string>(type: "text", nullable: true),
                    ReportReason = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockreporthistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blockreporthistories_Counselees_CounseleeId",
                        column: x => x.CounseleeId,
                        principalTable: "Counselees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blockreporthistories_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blockreporthistories_Users_CreatedByNavigationId",
                        column: x => x.CreatedByNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewedBy = table.Column<int>(type: "integer", nullable: true),
                    ReviewComment = table.Column<string>(type: "text", nullable: true),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReviewedByNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewedByNavigationId",
                        column: x => x.ReviewedByNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Userentityaccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EntityTypeNavigationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userentityaccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Userentityaccesses_Entitytypes_EntityTypeNavigationId",
                        column: x => x.EntityTypeNavigationId,
                        principalTable: "Entitytypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Userentityaccesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Userimages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userimages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Userimages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookingevents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounseleeId = table.Column<int>(type: "integer", nullable: true),
                    SurveyAttempted = table.Column<bool>(type: "boolean", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PastorId = table.Column<int>(type: "integer", nullable: true),
                    BookingStatusId = table.Column<int>(type: "integer", nullable: true),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: true),
                    IsPaymentSuccessful = table.Column<bool>(type: "boolean", nullable: true),
                    IsBooked = table.Column<bool>(type: "boolean", nullable: true),
                    SlotId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingevents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookingevents_Bookingstatuses_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "Bookingstatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookingevents_Counselees_CounseleeId",
                        column: x => x.CounseleeId,
                        principalTable: "Counselees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookingevents_Pastors_PastorId",
                        column: x => x.PastorId,
                        principalTable: "Pastors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookingevents_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookingevents_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: true),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Bookingevents_EventId",
                        column: x => x.EventId,
                        principalTable: "Bookingevents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paymentdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    CounseleeId = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paymentdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paymentdetails_Bookingevents_EventId",
                        column: x => x.EventId,
                        principalTable: "Bookingevents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paymentdetails_Counselees_CounseleeId",
                        column: x => x.CounseleeId,
                        principalTable: "Counselees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlanId = table.Column<int>(type: "integer", nullable: true),
                    IsPaymentSuccessful = table.Column<bool>(type: "boolean", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Bookingevents_EventId",
                        column: x => x.EventId,
                        principalTable: "Bookingevents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Sessionstatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Sessionstatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EventId",
                table: "AuditLogs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blockreporthistories_CounseleeId",
                table: "Blockreporthistories",
                column: "CounseleeId");

            migrationBuilder.CreateIndex(
                name: "IX_Blockreporthistories_CreatedByNavigationId",
                table: "Blockreporthistories",
                column: "CreatedByNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Blockreporthistories_PastorId",
                table: "Blockreporthistories",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingevents_BookingStatusId",
                table: "Bookingevents",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingevents_CounseleeId",
                table: "Bookingevents",
                column: "CounseleeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingevents_PastorId",
                table: "Bookingevents",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingevents_SlotId",
                table: "Bookingevents",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingevents_SubscriptionId",
                table: "Bookingevents",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Favouritepastors_CounseleeId",
                table: "Favouritepastors",
                column: "CounseleeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favouritepastors_PastorId",
                table: "Favouritepastors",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Paymentdetails_CounseleeId",
                table: "Paymentdetails",
                column: "CounseleeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paymentdetails_EventId",
                table: "Paymentdetails",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PastorId",
                table: "Ratings",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PastorId",
                table: "Reviews",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedByNavigationId",
                table: "Reviews",
                column: "ReviewedByNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EventId",
                table: "Sessions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PlanId",
                table: "Sessions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_StatusId",
                table: "Sessions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_PastorId",
                table: "Slots",
                column: "PastorId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveyresponses_CounseleeId",
                table: "Surveyresponses",
                column: "CounseleeId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveyresponses_CounselingTypeNavigationId",
                table: "Surveyresponses",
                column: "CounselingTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveyresponses_QuestionId",
                table: "Surveyresponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CounselingTypeNavigationId",
                table: "Surveys",
                column: "CounselingTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Userentityaccesses_EntityTypeNavigationId",
                table: "Userentityaccesses",
                column: "EntityTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Userentityaccesses_UserId",
                table: "Userentityaccesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Userimages_UserId",
                table: "Userimages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EntityTypeNavigationId",
                table: "Users",
                column: "EntityTypeNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Blockreporthistories");

            migrationBuilder.DropTable(
                name: "Emailotps");

            migrationBuilder.DropTable(
                name: "Favouritepastors");

            migrationBuilder.DropTable(
                name: "Paymentdetails");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Surveyresponses");

            migrationBuilder.DropTable(
                name: "Userentityaccesses");

            migrationBuilder.DropTable(
                name: "Userimages");

            migrationBuilder.DropTable(
                name: "Bookingevents");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Sessionstatuses");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bookingstatuses");

            migrationBuilder.DropTable(
                name: "Counselees");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Counsellingtypes");

            migrationBuilder.DropTable(
                name: "Entitytypes");

            migrationBuilder.DropTable(
                name: "Pastors");
        }
    }
}
