using Final_project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class EvaluationModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int Risk { get; set; }
        public List<EstimatedTask> EstimatedTasks { get; set; }
    }
}
