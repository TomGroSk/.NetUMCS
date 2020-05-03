using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class EstimatedTask
    {
        public int Id { get; set; }
        public Technology Technology { get; set; }
        public Task Task { get; set; }
        public Type Type { get; set; }
        public bool IsCompleted { get; set; }
        public int EstimatedHours { get; set; }
        public int BurntHours { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
