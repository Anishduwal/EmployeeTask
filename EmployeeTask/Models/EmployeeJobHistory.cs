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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly EndDate { get; set; }
    }
}
