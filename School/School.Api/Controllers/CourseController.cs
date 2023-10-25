using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Modules.Course;
using School.Application.Contracts;
using School.Application.Dtos.Course;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;


namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            var result = this.courseService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<CourseController>/5
        [HttpGet("GetCourse")]
        public IActionResult GetCourse(int id)
        {
            var result = this.courseService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("SaveCourse")]
        public IActionResult Post([FromBody] CourseDtoAdd courseAdd)
        {
            var result = this.courseService.Save(courseAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("UpdateCourse")]
        public IActionResult Put([FromBody] CourseDtoUpdate courseUpdate)
        {

            var result = this.courseService.Update(courseUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("RemoveCourse")]
        public IActionResult Put([FromBody] CourseDtoRemove courseDtoRemove)
        {

            var result = this.courseService.Remove(courseDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


    }
}
