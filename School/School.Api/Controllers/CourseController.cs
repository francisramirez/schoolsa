using Microsoft.AspNetCore.Mvc;
using School.Api.Models.Modules.Course;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;


namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        [HttpGet("GetCourseByDepartmentId")]
        public IActionResult GetCourseByDepartmentId(int departmentId)
        {
            var courses = new List<Course>();
                //this.courseRepository.GetCoursesByDepartment(departmentId);
            return Ok(courses);
        }


        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = this.courseRepository.GetEntities().Select(cd => new CourseGetAllModel()
            {
                CourseId = cd.CourseID,
                ChanageDate = cd.CreationDate,
                Credits = cd.Credits,
                ChangeUser = cd.CreationUser, 
                DepartmentID= cd.DepartmentID, 
                Title= cd.Title
            }).ToList();


            return Ok(courses);
        }

        // GET api/<CourseController>/5
        [HttpGet("GetCourse")]
        public IActionResult GetCourse(int id)
        {
            var course = this.courseRepository.GetEntity(id);
            return Ok(course);
        }


        [HttpPost("SaveCourse")]
        public IActionResult Post([FromBody] CourseAddModel courseAdd)
        {

            Course course = new Course()
            {
                CreationDate = courseAdd.ChanageDate,
                CreationUser = courseAdd.ChangeUser,
                Credits = courseAdd.Credits,
                DepartmentID = courseAdd.DepartmentID,
                Title = courseAdd.Title
            };

            this.courseRepository.Save(course);

            return Ok();
        }


        [HttpPost("UpdateCourse")]
        public IActionResult Put([FromBody] CourseUpdateModel courseUpdate)
        {
            Course course = new Course()
            {
                CourseID = courseUpdate.CourseId,
                CreationDate = courseUpdate.ChanageDate,
                CreationUser = courseUpdate.ChangeUser,
                Credits = courseUpdate.Credits,
                DepartmentID = courseUpdate.DepartmentID,
                Title = courseUpdate.Title
            };

            this.courseRepository.Update(course);

            return Ok();
        }


    }
}
