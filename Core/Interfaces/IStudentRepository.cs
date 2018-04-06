using MySchool.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Core.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Task<Student> GetStudentAsync(int id);
        Task<QueryResult<Student>> GetStudentsAsync(StudentQuery queryObj);
    }
}