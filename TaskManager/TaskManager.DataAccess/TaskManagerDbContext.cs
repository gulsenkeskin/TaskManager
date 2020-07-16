using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= DESKTOP-6TIKNFS; Database=TaskManagerDb;uid=gulsen;pwd=1g6efljs;");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
