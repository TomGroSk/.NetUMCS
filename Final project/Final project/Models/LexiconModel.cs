using Final_project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Final_project.Models
{
    public class LexiconModel
    {
        public List<Task> Tasks { get; set; }
        public List<Technology> Technologies { get; set; }
        public List<Type> Types { get; set; }
        public string CreateName { get; set; }

    }
}
