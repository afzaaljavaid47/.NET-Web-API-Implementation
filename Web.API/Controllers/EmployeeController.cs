using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.API.Models;
using Web.API.WebAPI.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ApplicationDBContext dbContext;
        public EmployeeController(ApplicationDBContext context) { 
            dbContext = context;
        }
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return dbContext.Employees;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await dbContext.Employees.Where(x => x.id == id).FirstOrDefaultAsync();
            if(data!=null)
            {
                return Ok(data);
            }
            return BadRequest();
           
        }
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return Ok("Employee added successfully!");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeModel employeeData)
        {
            EmployeeModel employee= dbContext.Employees.Where(x => x.id == id).FirstOrDefault();
            employee.name = employeeData.name;
            employee.email = employeeData.email;
            employee.address = employeeData.address;
            employee.gender = employeeData.gender;
            employee.zipcode= employeeData.zipcode;
            employee.phonenumber = employeeData.phonenumber;
            employee.userID= employeeData.userID;
            employee.state = employeeData.state;
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EmployeeModel employee = dbContext.Employees.Where(x => x.id == id).FirstOrDefault();
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
