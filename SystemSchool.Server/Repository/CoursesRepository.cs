using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Data;
using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Interfaces;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDBContext _context;

        public CoursesRepository(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<Courses> CreateAsync(Courses coursesModel)
        {
            await _context.Courses.AddAsync(coursesModel);
            await _context.SaveChangesAsync();
            return coursesModel;
        }

        public async Task<Courses> DeleteAsync(int id)
        {
            var coursesModel = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (coursesModel != null)
            {
                return null;
            }

            _context.Courses.Remove(coursesModel);
            await _context.SaveChangesAsync();
            return coursesModel;
        }

        public async Task<List<Courses>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses?> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Courses> UpdateAsync(int id, UpdateCoursesDto coursesDto)
        {
            var existingCourses = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            {
                if (existingCourses != null)
                {
                    return null;
                }

                existingCourses.Name = coursesDto.Name;
                existingCourses.Workload = coursesDto.Workload;
                await _context.SaveChangesAsync();
                return existingCourses;
            }
        }
    }
}
