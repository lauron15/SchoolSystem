using Microsoft.AspNetCore.Mvc;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.UsersDto;
using SystemSchool.Server.Mappers;

namespace SystemSchool.Server.Controllers
{

    [Route("api/users")]
    //Tenho a opção de ser igual está acima, ou também de ser assim: [Route("api/[cotrollers]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var users = _context.Users.ToList()
                .Select(s => s.ToUsersDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var users = _context.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users.ToUsersDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUsersRequestDto usersDto)
        {
            var usersModel = usersDto.ToUsersFromCreateDTO();
            _context.Users.Add(usersModel);
            _context.SaveChanges();
  
            return CreatedAtAction(nameof(GetById), new { id = usersModel.Id }, usersModel.ToUsersDto());

        }
    }
}
