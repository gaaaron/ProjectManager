using Microsoft.EntityFrameworkCore;
using ProjectManager.Model.Entities;
using ProjectManager.Model.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Dal.Repositiories
{
    class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ProjectManagerContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<User> GetAllReduced()
        {
            return dbContext.Users.AsNoTracking()
                                  .Include(u => u.ProjectUsers).ThenInclude(u => u.Project);
        }

        public async Task<User> GetWithAllData(int id)
        {
            return await dbContext.Users.AsNoTracking()
                                  .Include(u => u.ProjectUsers).ThenInclude(u => u.Project).ThenInclude(p => p.Tasks)
                                  .Include(u => u.WorkTimeLogs).ThenInclude(w => w.Task)
                                  .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
