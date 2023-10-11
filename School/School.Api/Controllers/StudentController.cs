using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Modules.Student;
using School.Domain.Entities;
using School.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        // GET: api/<StudentController>
        [HttpGet("GetStudents")]
        public IActionResult Get()
        {
            var students = this.studentRepository.GetEntities()
                                                 .Select(st =>
                                                          new GetStudentModel()
                                                          {
                                                              CreationDate = st.CreationDate,
                                                              EnrollmentDate = st.EnrollmentDate,
                                                              FirstName = st.FirstName,
                                                              LastName = st.LastName,
                                                              StudentId = st.Id

                                                          });

            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var student = this.studentRepository.GetEntity(id);

            GetStudentModel studentModel = new GetStudentModel()
            {
                CreationDate = student.CreationDate,
                EnrollmentDate = student.EnrollmentDate,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.Id
            };


            return Ok(studentModel);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
