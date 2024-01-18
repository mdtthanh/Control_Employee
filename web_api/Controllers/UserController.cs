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
        public async Task<ActionResult<List<Employee>>> GetAllUsers(DateTime? v)
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

    }
}
