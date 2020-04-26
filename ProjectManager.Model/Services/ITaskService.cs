using System.Collections.Generic;
using System.Threading.Tasks;

using ProjectManager.Model.Entities;

namespace ProjectManager.Model.Services
{
    public interface ITaskService
    {
        List<PTask> GetAll();
        PTask Get(int id);
        Task Create(PTask project);
        Task Update(int id, PTask project);
        Task Delete(int id);
    }
}
