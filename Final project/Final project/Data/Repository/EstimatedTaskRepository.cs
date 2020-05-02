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
    }
}
