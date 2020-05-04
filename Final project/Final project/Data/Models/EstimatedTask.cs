using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project.Data.Models
{
    public class EstimatedTask
    {
        [XmlIgnore]
        public int Id { get; set; }
        public Technology Technology { get; set; }
        [XmlElement(ElementName = "Task_Name")]
        public Task Task { get; set; }
        public Type Type { get; set; }
        public bool IsCompleted { get; set; }
        public int EstimatedHours { get; set; }
        [XmlElement(ElementName = "Cost_Per_Hour")]
        public int BurntHours { get; set; }

        [XmlIgnore]
        public Evaluation Evaluation { get; set; }
    }
}
