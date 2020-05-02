using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Final_project.Data.Repository
{
    public class TaskRepository
    {
        private readonly ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(string name)
        {
            Task task = new Task
            {
                Name = name
            };
            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}
