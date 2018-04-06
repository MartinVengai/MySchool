using MySchool.Extensions;

namespace MySchool.Core.Models
{
    public class StudentQuery : IQueryObject
    {
        public int? ClassId { get; set; }
        public int? ClassSectionId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
        public string Search { get; set; }
    }
}
