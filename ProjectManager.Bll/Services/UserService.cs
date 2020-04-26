using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Model;
using ProjectManager.Model.Entities;
using ProjectManager.Model.Services;

namespace ProjectManager.Bll.Services
{
    class UserService : IUserService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public UserService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            return unitOfWork.UserRepository.Query().SingleOrDefault(u => u.UserName == username && u.Password == password);
        }

        public async void Create(User user)
        {
            unitOfWork.UserRepository.Create(user);
            await unitOfWork.CommitChanges();
        }

        public async Task<User> Get(int id)
        {
            return await unitOfWork.UserRepository.GetWithAllData(id);
        }

        public List<User> GetAll()
        {
            return unitOfWork.UserRepository.Query().ToList();
        }

        public List<User> GetAllReduced()
        {
            return unitOfWork.UserRepository.GetAllReduced().ToList();
        }
    }
}
