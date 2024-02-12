using Microsoft.AspNetCore.Mvc;
using ProjectAPI.DTOs;
using ProjectAPI.Services;
using ProjectAPI.Services.Validation;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            return await _projectService.GetAll();
        }

        [HttpPost]
        [FluentValidation(typeof(ProjectDTOValidator))]
        public async Task<ProjectDTO> SaveProject([FromBody] ProjectDTO projectDto)
        {
            return await _projectService.Add(projectDto);
        }

    }
}
