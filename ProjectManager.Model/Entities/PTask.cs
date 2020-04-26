using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Model.Entities
{
    public class PTask : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual List<WorkTimeLog> WorkTimeLogs { get; set; }

        public virtual List<PTaskUser> TaskUsers { get; set; }
    }
}
