using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dotnet7.Models;

namespace Dotnet7.Controllers
{

    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private CollegeContext _dbContext;
        private readonly IConfiguration _config;

        public UserController(CollegeContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public ActionResult Login([FromBody] LoginModel loginModel)
        {
            var response = new Dictionary<string, string>();
            var student = _dbContext.Students.FirstOrDefault(s => s.Email == loginModel.Username && s.Password == loginModel.Password);
            if(student != null)
            {
                var token = GenerateToken(student);
                response.Add("token", token);
                return Ok(response);
            }
            return NotFound("user not found");
        }


        [HttpPost("/Register")]
        public void Register([FromBody] Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        private string GenerateToken(Student user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}