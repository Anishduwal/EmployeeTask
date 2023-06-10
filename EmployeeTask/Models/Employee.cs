using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTask.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [ForeignKey("Persons")]
        public int PersonId { get; set; }
        public virtual Person Persons { get; set; }
        [Required]
        [ForeignKey("Positions")]
        public int PositionId { get; set; }
        public virtual Position Positions { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly? EndDate { get; set; }
        [Required]
        public Int64 EmployeeCode { get; set; }
        [Required]
        public bool IsDisabled { get; set; }

    }
}
