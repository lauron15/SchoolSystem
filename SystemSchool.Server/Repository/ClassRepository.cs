
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDBContext _context;

        public ClassRepository(ApplicationDBContext context)
        {
_context = context;
        }

        public async Task<Classes>CreateAsync(Classes classesModel)
        {
            await _context.Classes.AddAsync(classesModel);
            await _context.SaveChangesAsync();
            return classesModel;
        }

        public async Task<Classes?> DeleteAsync(int id)
        {
            var classModel = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (classModel != null)
            {
                return null;
            }

            _context.Classes.Remove(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }

        public async Task<List<Classes>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Classes?> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<Classes?> UpdateAsync(int id, UpdateCoursesDto classesDto)
        {
            var existingClasses = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (existingClasses != null)
            {
                return null;
            }

            existingClasses.Number = classesDto.Number;
            existingClasses.Capacity = classesDto.Capacity;
            await _context.SaveChangesAsync();
            return existingClasses;
        }
    }
}
