using MySchool.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Core.Interfaces
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int studentId);
    }
}
