using Microsoft.AspNetCore.Mvc;
using StudentApi.Model;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _repository;

        public StudentController(IConfiguration configuration)
        {
            // Retrieve connection string from appsettings.json
            string connectionString = configuration.GetConnectionString("DefaultConnection")
                          ?? "Server=LAPTOP-SHSMVAML\\SQLEXPRESS;Database=Student;Trusted_Connection=True;";

            _repository = new StudentRepository(connectionString);

        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            try
            {
                var students = _repository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
