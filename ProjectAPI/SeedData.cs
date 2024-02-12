using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI
{
    public static  class SeedData
    {
        private static List<Project> _projects => new List<Project>
        {
            new Project
            {
                Date = "2023-01-01",
                WorkingHours = "08:00-17:00",
                WorkAt = "J",
                Weather = "Ensoleillé",
                TemperatureMorning = 23,
                TemperatureAfternoon = 25
            },
            new Project
            {
                Date = "2023-01-02",
                WorkingHours = "09:00-18:00",
                WorkAt = "PM",
                Weather = "Nuageux",
                TemperatureMorning = 20,
                TemperatureAfternoon = 22
            },
            new Project
            {
                Date = "2023-01-03",
                WorkingHours = "10:00-19:00",
                WorkAt = "PS",
                Weather = "Pluvieux",
                TemperatureMorning = 18,
                TemperatureAfternoon = 20
            },
            new Project
            {
                Date = "2023-01-04",
                WorkingHours = "07:00-16:00",
                WorkAt = "J",
                Weather = "Orageux",
                TemperatureMorning = 16,
                TemperatureAfternoon = 18
            },
            new Project
            {
                Date = "2023-01-05",
                WorkingHours = "08:30-17:30",
                WorkAt = "PM",
                Weather = "Neigeux",
                TemperatureMorning = 15,
                TemperatureAfternoon = 17
            },
            new Project
            {
                Date = "2023-01-06",
                WorkingHours = "09:30-18:30",
                WorkAt = "PS",
                Weather = "Vent fort",
                TemperatureMorning = 17,
                TemperatureAfternoon = 19
            },
            new Project
            {
                Date = "2023-01-07",
                WorkingHours = "10:30-19:30",
                WorkAt = "J",
                Weather = "Brumeux",
                TemperatureMorning = 19,
                TemperatureAfternoon = 21
            },
            new Project
            {
                Date = "2023-01-08",
                WorkingHours = "11:00-20:00",
                WorkAt = "PM",
                Weather = "Ensoleillé",
                TemperatureMorning = 22,
                TemperatureAfternoon = 24
            },
            new Project
            {
                Date = "2023-01-09",
                WorkingHours = "06:00-15:00",
                WorkAt = "PS",
                Weather = "Nuageux",
                TemperatureMorning = 21,
                TemperatureAfternoon = 23
            },
            new Project
            {
                Date = "2023-01-10",
                WorkingHours = "07:30-16:30",
                WorkAt = "J",
                Weather = "Pluvieux",
                TemperatureMorning = 18,
                TemperatureAfternoon = 19
            }
        };

        public static async Task Initialize(ProjectDbContext context)
        {
            context.Database.Migrate();
            if (!context.Projects.Any())
            {
                await context.Projects.AddRangeAsync(_projects);
                await context.SaveChangesAsync();
            }
        }
    }
}
