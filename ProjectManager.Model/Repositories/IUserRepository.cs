using System.Linq;
using System.Threading.Tasks;

using ProjectManager.Model.Entities;

namespace ProjectManager.Model.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithAllData(int id);
        IQueryable<User> GetAllReduced();
    }
}
