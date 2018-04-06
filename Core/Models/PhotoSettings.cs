using System.IO;
using System.Linq;

namespace MySchool.Core.Models
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupported(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName).ToLower();
            return AcceptedFileTypes.Any(s => s.ToLower() == fileExtension);
        }
    }
}
