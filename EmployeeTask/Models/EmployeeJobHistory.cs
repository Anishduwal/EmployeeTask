using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTask.Models
{
    public class EmployeeJobHistory
    {
        [Key]
        public int EmployeeJobHistoryId { get; set; }
        [Required]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public virtual Employee Employees { get; set; }
        [Required]
        [ForeignKey("Positions")]
        public int PositionId { get; set; }
        public virtual Position Positions { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
