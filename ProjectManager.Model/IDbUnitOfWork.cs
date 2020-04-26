using System.Threading.Tasks;

using ProjectManager.Model.Repositories;

namespace ProjectManager.Model
{
    public interface IDbUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProjectRepository ProjectRepository {get;}
        IProjectTaskRepository ProjectTaskRepository {get;}
        IWorkTimeLogRepository WorkTimeLogRepository { get; }

        Task CommitChanges();
    }
}
