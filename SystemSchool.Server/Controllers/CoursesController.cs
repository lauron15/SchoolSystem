using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.CoursesDto;
using SystemSchool.Server.Mappers;
using SystemSchool.Server.Models;


namespace SystemSchool.Server.Controllers
{
    [ApiController]
    [Route("api/courses")]
    
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CoursesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  async Task<ActionResult> GetAll()
        {
            var courses = await _context.Courses.ToListAsync();
            var coursesDto = courses.Select(s => s.ToCoursesDto());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses.ToCoursesDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCoursesRequestDto coursesDto)
        {
            var coursesModel = coursesDto.ToCoursesFromCreateDTO();
           await _context.Courses.AddAsync(coursesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = coursesModel.Id }, coursesModel.ToCoursesDto());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCoursesDto updateDto)
        {
            var coursesModel = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if(coursesModel == null)
            {
                return NotFound();
            }

            coursesModel.Name = updateDto.Name;
            coursesModel.Workload = updateDto.workload;
            await _context.SaveChangesAsync();
            return Ok(coursesModel.ToCoursesDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var coursesModel = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(coursesModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
