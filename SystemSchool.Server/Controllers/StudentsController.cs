
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> GetAll()
        {
            var students = await _context.Students.ToArrayAsync();
             var studentsDto = students.Select(s => s.ToStudentsDto());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var students = await _context.Students.FindAsync(id);
            if(students == null)
            {
                return NotFound();
            }

            return Ok(students.ToStudentsDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentsRequestDto studentsDto)
        {
            var studentsModel = studentsDto.ToStudentsFromCreateDTO();
            await _context.Students.AddAsync(studentsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = studentsModel.Id }, studentsModel.ToStudentsDto());

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentsDto updateDto)
        {
            var studentsModel = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(studentsModel == null)
            {
                return NotFound();
            }

            studentsModel.Name = updateDto.Name;
            studentsModel.Email = updateDto.Email;
            studentsModel.Age = updateDto.Age;
            await _context.SaveChangesAsync();
            return Ok(studentsModel.ToStudentsDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentsModel = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(studentsModel == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentsModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

    
}
