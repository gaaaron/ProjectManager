using System;

namespace ProjectManager.RestApi.Dtos
{
    public class CreateWorkTimeLogDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
