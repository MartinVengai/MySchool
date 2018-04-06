using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Controllers.Resources;
using MySchool.Core.Interfaces;
using MySchool.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    [Produces("application/json")]
    [Route("api/Classes")]
    public class ClassesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;

        public ClassesController(IMapper mapper, IClassRepository classRepository)
        {
            _mapper = mapper;
            _classRepository = classRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassResource>> GetClasses()
        {
            var classes = await _classRepository.GetClasses();
            return _mapper.Map<IEnumerable<Class>, IEnumerable<ClassResource>>(classes);
        }
    }
}