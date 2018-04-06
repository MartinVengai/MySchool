using MySchool.Core;
using MySchool.Core.Interfaces;
using MySchool.Persistence.Repositories;
using System.Threading.Tasks;

namespace MySchool.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Students { get; }
        public IPhotoRepository Photos { get; }
        public IClassRepository Classes { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Classes = new ClassRepository(_context);
            Photos = new PhotoRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
