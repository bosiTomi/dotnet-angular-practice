using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAccess;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment env, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _env = env;
            _departmentService = departmentService;
        }

        [HttpGet]
        public JsonResult GetDepartments()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return new JsonResult(employees);
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [HttpPost]
        public JsonResult AddDepartment(Employee employee)
        {
            try
            {
                _employeeService.AddEmployee(employee);
                return new JsonResult(new { message = "Employee added successfully." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [HttpPut]
        public JsonResult UpdateDepartment(Employee employee)
        {
            try
            {
                _employeeService.UpdateEmployee(employee);
                return new JsonResult(new { message = "Employee updated successfully." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteDepartment(long id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return new JsonResult(new { message = "Employee deleted successfully." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Uploads/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            try
            {
                var departmentNames = _departmentService.GetDepartmentNames();
                return new JsonResult(departmentNames);
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }
    }
}
