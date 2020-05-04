using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Final_project.Data.Models;
using Final_project.Data.Repository;
using Final_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_project.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly EvaluationRepository evaluationRepository;
        private readonly EstimatedTaskRepository estimatedTaskRepository;
        private readonly TaskRepository taskRepository;
        private readonly TechnologyRepository technologyRepository;
        private readonly TypeRepository typeRepository;
        private readonly UserManager<User> userManager;

        public EvaluationController(EvaluationRepository evaluationRepository,
            EstimatedTaskRepository estimatedTaskRepository,
            TaskRepository taskRepository,
            TechnologyRepository technologyRepository,
            TypeRepository typeRepository,
            UserManager<User> userManager)
        {
            this.evaluationRepository = evaluationRepository;
            this.estimatedTaskRepository = estimatedTaskRepository;
            this.taskRepository = taskRepository;
            this.technologyRepository = technologyRepository;
            this.typeRepository = typeRepository;
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

        public IActionResult Details(int Id)
        {
            Evaluation evaluation = evaluationRepository.GetEvaluation(Id);
            EvaluationModel evaluationModel = new EvaluationModel()
            {
                ProjectName = evaluation.ProjectName,
                UserName = evaluation.User.UserName,
                Date = evaluation.Date,
                Risk = evaluation.Risk,
                Id = evaluation.Id,
                EstimatedTasks = evaluation.EstimatedTask
            };
            return View(evaluationModel);
        }

        public IActionResult CreateEstimatedTask(int Id)
        {
            EstimatedTaskModel estimatedTaskModel = new EstimatedTaskModel()
            {
                Technologies = technologyRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList(),
                Types = typeRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList(),
                Tasks = taskRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList()
            };
            
            return View(estimatedTaskModel);
        }

        [HttpPost]
        public IActionResult CreateEstimatedTask(EstimatedTaskModel estimatedTaskModel)
        {
            if (!HttpContext.Request.Path.HasValue)
            {
                return RedirectToAction("Index");
            }
            if(!int.TryParse(HttpContext.Request.Path.Value.Split('/')[^1], out int evaluationId))
            {
                return RedirectToAction("Index");
            }
            EstimatedTask estimatedTask = new EstimatedTask()
            {
                Task = taskRepository.GetTask(int.Parse(estimatedTaskModel.Task)),
                Type = typeRepository.GetType(int.Parse(estimatedTaskModel.Type)),
                Technology = technologyRepository.GetTechnology(int.Parse(estimatedTaskModel.Technology)),
                BurntHours = estimatedTaskModel.BurntHours,
                EstimatedHours = estimatedTaskModel.EstimatedHours,
                IsCompleted = estimatedTaskModel.IsCompleted,
                Evaluation = evaluationRepository.GetEvaluation(evaluationId)
            };

            estimatedTaskRepository.Add(estimatedTask);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEstimatedTask(int Id)
        {
            estimatedTaskRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult EditEstimatedTask(int Id)
        {
            EstimatedTask estimatedTask = estimatedTaskRepository.GetEstimatedTask(Id);
            EstimatedTaskModel estimatedTaskModel = new EstimatedTaskModel()
            {
                Id = estimatedTask.Id,
                Technologies = technologyRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList(),
                Types = typeRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList(),
                Tasks = taskRepository.GetAll().Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList(),
                Task = estimatedTask.Task.Id.ToString(),
                Technology = estimatedTask.Technology.Id.ToString(),
                Type = estimatedTask.Type.Id.ToString(),
                BurntHours = estimatedTask.BurntHours,
                EstimatedHours = estimatedTask.EstimatedHours,
                IsCompleted = estimatedTask.IsCompleted
            };
            
            return View(estimatedTaskModel);
        }

        [HttpPost]
        public IActionResult EditEstimatedTask(EstimatedTaskModel estimatedTaskModel)
        {
            EstimatedTask estimatedTask = new EstimatedTask()
            {
                Id = estimatedTaskModel.Id,
                Task = taskRepository.GetTask(int.Parse(estimatedTaskModel.Task)),
                Type = typeRepository.GetType(int.Parse(estimatedTaskModel.Type)),
                Technology = technologyRepository.GetTechnology(int.Parse(estimatedTaskModel.Technology)),
                BurntHours = estimatedTaskModel.BurntHours,
                EstimatedHours = estimatedTaskModel.EstimatedHours,
                IsCompleted = estimatedTaskModel.IsCompleted

            };
            estimatedTaskRepository.Update(estimatedTask);
            return RedirectToAction("Index");
        }

        public String GetXML(int Id)
        {
            Evaluation evaluation = evaluationRepository.GetEvaluation(Id);
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(evaluation.GetType());
                serializer.Serialize(stringwriter, evaluation);
                return stringwriter.ToString();
            }
        }

        public String GetDOC(int Id)
        {
            Evaluation evaluation = evaluationRepository.GetEvaluation(Id);
            return evaluation.ToString();
        }

        public String GetPDF(int Id)
        {
            Evaluation evaluation = evaluationRepository.GetEvaluation(Id);
            return evaluation.ToString();
        }

        public String GetCSV(int Id)
        {
            Evaluation evaluation = evaluationRepository.GetEvaluation(Id);
            return evaluation.ToString();
        }

    }
}