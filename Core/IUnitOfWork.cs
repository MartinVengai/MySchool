using MySchool.Core.Interfaces;
using System.Threading.Tasks;

namespace MySchool.Core
{
    public interface IUnitOfWork
    {
        IClassRepository Classes { get; }
        IStudentRepository Students { get; }
        IPhotoRepository Photos { get; }
        Task<int> CompleteAsync();
    }
}