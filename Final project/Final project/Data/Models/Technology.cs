using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project.Data.Models
{
    public class Technology
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [XmlIgnore]
        public List<EstimatedTask> EstimatedTask { get; set; }
    }
}
