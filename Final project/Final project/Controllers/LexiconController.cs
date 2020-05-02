using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
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
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(string name)
        {
            taskRepository.Create(name);
            return View("Index");
        }

        [HttpPost]
        public IActionResult CreateTechnology(string name)
        {
            technologyRepository.Create(name);
            return View("Index");
        }

        [HttpPost]
        public IActionResult CreateType(string name)
        {
            typeRepository.Create(name);
            return View("Index");
        }
    
    
        
    
    
    
    
    
    }
}