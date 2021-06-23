using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoSun.ApplicationCore.Entities;

namespace YaoSun.Infrastructure.Data
{
    public class TaskManagementSystemDbContext : DbContext
    {
        public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Tasks>(ConfigureTask);
            modelBuilder.Entity<Tasks_History>(ConfigureTasksHistory);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Taskss { get; set; }
        public DbSet<Tasks_History> TasksHistory { get; set; }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.Mobileno).HasMaxLength(50);
        }
        private void ConfigureTask(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.userid);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Priority).IsFixedLength(true);
            builder.Property(t => t.Remarks).HasMaxLength(500);
            builder.HasOne(t => t.User).WithMany(u => u.Tasks).HasForeignKey(t => t.userid);
        }
        private void ConfigureTasksHistory(EntityTypeBuilder<Tasks_History> builder)
        {
            builder.ToTable("Tasks_History");
            builder.HasKey(th => th.TaskId);
            builder.Property(th => th.UserId);
            builder.Property(th => th.Title).HasMaxLength(50);
            builder.Property(th => th.Description).HasMaxLength(500);
            builder.Property(th => th.Remarks).HasMaxLength(500);
            builder.HasOne(th => th.User).WithMany(u => u.Tasks_Histories).HasForeignKey(th => th.UserId);
        }

    }
}
