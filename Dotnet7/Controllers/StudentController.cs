using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dotnet7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dotnet7.Controllers
{
    [Route("api/v1/[controller]")]
    public class StudentController : Controller
    {
        private CollegeContext _dbContext;

        public StudentController(CollegeContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        public IEnumerable<Student> Get()
        {
            return _dbContext.Students.ToList();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user,admin")]
        public Student Get(int id)
        {
            return _dbContext.Students.FirstOrDefault(s => s.Id == id);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
    }
}

