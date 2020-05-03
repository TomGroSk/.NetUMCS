using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class EstimatedTaskModel
    {
        public bool IsCompleted { get; set; }
        public int EstimatedHours { get; set; }
        public int BurntHours { get; set; }
        public string Type { get; set; }
        public string Technology { get; set; }
        public string Task { get; set; }
        public List<SelectListItem> Tasks { get; set; }
        public List<SelectListItem> Technologies { get; set; }
        public List<SelectListItem> Types { get; set; }
    }
}
