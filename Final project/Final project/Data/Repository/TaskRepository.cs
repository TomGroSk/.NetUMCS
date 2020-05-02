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
        public void Update(Task task)
        {
            context.Tasks.Update(task);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Tasks.Remove(context.Tasks.Where(t => t.Id == Id).FirstOrDefault());
            context.SaveChanges();
        }

        public Task GetTask(int Id)
        {
            return context.Tasks.Where(t => t.Id == Id).FirstOrDefault();
        }

        internal List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }
    }
}
