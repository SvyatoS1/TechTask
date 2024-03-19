using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Task.BLL.Validation;
using Task.DAL.Repositories.Interfaces;
using Task.DAL.Repositories.Realization;
using Task.Domain;

namespace Task.WebApi.Conrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentValidator _studentValidator;

        public StudentController(IStudentRepository studentRepository, StudentValidator studentValidator)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var student = await _studentRepository.GetAllAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentRepository.GetById(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var validationResult = _studentValidator.Validate(student);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _studentRepository.Create(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var validationResult = _studentValidator.Validate(student);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var existingStudent = _studentRepository.GetById(id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.Surname = student.Surname;

            _studentRepository.Update(existingStudent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var course = _studentRepository.GetById(id);
            if (course == null)
                return NotFound();

            _studentRepository.Delete(course);
            return NoContent();
        }
    }
}
