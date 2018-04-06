using AutoMapper;
using MySchool.Controllers.Resources;
using MySchool.Core.Models;

namespace MySchool.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Class, ClassResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap<Student, StudentResource>()
                .ForMember(sr => sr.Class, opt => opt.MapFrom(s => s.ClassSection.Class));

            CreateMap<SaveStudentResource, Student>();
            CreateMap<StudentQueryResource, StudentQuery>();
        }
    }
}
