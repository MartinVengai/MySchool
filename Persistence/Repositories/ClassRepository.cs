using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interfaces;
using MySchool.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Persistence.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _context.Classes.Include(c => c.ClassSections).ToListAsync();
        }
    }
}
