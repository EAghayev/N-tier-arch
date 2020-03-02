using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class User:BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<PipelineTask> Tasks { get; set; }
    }
}
