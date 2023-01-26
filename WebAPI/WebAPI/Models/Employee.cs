using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }

    }
}
