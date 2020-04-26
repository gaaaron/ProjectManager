using ProjectManager.Model.Entities;
using ProjectManager.Model.Repositories;

namespace ProjectManager.Dal.Repositiories
{
    class ProjectTaskRepository : RepositoryBase<PTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ProjectManagerContext dbContext) : base(dbContext)
        {
        }
    }
}
