using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(long id);
        List<string> GetDepartmentNames();
    }
}
