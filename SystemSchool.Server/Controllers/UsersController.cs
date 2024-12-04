using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.UsersDto;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Mappers;

namespace SystemSchool.Server.Controllers
{

    [Route("api/users")]
    //Tenho a opção de ser igual está acima, ou também de ser assim: [Route("api/[cotrollers]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUsersRepository _usersRepo;
       
        public UsersController(ApplicationDBContext context, IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _usersRepo.GetAllAsync();
            var usersModel= users.Select(s => s.ToUsersDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users.ToUsersDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsersRequestDto usersDto)
        {
            var usersModel = usersDto.ToUsersFromCreateDTO();
           await _context.Users.AddAsync(usersModel);
            await _context.SaveChangesAsync();
  
            return CreatedAtAction(nameof(GetById), new { id = usersModel.Id }, usersModel.ToUsersDto());

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersDto updateDto)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (usersModel == null)
            {
                return NotFound();
            }

            usersModel.Username = updateDto.Username;
            usersModel.Password = updateDto.Password;
            await _context.SaveChangesAsync();
            return Ok(usersModel.ToUsersDto());

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete ([FromRoute]int id)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(usersModel == null)
            {
                return NotFound();
            }
            _context.Users.Remove(usersModel);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}



