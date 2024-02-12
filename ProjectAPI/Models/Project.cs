using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI.Models
{
    [Table("projet")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("uuid")]
        public Guid GUID { get; set; }
        [StringLength(10)]
        [Column("_date")]
        public string? Date { get; set; }
        [Column("horaires")]
        public string? WorkingHours { get; set; }
        [Column("travail")]
        [StringLength(2)]
        public string? WorkAt { get; set; }
        [Column("meteo")]
        public string? Weather { get; set; }
        [Column("temp1")]
        public int? TemperatureMorning { get; set; }
        [Column("temp2")]
        public int? TemperatureAfternoon { get; set; }
        
    }
}
