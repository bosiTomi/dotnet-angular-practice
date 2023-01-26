using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IConfiguration configuration, IDepartmentService departmentService)
        {
            _configuration = configuration;
            _departmentService = departmentService;
        }

        [HttpGet]
        public JsonResult GetDepartments()
        {
            try
            {
                var departments = _departmentService.GetAllDepartments();
                return new JsonResult(departments);
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [HttpPost]
        public JsonResult AddDepartment(Department department)
        {
            try
            {
                _departmentService.AddDepartment(department);
                return new JsonResult(new { message = "Department added successfully." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

        [HttpPut]
        public JsonResult UpdateDepartment(Department department)
        {
            try
            {
                _departmentService.UpdateDepartment(department);
                return new JsonResult(new { message = "Department updated successfully." });
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
                _departmentService.DeleteDepartment(id);
                return new JsonResult(new { message = "Department deleted successfully." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { message = e.Message });
            }
        }

    }
}
