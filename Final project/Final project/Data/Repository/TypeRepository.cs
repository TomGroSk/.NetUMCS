using Final_project.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Repository
{
    public class TypeRepository
    {
        private readonly ApplicationDbContext context;

        public TypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(string name)
        {
            Type type = new Type
            {
                Name = name
            };
            context.Types.Add(type);
            context.SaveChanges();
        }

        public void Update(Type type)
        {

        }
    }
}
