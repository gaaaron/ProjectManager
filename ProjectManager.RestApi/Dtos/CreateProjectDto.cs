using System.Collections.Generic;

namespace ProjectManager.RestApi.Dtos
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> UserNames { get; set; }
    }
}
