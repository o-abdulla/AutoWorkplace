using ChryslerWorkplace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChryslerWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        ChryslerDBContext dbContext = new ChryslerDBContext();

        // GET: Departments
        [HttpGet]
        public List<Department> GetDepts()
        {
            return dbContext.Departments.ToList();
        }
        
        // GET: Departments/1
        [HttpGet("{deptId}")]
        public ActionResult<Department> GetByDeptId(int deptId)
        {
            var dept = dbContext.Departments.Find(deptId);

            if (dept == null)
            {
                return NotFound();
            }
            return dept;
        }

        // GET: Departments/1380
        [HttpGet("{deptNumber}")]
        public Department GetByDeptNumber(int deptNumber)
        {
            return dbContext.Departments.Find(deptNumber);
        }

        // ______________Original Post Method__________________________

        // POST: Departments
        //[HttpPost]
        //public Department newDept([FromBody] Department dept)
        //{
        //    dbContext.Departments.Add(dept);
        //    dbContext.SaveChanges();
        //    return dept;
        //}

        //__________________________________________

        // POST: Departments
        [HttpPost]
        public IActionResult AddDept([FromBody] Department dept)
        {
            if (string.IsNullOrWhiteSpace(dept.DepartmentName))
            {
                return BadRequest("Please enter a valid Department name.");
            }
            try
            {
                dbContext.Departments.Add(dept);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetByDeptId), new { id = dept.DepartmentId }, dept);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        // PUT: Departments/1
        [HttpPut("{id}")]
        public Department UpdateDept(int id, [FromBody] Department dept)
        {
            dbContext.Departments.Update(dept);
            dbContext.SaveChanges();
            return dept;
        }

        // DELETE: Departments/1
        [HttpDelete("{id}")]
        public Department DeleteDept(int id)
        {
            try
            {
                // Step 1: Find the department by its ID
                Department deptDelete = dbContext.Departments.Find(id);

                // Step 2: Check if the department exists
                if (deptDelete == null)
                {
                    return null;
                }

                // Step 3: Check if there are any employees associated with this department
                bool hasEmployees = dbContext.Employees.Any(e => e.DepartmentId == id);
                if (hasEmployees)
                {
                    throw new Exception("Unable to delete department with employees");
                }


                // Step 5: If no employees are associated with the department, delete it, save changes to DB
                dbContext.Departments.Remove(deptDelete);
                dbContext.SaveChanges();
                return deptDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            
        }
    }
}
