using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ProjectUser:BaseEntity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string InviteToken { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
    }
}
