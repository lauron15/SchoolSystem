using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.UsersDto;
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
        public async Task<Users> CreateAsync(Users usersModel)
        {
            await _context.Users.AddAsync(usersModel);
            await _context.SaveChangesAsync();
            return usersModel;
        }

        public async Task<Users?> DeleteAsync(int id)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(usersModel == null)
            {
                return null;
            }

            _context.Users.Remove(usersModel);
            await _context.SaveChangesAsync();
            return usersModel;
        }

        public async Task<List<Users>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users?> UpdateAsync(int id, UpdateUsersDto usersDto)
        {
            var existingUsers = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(existingUsers == null)
            {
                return null;
            }

            existingUsers.Username = usersDto.Username;
            existingUsers.Password = usersDto.Password;
            await _context.SaveChangesAsync();
            return existingUsers;

        }
    }
}
