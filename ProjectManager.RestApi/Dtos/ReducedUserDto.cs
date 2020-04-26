using System.Collections.Generic;

namespace ProjectManager.RestApi.Dtos
{
    public class ReducedUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public List<string> ProjectNames { get; set; }
    }
}
