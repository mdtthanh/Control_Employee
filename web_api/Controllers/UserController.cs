using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Entities;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllUsers()
        {
            var employees = await _context.Employee.ToListAsync();
            return Ok(employees);
        }

        // api get all info of employee end workplace

        [HttpGet("AllInfo")]
        public async Task<ActionResult<List<Employee>>> GetAllInfo()
        {
            var employees = await _context.Employee.Include(x => x.WorkPlace).ToListAsync();
            return Ok(employees);
        }
        //api add new all info off employee end workplace
        [HttpPost("AddAllInfo")]
        public async Task<ActionResult<Employee>> AddAllInfo(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet("AllInfo/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employee.Include(x => x.WorkPlace).FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // api edit info of employee 
        [HttpPut("EditInfo/{id}")]
        public async Task<ActionResult<Employee>> EditInfo(int id, Employee employee)
        {
            var employeeEdit = await _context.Employee.FindAsync(id);
            if (employeeEdit == null)
            {
                return NotFound();
            }
            employeeEdit.Username = employee.Username;
            employeeEdit.Email = employee.Email;
            employeeEdit.Password = employee.Password;
            employeeEdit.Description = employee.Description;
            employeeEdit.WorkTime = employee.WorkTime;
            employeeEdit.WorkPlaceId = employee.WorkPlaceId;
            await _context.SaveChangesAsync();
            return Ok(employeeEdit);
        }

        // api delete info of employee
        [HttpDelete("DeleteInfo/{id}")]
        public async Task<ActionResult<Employee>> DeleteInfo(int id)
        {
            var employeeDelete = await _context.Employee.FindAsync(id);
            if (employeeDelete == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(employeeDelete);
            await _context.SaveChangesAsync();
            return Ok(employeeDelete);
        }

        // api get all info of workplace
        [HttpGet("AllInfoWorkPlace")]
        public async Task<ActionResult<List<WorkPlace>>> GetAllInfoWorkPlace()
        {
            var workPlaces = await _context.WorkPlace.ToListAsync();
            return Ok(workPlaces);
        }
    }
}
