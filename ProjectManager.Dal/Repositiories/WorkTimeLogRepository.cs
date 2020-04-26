using ProjectManager.Model.Entities;
using ProjectManager.Model.Repositories;

namespace ProjectManager.Dal.Repositiories
{
    class WorkTimeLogRepository : RepositoryBase<WorkTimeLog>, IWorkTimeLogRepository
    {
        public WorkTimeLogRepository(ProjectManagerContext dbContext) : base(dbContext)
        {
        }
    }
}
