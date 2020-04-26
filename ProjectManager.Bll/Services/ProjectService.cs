using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectManager.Model;
using ProjectManager.Model.Entities;
using ProjectManager.Model.Services;

namespace ProjectManager.Bll.Services
{
    class ProjectService : IProjectService
    {
        private readonly IDbUnitOfWork unitOfWork;

        public ProjectService(IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Create(Project project)
        {
            unitOfWork.ProjectRepository.Create(project);
            await unitOfWork.CommitChanges();
        }

        public async Task Delete(int id)
        {
            unitOfWork.ProjectRepository.Delete(id);
            await unitOfWork.CommitChanges();
        }

        public Project Get(int id)
        {
            return unitOfWork.ProjectRepository.Get(id);
        }

        public List<Project> GetAll()
        {
            return unitOfWork.ProjectRepository.Query().ToList();
        }

        public async Task Update(int id, Project project)
        {
            unitOfWork.ProjectRepository.Update(id, project);
            await unitOfWork.CommitChanges();
        }
    }
}
