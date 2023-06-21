using EventManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventUserModel> EventUsers { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<UserNotificationModel> UserNotifications { get; set; }
        public DbSet<EventAddressModel> EventAddresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserNotificationModel>().HasKey(x => new { x.UserId, x.NotificationId });
            modelBuilder.Entity<EventUserModel>().HasKey(x => new { x.ObserverId, x.EventId });
        }
    }
}