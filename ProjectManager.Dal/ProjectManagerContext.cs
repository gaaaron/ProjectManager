using Microsoft.EntityFrameworkCore;

using ProjectManager.Model.Entities;
using System;
using System.IO;

namespace ProjectManager.Dal
{
    class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<PTask> ProjectTasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkTimeLog> WorkTimeLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "projectmanager.db");

            options.UseSqlite($"Data Source={dbPath}",
               builder => builder.MigrationsAssembly(typeof(ProjectManagerContext).Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().HasKey(x => new { x.UserId, x.ProjectId});
            modelBuilder.Entity<ProjectUser>().HasOne(x => x.Project)
                                              .WithMany(x => x.ProjectUsers)
                                              .HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectUser>().HasOne(x => x.User)
                                              .WithMany(x => x.ProjectUsers)
                                              .HasForeignKey(x => x.UserId);


            modelBuilder.Entity<PTaskUser>().HasKey(x => new { x.UserId, x.TaskId });
            modelBuilder.Entity<PTaskUser>().HasOne(x => x.Task)
                                  .WithMany(x => x.TaskUsers)
                                  .HasForeignKey(x => x.TaskId);
            modelBuilder.Entity<PTaskUser>().HasOne(x => x.User)
                                              .WithMany(x => x.TasksUsers)
                                              .HasForeignKey(x => x.UserId);
        }
    }
}
