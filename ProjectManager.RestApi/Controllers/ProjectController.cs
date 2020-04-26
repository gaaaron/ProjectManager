using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using ProjectManager.Model.Entities;
using ProjectManager.Model.Services;
using ProjectManager.RestApi.Dtos;

namespace ProjectManager.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ProjectController(IProjectService projectService, IUserService userService, IMapper mapper)
        {
            this.projectService = projectService;
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<ProjectDto> Get()
        {
            var projects = projectService.GetAll();
            return mapper.Map<List<ProjectDto>>(projects);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public ProjectDto Get(int id)
        {
            var project = projectService.Get(id);
            return mapper.Map<ProjectDto>(project);
        }

        // POST: api/Project
        [HttpPost]
        public async Task<int> Post([FromBody] CreateProjectDto projectDto)
        {
            var project = mapper.Map<Project>(projectDto);
            project.ProjectUsers = userService.GetAll()
                                              .Where(x => projectDto.UserNames.Contains(x.UserName))
                                              .Select(user => new ProjectUser { UserId = user.Id, Project = project })
                                              .ToList();

            await projectService.Create(project);

            return project.Id;
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProjectDto projectDto)
        {
            var project = mapper.Map<Project>(projectDto);
            project.ProjectUsers = userService.GetAll()
                                  .Where(x => projectDto.UserNames.Contains(x.UserName))
                                  .Select(user => new ProjectUser { UserId = user.Id, Project = project })
                                  .ToList();

            projectService.Update(id, project);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            projectService.Delete(id);
        }
    }
}
