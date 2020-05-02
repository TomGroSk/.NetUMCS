using Final_project.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
            Models.Type type = new Models.Type
            {
                Name = name
            };
            context.Types.Add(type);
            context.SaveChanges();
        }

        public void Update(Models.Type type)
        {
            context.Types.Update(type);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Types.Remove(context.Types.Where(t => t.Id == Id).FirstOrDefault());
            context.SaveChanges();
        }

        public Type GetType(int Id)
        {
            return context.Types.Where(t => t.Id == Id).FirstOrDefault();
        }

        internal List<Models.Type> GetAll()
        {
            return context.Types.ToList();
        }
    }
}
