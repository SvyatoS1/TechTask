using Microsoft.AspNetCore.Mvc;
using Task.BLL.Validation;
using Task.DAL.Repositories.Interfaces;
using Task.Domain;

namespace Task.WebApi.Conrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly CourseValidator _courseValidator;

        [HttpGet]
        public async Task<IActionResult> GetAllCourses() 
        {
            var course = await _courseRepository.GetAllAsync();
            return Ok(course);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            var validationResult = _courseValidator.Validate(course);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _courseRepository.Create(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            var existingCourse = _courseRepository.GetById(id);
            if (existingCourse == null)
                return NotFound();

            course.Id = id;
            var validationResult = _courseValidator.Validate(course);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _courseRepository.Update(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _courseRepository.GetById(id);
            if(course == null)
                return NotFound();

            _courseRepository.Delete(course);
            return NoContent();
        }
    }
}
