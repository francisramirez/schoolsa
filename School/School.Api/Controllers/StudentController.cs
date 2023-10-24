using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Modules.Student;
using School.Application.Contracts;
using School.Application.Dtos.Student;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;


namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public IActionResult Get()
        {
            var result = this.studentService.GetAll();

            if (!result.Success)
              return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var result = this.studentService.GetById(id);
            
            if (!result.Success)
              return BadRequest(result);

            return Ok(result);
        }


        [HttpPost("SaveStudent")]
        public IActionResult Post([FromBody] StudentDtoAdd studentApp)
        {

            var result = this.studentService.Save(studentApp);
            
            if (!result.Success)
                return BadRequest(result);
            

            return Ok(result);
        }


        [HttpPost("UpdateStudent")]
        public IActionResult Put([FromBody] StudentDtoUpdate studentDtoUpdate)
        {
            var result = this.studentService.Update(studentDtoUpdate);

            if (!result.Success)
                return BadRequest(result);
            
           
            return Ok(result);
        }
        [HttpPost("RemoveStudent")]
        public IActionResult Remove([FromBody] StudentDtoRemove studentDtoRemove)
        {
            var result = this.studentService.Remove(studentDtoRemove);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

    }
}
