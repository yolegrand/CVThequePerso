using CVTheque.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CVTheque.data.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options){ }

        public DbSet<Level> Levels { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
               new Level
               {
                   Id = 1,
                   Name = "bon",
                   IsDelete = true
               }
           );
            modelBuilder.Entity<LanguageLevel>().HasData(
               new LanguageLevel
               {
                   Id = 1,
                   Name = "bon",
                   IsDelete = true
               }
           );
            //modelBuilder.Entity<UserRole>(eb =>
            // {
            //     eb.HasKey(t => new { t.RoleId, t.UserId });
            //     eb.Property(v => v.UserId).HasColumnName("UserId");
            //     eb.Property(v => v.RoleId).HasColumnName("RoleId");
            // });
            modelBuilder.Entity<UserRole>()
            .HasKey(t => new { t.RoleId, t.UserId });
            modelBuilder.Entity<UserRole>().HasOne(ur => ur.user).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>().HasOne(r => r.role).WithMany(u => u.UserRoles).HasForeignKey(r => r.RoleId);
            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "Admin",
                   IsDelete = true
               },
               new Role
               {
                   Id = 2,
                   Name = "Developer",
                   IsDelete = true
               },
               new Role
               {
                   Id = 3,
                   Name = "Recruiter",
                   IsDelete = true
               },
               new Role
               {
                   Id = 4,
                   Name = "Visitor",
                   IsDelete = true
               }
           );
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = 1,
                    Firstname = "David",
                    Lastname = "Desmette",
                    Password = Encoding.UTF8.GetBytes("Educassist123,"),
                    IsDelete = false,
                    Mail = "ddesmette@alterinfo.be",
                    PasswordSalt = new HMACSHA512().Key,
                    Username = "David"
                });
            modelBuilder.Entity<UserRole>().HasData(
               new UserRole
               {
                   RoleId = 1,
                   UserId = 1,
               }
            );
        }
    }
}
