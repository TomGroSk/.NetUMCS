using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int Risk { get; set; }
        public List<EstimatedTask> EstimatedTask { get; set; }
    }
}
