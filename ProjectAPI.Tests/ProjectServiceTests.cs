using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectAPI.Services;
using ProjectAPI.Services.Mapper;

namespace ProjectAPI.Tests
{
    public class ProjectServiceTests
    {
        private readonly IConfiguration _configuration;
        private readonly IProjectService _projectService;

        public ProjectServiceTests()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json")
            .Build();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomAutoMapperProfile>();
            });

            var _mapper = new Mapper(configuration);

            var options = new DbContextOptionsBuilder<ProjectDbContext>()
            .UseNpgsql(_configuration.GetConnectionString("ProjectDb"))
            .Options;

            _projectService = new ProjectService(_mapper, new ProjectDbContext(options));
        }

        [Fact]
        public async Task Add_Project()
        {
            var model = await CreateModelAsync();
            var result = await _projectService.Add(model);

            Assert.NotNull(result);
            Assert.Equal(result.TemperatureMorning, model.TemperatureMorning);
            Assert.Equal(result.TemperatureAfternoon, model.TemperatureAfternoon);
        }

        [Fact]
        public async Task Get_All_Projects()
        {
            await Add_Project();
            var records = await _projectService.GetAll();
            
            Assert.NotNull(records);
            Assert.True(records.Count > 0, "The count should be greater than 0");
        }

        private async Task<DTOs.ProjectDTO> CreateModelAsync()
        {
            var random = new Random();
            var model = new DTOs.ProjectDTO
            {
                Date = DateTime.Now,
                WorkingHours = "08:00-17:00",
                WorkAt = "J",
                Weather = "Testing",
                TemperatureMorning = random.Next(15, 25),
                TemperatureAfternoon = random.Next(15, 25)
            };

            return await Task.FromResult(model);
        }
    }
}