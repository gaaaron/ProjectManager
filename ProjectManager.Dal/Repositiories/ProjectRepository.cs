using ProjectManager.Model.Entities;
using ProjectManager.Model.Repositories;

namespace ProjectManager.Dal.Repositiories
{
    class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagerContext dbContext) : base(dbContext)
        {
        }
    }
}
