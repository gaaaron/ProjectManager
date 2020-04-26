using Microsoft.Extensions.DependencyInjection;

using ProjectManager.Dal.Repositiories;
using ProjectManager.Model;
using ProjectManager.Model.Repositories;

namespace ProjectManager.Dal
{
    public static class IServiceCollectionExtension
    {
        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddDbContext<ProjectManagerContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddTransient<IWorkTimeLogRepository, WorkTimeLogRepository>();
            services.AddTransient<IDbUnitOfWork, UnitOfWork>();
        }
    }
}
