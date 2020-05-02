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
    }
}
