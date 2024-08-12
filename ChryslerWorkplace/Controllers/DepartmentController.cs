﻿using ChryslerWorkplace.Models;
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
            Department deleted = dbContext.Departments.Find(id);
            dbContext.Departments.Remove(deleted);
            dbContext.SaveChanges();
            return deleted;
        }
    }
}
