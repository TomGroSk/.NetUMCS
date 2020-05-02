using System.Linq;
using Final_project.Data.Models;
using Final_project.Data.Repository;
using Final_project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Authorize]
    public class LexiconController : Controller
    {
        private readonly TaskRepository taskRepository;
        private readonly TechnologyRepository technologyRepository;
        private readonly TypeRepository typeRepository;

        public LexiconController(TaskRepository taskRepository, TechnologyRepository technologyRepository, TypeRepository typeRepository)
        {
            this.taskRepository = taskRepository;
            this.technologyRepository = technologyRepository;
            this.typeRepository = typeRepository;
        }

        public IActionResult Index()
        {
            LexiconModel lexiconModel = new LexiconModel();
            lexiconModel.Technologies = technologyRepository.GetAll();
            lexiconModel.Tasks = taskRepository.GetAll();
            lexiconModel.Types = typeRepository.GetAll();

            return View(lexiconModel);
        }

        [HttpPost]
        public IActionResult CreateTask(LexiconModel lexiconModel)
        {
            if ((!string.IsNullOrEmpty(lexiconModel.CreateName)) &&
                !taskRepository.GetAll().Where(t => t.Name == lexiconModel.CreateName).Any())
            {
                taskRepository.Create(lexiconModel.CreateName);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateTechnology(LexiconModel lexiconModel)
        {
            if ((!string.IsNullOrEmpty(lexiconModel.CreateName)) &&
                !technologyRepository.GetAll().Where(t => t.Name == lexiconModel.CreateName).Any())
            {
                technologyRepository.Create(lexiconModel.CreateName);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateType(LexiconModel lexiconModel)
        {
            if ((!string.IsNullOrEmpty(lexiconModel.CreateName)) && 
                !typeRepository.GetAll().Where(t => t.Name == lexiconModel.CreateName).Any())
            {
                typeRepository.Create(lexiconModel.CreateName);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int Id)
        {
            taskRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTechnology(int Id)
        {
            technologyRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteType(int Id)
        {
            typeRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult EditTask(int Id)
        {
            return View(taskRepository.GetTask(Id));
        }

        public IActionResult EditTechnology(int Id)
        {
            return View(technologyRepository.GetTechnology(Id));
        }

        public IActionResult EditType(int Id)
        {
            return View(typeRepository.GetType(Id));
        }

        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            taskRepository.Update(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditTechnology(Technology technology)
        {
            technologyRepository.Update(technology);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditType(Type type)
        {
            typeRepository.Update(type);
            return RedirectToAction("Index");
        }
    }
}