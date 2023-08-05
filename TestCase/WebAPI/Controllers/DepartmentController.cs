using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartment")]
        public List<Department> GetAllDepartment(int? departmentId)
        {
            return _departmentService.GetAll(departmentId);
        }


        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            var result = _departmentService.AddDepartment(department);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("UpdateDepartment")]
        public IActionResult UpdateDepartment(Department department)
        {
            var result = _departmentService.UpdateDepartment(department);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("DeleteDepartment")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            var result = _departmentService.DeleteDepartment(departmentId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
