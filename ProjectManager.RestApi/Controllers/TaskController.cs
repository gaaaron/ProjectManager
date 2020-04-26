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
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public TaskController(ITaskService taskService, IUserService userService, IMapper mapper)
        {
            this.taskService = taskService;
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET: api/Task
        [HttpGet]
        public IEnumerable<TaskDto> Get()
        {
            var tasks = taskService.GetAll();
            return mapper.Map<List<TaskDto>>(tasks);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public TaskDto Get(int id)
        {
            var task = taskService.Get(id);
            return mapper.Map<TaskDto>(task);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<int> Post([FromBody] CreateTaskDto value)
        {
            var task = mapper.Map<PTask>(value);
            task.TaskUsers = userService.GetAll()
                                        .Where(x => value.UserNames.Contains(x.UserName))
                                        .Select(user => new PTaskUser { UserId = user.Id, Task = task })
                                        .ToList();

            await taskService.Create(task);

            return task.Id;
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskDto value)
        {
            var task = mapper.Map<PTask>(value);
            task.TaskUsers = userService.GetAll()
                                        .Where(x => value.UserNames.Contains(x.UserName))
                                        .Select(user => new PTaskUser { UserId = user.Id, Task = task })
                                        .ToList();

            taskService.Update(id, task);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            taskService.Delete(id);
        }
    }
}
