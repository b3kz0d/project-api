using ProjectAPI.DTOs;

namespace ProjectAPI.Services
{
    public interface IProjectService : IReadAllService<ProjectDTO>, IAddService<ProjectDTO>
    {
    }
}
