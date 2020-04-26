using System.Collections.Generic;
using System.Threading.Tasks;

using ProjectManager.Model.Entities;

namespace ProjectManager.Model.Services
{
    public interface IProjectService
    {
        List<Project> GetAll();
        Project Get(int id);
        Task Create(Project project);
        Task Update(int id, Project project);
        Task Delete(int id);
    }
}
