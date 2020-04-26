using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Model.Entities
{
    public class WorkTimeLog : IEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int TaskId { get; set; }

        public virtual PTask Task { get; set; }
    }
}
