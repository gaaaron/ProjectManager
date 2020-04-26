using System.Threading.Tasks;

using ProjectManager.Model;
using ProjectManager.Model.Repositories;

namespace ProjectManager.Dal
{
    class UnitOfWork : IDbUnitOfWork
    {
        private ProjectManagerContext _dbContext;
        public IUserRepository UserRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IProjectTaskRepository ProjectTaskRepository { get; }
        public IWorkTimeLogRepository WorkTimeLogRepository { get; }

        public UnitOfWork(
            ProjectManagerContext dbContext,
            IUserRepository userRepository, IProjectRepository projectRepository, IProjectTaskRepository projectTaskRepository, IWorkTimeLogRepository workTimeLogRepository)
        {
            this._dbContext = dbContext;
            UserRepository = userRepository;
            ProjectRepository = projectRepository;
            ProjectTaskRepository = projectTaskRepository;
            WorkTimeLogRepository = workTimeLogRepository;
        }

        public async Task CommitChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
