using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ChecklistItem:BaseEntity
    {
        public int ChecklistId { get; set; }
        public bool IsDone { get; set; }
        public string Content { get; set; }

        public Checklist Checklist { get; set; }
    }
}
