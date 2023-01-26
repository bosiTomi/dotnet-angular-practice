using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployee(long? employeeId);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(long id);
    }
}
