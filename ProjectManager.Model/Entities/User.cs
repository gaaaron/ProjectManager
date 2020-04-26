using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ProjectManager.Model.Enums;

namespace ProjectManager.Model.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        public virtual List<ProjectUser> ProjectUsers { get; set; }

        public virtual List<PTaskUser> TasksUsers { get; set; }

        public virtual List<WorkTimeLog> WorkTimeLogs { get; set; }
    }
}
