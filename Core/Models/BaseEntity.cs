using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
