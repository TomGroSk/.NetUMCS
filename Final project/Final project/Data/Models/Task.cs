using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EstimatedTask> EstimatedTask { get; set; }
    }
}
