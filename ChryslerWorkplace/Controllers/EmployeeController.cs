using ChryslerWorkplace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChryslerWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ChryslerDBContext dbContext = new ChryslerDBContext();

        // GET: Employee
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        // GET: Employee/1
        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return dbContext.Employees.Find(id);
        }

        // POST: Employee
        [HttpPost]
        public Employee NewEmployee([FromBody] Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        // PUT: Employee/1
        [HttpPut("{id}")]
        public Employee UpdateEmployee(int id, [FromBody] Employee employee)
        {
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
            return employee;
        }

        // DELETE: Employee/1
        [HttpDelete("{id}")]
        public Employee DeleteEmpById(int id)
        {
            Employee delete = dbContext.Employees.Find(id);
            dbContext.Employees.Remove(delete);
            dbContext.SaveChanges();
            return delete;
        }
    }
}
