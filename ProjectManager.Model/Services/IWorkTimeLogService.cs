using System.Collections.Generic;
using System.Threading.Tasks;

using ProjectManager.Model.Entities;

namespace ProjectManager.Model.Services
{
    public interface IWorkTimeLogService
    {
        List<WorkTimeLog> GetAll();
        WorkTimeLog Get(int id);
        Task Create(WorkTimeLog project);
        Task Update(int id, WorkTimeLog project);
        Task Delete(int id);
    }
}
