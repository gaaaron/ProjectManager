using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectManager.Model;
using ProjectManager.Model.Entities;
using ProjectManager.Model.Services;

namespace ProjectManager.Bll.Services
{

    class TaskService : ITaskService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public TaskService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Create(PTask task)
        {
            unitOfWork.ProjectTaskRepository.Create(task);
            await unitOfWork.CommitChanges();
        }

        public async Task Delete(int id)
        {
            unitOfWork.ProjectTaskRepository.Delete(id);
            await unitOfWork.CommitChanges();
        }

        public PTask Get(int id)
        {
            return unitOfWork.ProjectTaskRepository.Get(id);
        }

        public List<PTask> GetAll()
        {
            return unitOfWork.ProjectTaskRepository.Query().ToList();
        }

        public async Task Update(int id, PTask task)
        {
            unitOfWork.ProjectTaskRepository.Update(id, task);
            await unitOfWork.CommitChanges();
        }
    }
}
