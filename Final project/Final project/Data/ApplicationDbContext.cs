using System;
using System.Collections.Generic;
using System.Text;
using Final_project.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<EstimatedTask> EstimatedTasks { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Models.Type> Types { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


    }
}
