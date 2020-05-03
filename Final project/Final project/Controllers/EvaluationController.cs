using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Data.Models;
using Final_project.Data.Repository;
using Final_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly EvaluationRepository evaluationRepository;
        private readonly UserManager<User> userManager;

        public EvaluationController(EvaluationRepository evaluationRepository, UserManager<User> userManager)
        {
            this.evaluationRepository = evaluationRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Evaluation> evaluations = evaluationRepository.GetAllEvaluations();
            List<EvaluationModel> evaluationModels = new List<EvaluationModel>();
            foreach(var e in evaluations)
            {
                evaluationModels.Add(new EvaluationModel()
                {
                    ProjectName = e.ProjectName,
                    UserName = e.User.UserName,
                    Date = e.Date,
                    Risk = e.Risk,
                    Id = e.Id
                });
            }
            return View(evaluationModels);
        }

        public IActionResult CreateEvaluation()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluationAsync(EvaluationModel EvaluationModel)
        {
            var user = await userManager.GetUserAsync(User);
            Evaluation evaluation = new Evaluation()
            {
                ProjectName = EvaluationModel.ProjectName,
                User = user,
                Date = EvaluationModel.Date,
                Risk = EvaluationModel.Risk
            };
            evaluationRepository.Add(evaluation);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {

            evaluationRepository.Delete(Id);
            return RedirectToAction("Index");
        }
        
    }
}