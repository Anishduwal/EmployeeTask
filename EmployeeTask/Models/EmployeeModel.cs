using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public int PositionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> EndDate { get; set; }
        public Int64 EmployeeCode { get; set; }
        public bool IsDisabled { get; set; }
        public DateOnly EmployeeStartDate { get; set; }
        public DateOnly? EmployeeEndDate { get; set; }
    }
}
