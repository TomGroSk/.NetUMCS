using Final_project.Data.Models;
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
            return context.EstimatedTasks.Where(e => e.Id == Id).FirstOrDefault();
        }

        public void Add(EstimatedTask estimatedTask)
        {
            context.Add(estimatedTask);
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            context.EstimatedTasks.Remove(GetEstimatedTask(Id));
            context.SaveChanges();
        }
    }
}
