using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.DTOs;
using ProjectAPI.Models;

namespace ProjectAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly ProjectDbContext _dbContext;
        public ProjectService(IMapper mapper, ProjectDbContext dbContext) 
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<ProjectDTO>> GetAll()
        {
            var entities = await _dbContext.Projects.ToListAsync();
            return _mapper.Map<List<ProjectDTO>>(entities);
        }

        public async Task<ProjectDTO> Add(ProjectDTO dto)
        {
            var entity = _mapper.Map<Project>(dto);
            _dbContext.Projects.Add(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProjectDTO>(entity);
        }
    }
}
