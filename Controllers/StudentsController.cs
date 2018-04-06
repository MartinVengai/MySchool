using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySchool.Controllers.Resources;
using MySchool.Core;
using MySchool.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySchool.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<QueryResultResource<StudentResource>> GetStudents(StudentQueryResource studentQueryResource)
        {
            var filter = _mapper.Map<StudentQueryResource, StudentQuery>(studentQueryResource);
            var queryResult = await _unitOfWork.Students.GetStudentsAsync(filter);
            return _mapper.Map<QueryResult<Student>, QueryResultResource<StudentResource>>(queryResult);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudents(int id)
        {
            var student = await _unitOfWork.Students.GetStudentAsync(id);

            if (student == null)
                return NotFound();

            var studentResource = _mapper.Map<Student, StudentResource>(student);
            return Ok(studentResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveStudentResource saveStudentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = _mapper.Map<SaveStudentResource, Student>(saveStudentResource);
            _unitOfWork.Students.Add(student);
            await _unitOfWork.CompleteAsync();

            student = await _unitOfWork.Students.GetStudentAsync(student.Id);
            var studentResource = Mapper.Map<Student, StudentResource>(student);

            return Ok(studentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveStudentResource studentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _unitOfWork.Students.GetStudentAsync(id);

            if (student == null)
                return NotFound();

            _mapper.Map(studentResource, student);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Student, SaveStudentResource>(student);
            return Ok(result);
        }
    }
}