using System;

namespace ProjectManager.RestApi.Dtos
{
    public class WorkTimeLogDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string TaskName { get; set; }
    }
}
