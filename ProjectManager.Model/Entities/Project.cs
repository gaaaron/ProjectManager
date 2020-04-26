using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Model.Entities
{
    public class Project : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<ProjectUser> ProjectUsers { get; set; }

        public virtual List<PTask> Tasks { get; set; }
    }
}
