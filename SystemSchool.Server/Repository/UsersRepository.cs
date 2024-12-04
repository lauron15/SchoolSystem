using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;


namespace SystemSchool.Server.Repository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly ApplicationDBContext _context;

        public UsersRepository(ApplicationDBContext context) 
        {
            _context = context;

        }

        public Task<List<Users>> GetAllAsync()
        {
           return  _context.Users.ToListAsync();
        }
    }
}
