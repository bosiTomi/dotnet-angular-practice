
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
