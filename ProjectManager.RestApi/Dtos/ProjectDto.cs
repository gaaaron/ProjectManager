using System.Collections.Generic;

namespace ProjectManager.RestApi.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> UserNames { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
