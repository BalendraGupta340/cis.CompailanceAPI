﻿using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeePortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
                
        }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
