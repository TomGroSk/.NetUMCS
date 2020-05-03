using Final_project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Repository
{
    public class EvaluationRepository
    {
        private readonly ApplicationDbContext context;

        public EvaluationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Evaluation GetEvaluation(int Id)
        {
            return context.Evaluations.Where(t => t.Id == Id)
                .Include(e => e.User)
                .Include(e => e.EstimatedTask).ThenInclude(e => e.Task)
                .Include(e => e.EstimatedTask).ThenInclude(e => e.Technology)
                .Include(e => e.EstimatedTask).ThenInclude(e => e.Type)
                .FirstOrDefault();
        }

        public List<Evaluation> GetAllEvaluations()
        {
            return context.Evaluations.Include(e => e.User).ToList();
        }

        public void Add(Evaluation Evaluation)
        {
            context.Add(Evaluation);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Remove(GetEvaluation(Id));
            context.SaveChanges();
        }
    }
}
