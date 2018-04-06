using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MySchool.Controllers.Resources
{
    public class ClassResource : KeyValuePairResource
    {
        public ClassResource()
        {
            ClassSections = new Collection<ClassSectionResource>();
        }

        public ICollection<ClassSectionResource> ClassSections { get; set; }
    }
}
