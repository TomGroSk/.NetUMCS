﻿using Final_project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Repository
{
    public class EstimatedTaskRepository
    {
        private readonly ApplicationDbContext context;

        public EstimatedTaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public EstimatedTask GetEstimatedTask(int Id)
        {
            return context.EstimatedTasks.Include(t => t.Evaluation).Where(e => e.Id == Id).FirstOrDefault();
        }

        public void Add(EstimatedTask estimatedTask)
        {
            context.EstimatedTasks.Add(estimatedTask);
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            context.EstimatedTasks.Remove(GetEstimatedTask(Id));
            context.SaveChanges();
        }

        internal void Update(EstimatedTask estimatedTask)
        {
            context.EstimatedTasks.Update(estimatedTask);
            context.SaveChanges();
        }
    }
}
