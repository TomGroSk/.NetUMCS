using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project.Data.Models
{
    public class Evaluation
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string ProjectName { get; set; }

        [XmlIgnore]
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int Risk { get; set; }

        [XmlElement(ElementName = "Task")]
        public List<EstimatedTask> EstimatedTask { get; set; }
    }
}
