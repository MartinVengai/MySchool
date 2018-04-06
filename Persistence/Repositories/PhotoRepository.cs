using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interfaces;
using MySchool.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Persistence.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _context;

        public PhotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int studentId)
        {
            return await _context.Photos
                .Where(p => p.StudentId == studentId)
                .ToListAsync();
        }
    }
}
