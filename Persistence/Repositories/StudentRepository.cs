using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interfaces;
using MySchool.Core.Models;
using MySchool.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static System.String;

namespace MySchool.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _context.Students
                .Include(s => s.ClassSection)
                .ThenInclude(cs => cs.Class)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<QueryResult<Student>> GetStudentsAsync(StudentQuery queryObj)
        {
            var result = new QueryResult<Student>();

            var query = _context.Students
                .Include(s => s.ClassSection)
                .ThenInclude(cs => cs.Class)
                .AsQueryable();

            if (queryObj.ClassId.HasValue)
                query = query.Where(s => s.ClassSection.ClassId == queryObj.ClassId.Value);

            if (queryObj.ClassSectionId.HasValue)
                query = query.Where(s => s.ClassSectionId == queryObj.ClassSectionId);

            if (!IsNullOrWhiteSpace(queryObj.Search))
                query = query.Where(s =>
                    s.FirstName.Contains(queryObj.Search) ||
                    s.LastName.Contains(queryObj.Search) ||
                    s.Email.Contains(queryObj.Search) ||
                    s.ClassSection.Name.Contains(queryObj.Search) ||
                    s.ClassSection.Class.Name.Contains(queryObj.Search));


            var columnsMap = new Dictionary<string, Expression<Func<Student, object>>>
            {
                ["class"] = s => s.ClassSection.Class.Name,
                ["classSection"] = s => s.ClassSection.Name,
                ["firstName"] = s => s.FirstName,
                ["lastName"] = s => s.LastName
            };

            query = query.ApplyOrdering(queryObj, columnsMap);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }


    }
}
