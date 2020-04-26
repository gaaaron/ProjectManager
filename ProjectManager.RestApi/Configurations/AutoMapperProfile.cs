using AutoMapper;
using ProjectManager.Model.Entities;
using ProjectManager.RestApi.Dtos;
using System.Linq;

namespace ProjectManager.RestApi.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, ReducedUserDto>().ForMember(dest => dest.ProjectNames, opt => opt.MapFrom(u => u.ProjectUsers.Select(pu => pu.Project.Name)));

            CreateMap<Project, ProjectDto>().ForMember(dest => dest.UserNames, opt => opt.MapFrom(src => src.ProjectUsers.Select(pu => pu.User.Name)));
            CreateMap<ProjectDto, Project>();
            CreateMap<CreateProjectDto, Project>();

            CreateMap<PTask, TaskDto>().ForMember(dest => dest.UserNames, opt => opt.MapFrom(src => src.TaskUsers.Select(pu => pu.User.Name)));
            CreateMap<TaskDto, PTask>();
            CreateMap<CreateTaskDto, PTask>();

            CreateMap<WorkTimeLog, WorkTimeLogDto>().ForMember(dest => dest.TaskName, opt => opt.MapFrom(wl => wl.Task.Name));
            CreateMap<WorkTimeLogDto, WorkTimeLog>();
            CreateMap<CreateWorkTimeLogDto, WorkTimeLog>();

            CreateMap<ProjectUser, ProjectDto>().ConstructUsing((user, context) => context.Mapper.Map<ProjectDto>(user.Project));
            CreateMap<User, UserDto>().ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.ProjectUsers));
        }
    }
}
