using WebAPI.DataAccess;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public Employee GetEmployee(long? employeeId)
        {
            return _context.Employees.FirstOrDefault(employee => employee.EmployeeId == employeeId) ?? throw new InvalidOperationException();
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(long id)
        {
            var employeeToDelete = GetEmployee(id);
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
        }

    }
}
