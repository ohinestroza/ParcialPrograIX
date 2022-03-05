using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var studentService = new StudentServices();
            {
                var student = studentService.GetStudents();
                if (student != null)
                {
                    return Ok(student);
                }
                return NotFound("ATTENTION! There is not students");
            }
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var studentService = new StudentServices();
            {
                var student = studentService.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                return NotFound("ATTENTION! There is not student with id: " + id);
            }
        }

        //api/student/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Student student)
        {
            try
            {
                var studentService = new StudentServices();
                {
                    student.id = 0;
                    await studentService.AddStudentAsync(student);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        [Route("ASYNC")]
        public async Task PutAsync([FromBody] Student student)
        {
            try
            {
                var studentService = new StudentServices();
                {
                    await studentService.UpdateStudentAsync(student);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
