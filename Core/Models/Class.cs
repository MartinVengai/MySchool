using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MySchool.Core.Models
{
    public class Class
    {
        public Class()
        {
            ClassSections = new Collection<ClassSection>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassSection> ClassSections { get; set; }
    }
}
