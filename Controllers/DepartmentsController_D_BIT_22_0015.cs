using MailManagement.Data;
using MailManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController_D_BIT_22_0015 : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController_D_BIT_22_0015(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments_D_BIT_22_0015()
        {
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById_D_BIT_22_0015(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment_D_BIT_22_0015(Department_D_BIT_22_0015 department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartmentById_D_BIT_22_0015), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment_D_BIT_22_0015(int id, Department_D_BIT_22_0015 department)
        {
            if (id != department.Id)
                return BadRequest();

            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment_D_BIT_22_0015(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
