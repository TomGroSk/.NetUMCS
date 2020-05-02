using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Repository
{
    public class TechnologyRepository
    {
        private readonly ApplicationDbContext context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(string name)
        {
            Technology technology = new Technology
            {
                Name = name
            };
            context.Technologies.Add(technology);
            context.SaveChanges();
        }

        public void Update(Technology technology)
        {
            context.Technologies.Update(technology);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Technologies.Remove(context.Technologies.Where(t => t.Id == Id).FirstOrDefault());
            context.SaveChanges();
        }

        public Technology GetTechnology(int Id)
        {
            return context.Technologies.Where(t => t.Id == Id).FirstOrDefault();
        }

        internal List<Technology> GetAll()
        {
            return context.Technologies.ToList();
        }
    }
}
