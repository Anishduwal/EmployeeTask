using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTask.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        public string PositionName { get; set; }
    }
}
