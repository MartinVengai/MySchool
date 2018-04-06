using System.Collections.Generic;
using System.Threading.Tasks;
using MySchool.Core.Models;

namespace MySchool.Core.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClasses();
    }
}