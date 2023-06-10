using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeTask.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(256)")]
        [StringLength(10)]
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar(256)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
