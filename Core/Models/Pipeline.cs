using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Pipeline:BaseEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int Order { get; set; }

        public Project Project { get; set; }
        public ICollection<PipelineTask> Tasks { get; set; }
    }
}
