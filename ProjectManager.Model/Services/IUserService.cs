using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Model.Entities;

namespace ProjectManager.Model.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        List<User> GetAll();
        void Create(User user);
        Task<User> Get(int id);
        List<User> GetAllReduced();
    }
}
