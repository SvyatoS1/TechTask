using Microsoft.AspNetCore.Mvc;
using Task.BLL.Validation;
using Task.DAL.Repositories.Interfaces;
using Task.DAL.Repositories.Realization;
using Task.Domain;

namespace Task.WebApi.Conrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherValidator _teacherValidator;

        public TeacherController(ITeacherRepository teacherRepository, TeacherValidator teacherValidator)
        {
            _teacherRepository = teacherRepository;
            _teacherValidator = teacherValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teacher = await _teacherRepository.GetAllAsync();
            return Ok(teacher);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _teacherRepository.GetById(id);
            return teacher == null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] Teacher teacher)
        {
            var validationResult = _teacherValidator.Validate(teacher);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            _teacherRepository.Create(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            var validationResult = _teacherValidator.Validate(teacher);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var existingTeacher = _teacherRepository.GetById(id);
            if (existingTeacher == null)
                return NotFound();

            existingTeacher.Name = teacher.Name;
            existingTeacher.Surname = teacher.Surname;
            existingTeacher.Speciality = teacher.Speciality;

            _teacherRepository.Update(existingTeacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetById(id);
            if (teacher == null)
                return NotFound();

            _teacherRepository.Delete(teacher);
            return NoContent();
        }
    }
}
