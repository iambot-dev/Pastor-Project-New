using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PASTORALISPROJECTNEW.Models;


namespace PASTORALISPROJECTNEW.DBContext;

public partial class PastoralisDBContext : DbContext
{
    public PastoralisDBContext()
    {
    }

    public PastoralisDBContext(DbContextOptions<PastoralisDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Blockreporthistory> Blockreporthistories { get; set; }

    public virtual DbSet<Bookingevent> Bookingevents { get; set; }

    public virtual DbSet<Bookingstatus> Bookingstatuses { get; set; }

    public virtual DbSet<Counselee> Counselees { get; set; }

    public virtual DbSet<Counsellingtype> Counsellingtypes { get; set; }

    public virtual DbSet<Emailotp> Emailotps { get; set; }

    public virtual DbSet<Entitytype> Entitytypes { get; set; }

    public virtual DbSet<Favouritepastor> Favouritepastors { get; set; }

    public virtual DbSet<Pastor> Pastors { get; set; }

    public virtual DbSet<Paymentdetail> Paymentdetails { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Sessionstatus> Sessionstatuses { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<Surveyresponse> Surveyresponses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userentityaccess> Userentityaccesses { get; set; }

    public virtual DbSet<Userimage> Userimages { get; set; }

}