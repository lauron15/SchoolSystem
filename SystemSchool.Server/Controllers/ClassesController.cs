using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Mappers;

namespace SystemSchool.Server.Controllers
{

    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ClassesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var classes = await _context.Classes.ToListAsync();
            var classesDto = classes.Select(s => s.ToClassesDto());
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var classesModel = await _context.Classes.FindAsync(id);
            if (classesModel == null)
            {
                return NotFound();
            }
            return Ok(classesModel.ToClassesDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassesRequestDto classeDto)
        {
            var classesModel = classeDto.ToClassesFromCreateDTO();
            await _context.Classes.AddAsync(classesModel);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetById), new { id = classesModel.Id }, classesModel.ToClassesDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)

        {
            var classesModel = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (classesModel == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classesModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
