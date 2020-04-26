using ProjectManager.Model.Enums;
using System.Collections.Generic;

namespace ProjectManager.RestApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public List<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
        public List<WorkTimeLogDto> WorkTimeLogs { get; set; } = new List<WorkTimeLogDto>();
    }
}
