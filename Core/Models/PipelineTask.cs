using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PipelineTask:BaseEntity
    {
        public int PipelineId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool IsDone { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? DoneAt { get; set; }
        public int? UserId { get; set; }

        public Pipeline Pipeline { get; set; }
        public User User { get; set; }
        public ICollection<Checklist> Checklists { get; set; }
    }
}
