
using Microsoft.AspNetCore.Mvc;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.StudentsDto;
using SystemSchool.Server.Mappers;

namespace SystemSchool.Server.Controllers
{

    
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StudentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var students = _context.Students.ToList()
                .Select(s => s.ToStudentsDto());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var students = _context.Students.Find(id);
            if(students == null)
            {
                return NotFound();
            }

            return Ok(students.ToStudentsDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentsRequestDto studentsDto)
        {
            var studentsModel = studentsDto.ToStudentsFromCreateDTO();
            _context.Students.Add(studentsModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = studentsModel.Id }, studentsModel.ToStudentsDto());

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStudentsDto updateDto)
        {
            var studentsModel = _context.Students.FirstOrDefault(x => x.Id == id);
            if(studentsModel == null)
            {
                return NotFound();
            }

            studentsModel.Name = updateDto.Name;
            studentsModel.Email = updateDto.Email;
            studentsModel.Age = updateDto.Age;
            return Ok(studentsModel.ToStudentsDto());

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var studentsModel = _context.Students.FirstOrDefault(x => x.Id == id);
            if(studentsModel == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentsModel);
            _context.SaveChanges();
            return NoContent();
        }


    }

    
}
