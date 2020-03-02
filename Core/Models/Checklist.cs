using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Checklist:BaseEntity
    {
        public int PipelineTaskId { get; set; }
        public string Name { get; set; }

        public PipelineTask Task { get; set; }
        public ICollection<ChecklistItem> ChecklistItems { get; set; }
    }
}
