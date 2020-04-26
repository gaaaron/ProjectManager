using System.Collections.Generic;

namespace ProjectManager.RestApi.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public List<string> UserNames { get; set; }
    }
}
