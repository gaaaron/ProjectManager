using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectManager.Model;
using ProjectManager.Model.Entities;
using ProjectManager.Model.Services;


namespace ProjectManager.Bll.Services
{
    class WorkTimeLogService : IWorkTimeLogService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public WorkTimeLogService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Create(WorkTimeLog workTimeLog)
        {
            unitOfWork.WorkTimeLogRepository.Create(workTimeLog);
            await unitOfWork.CommitChanges();
        }

        public async Task Delete(int id)
        {
            unitOfWork.WorkTimeLogRepository.Delete(id);
            await unitOfWork.CommitChanges();
        }

        public WorkTimeLog Get(int id)
        {
            return unitOfWork.WorkTimeLogRepository.Get(id);
        }

        public List<WorkTimeLog> GetAll()
        {
            return unitOfWork.WorkTimeLogRepository.Query().ToList();
        }

        public async Task Update(int id, WorkTimeLog workTimeLog)
        {
            unitOfWork.WorkTimeLogRepository.Update(id, workTimeLog, w => w.UserId, w => w.TaskId);
            await unitOfWork.CommitChanges();
        }
    }
}
