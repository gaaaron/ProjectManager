using System.Collections.Generic;
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
    public class WorkTimeLogController : ControllerBase
    {
        private readonly IWorkTimeLogService workTimeLogService;
        private readonly IMapper mapper;

        public WorkTimeLogController(IWorkTimeLogService workTimeLogService, IMapper mapper)
        {
            this.workTimeLogService = workTimeLogService;
            this.mapper = mapper;
        }

        // GET: api/WorkTimeLog
        [HttpGet]
        public IEnumerable<WorkTimeLogDto> Get()
        {
            var workTimeLogs = workTimeLogService.GetAll();
            return mapper.Map<List<WorkTimeLogDto>>(workTimeLogs);
        }

        // GET: api/WorkTimeLog/5
        [HttpGet("{id}")]
        public WorkTimeLogDto Get(int id)
        {
            var workTimeLog = workTimeLogService.Get(id);
            return mapper.Map<WorkTimeLogDto>(workTimeLog);
        }

        // POST: api/WorkTimeLog
        [HttpPost]
        public async Task<int> Post([FromBody] CreateWorkTimeLogDto value)
        {
            var workTimeLog = mapper.Map<WorkTimeLog>(value);
            await workTimeLogService.Create(workTimeLog);

            return workTimeLog.Id;
        }

        // PUT: api/WorkTimeLog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WorkTimeLogDto value)
        {
            var workTimeLog = mapper.Map<WorkTimeLog>(value);
            workTimeLogService.Update(id, workTimeLog);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            workTimeLogService.Delete(id);
        }
    }
}
