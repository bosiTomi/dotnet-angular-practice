using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EmployeeContext _context;

        public DepartmentService(EmployeeContext context)
        {
            _context = context;
        }

        public Department GetDepartment(long? departmentId)
        {
            return _context.Departments.FirstOrDefault(department => department.DepartmentId == departmentId) ?? throw new InvalidOperationException();
        }

        public List<string> GetDepartmentNames()
        {
            return _context.Departments.Select(department => department.DepartmentName).ToList();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(long id)
        {
            var departmentToDelete = GetDepartment(id);
            _context.Departments.Remove(departmentToDelete);
            _context.SaveChanges();
        }
    }
}
