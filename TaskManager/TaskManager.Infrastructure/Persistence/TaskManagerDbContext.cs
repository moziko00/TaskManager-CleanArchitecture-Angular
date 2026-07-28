using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence
{
    public class TaskManagerDbContext :DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options): base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
