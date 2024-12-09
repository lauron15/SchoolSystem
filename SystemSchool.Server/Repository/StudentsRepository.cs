using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.StudentsDto;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Repository
{
    public class StudentsRepository: IStudentsRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Students> CreateAsync(Students studentsModel)
        {
            await _context.Students.AddAsync(studentsModel);
            await _context.SaveChangesAsync();
            return studentsModel;
        }

        public async Task<Students> DeleteAsync(int id)
        {
        
            var studentsModel = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (studentsModel != null) {
                return null;
            }
            _context.Students.Remove(studentsModel);
            await _context.SaveChangesAsync(true);
            return studentsModel;   

        }

        public async Task<List<Students>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Students> UpdateAsync(int id, UpdateStudentsDto studentsDto)
        {
            var existingStudents = await _context.Students.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingStudents != null) {
                return null;
            }   

            existingStudents.Age= studentsDto.Age;
            existingStudents.Email= studentsDto.Email;
            await _context.SaveChangesAsync();
            return existingStudents;
        }
    }
}
