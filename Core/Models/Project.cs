using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<Pipeline> Pipelines { get; set; }
    }
}
