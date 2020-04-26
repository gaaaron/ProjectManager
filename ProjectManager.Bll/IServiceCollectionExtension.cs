using Microsoft.Extensions.DependencyInjection;

using ProjectManager.Bll.Services;
using ProjectManager.Dal;
using ProjectManager.Model.Services;

namespace ProjectManager.Bll
{
    public static class IServiceCollectionExtension
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddDatabaseServices();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IWorkTimeLogService, WorkTimeLogService>();
        }
    }
}
