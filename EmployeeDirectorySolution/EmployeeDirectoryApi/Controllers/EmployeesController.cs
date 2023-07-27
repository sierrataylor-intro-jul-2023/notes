using EmployeeDirectoryApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApi.Controllers
{
    public class EmployeesController: ControllerBase
    {
        private readonly EmployeesDataContext _context;

        public EmployeesController(EmployeesDataContext context)
        {
            _context = context;
        }

        [HttpGet("/employees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            var response = await _context.Employees.OrderBy(e => e.LastName).Select(emp => new EmployeeResponseModel
            {
                Id = emp.Id.ToString(),
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,

            }).ToListAsync();
            
            
            return Ok(response);
        }

        [HttpPost("/employees")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeRequestModel employee)
        {
            //mapping body to appropriate data type- this is required and error prone, but there is an an AutoMapper class
            var employeeToAdd = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Salary = employee.Salary,
                Phone = employee.Phone,
            };
            _context.Employees.Add(employeeToAdd);
            await _context.SaveChangesAsync();
            return Ok(employeeToAdd);
        }
    }

    public record EmployeeRequestModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

    }

    public record EmployeeResponseModel
    {
        public string Id { get; set; } = string.Empty
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
