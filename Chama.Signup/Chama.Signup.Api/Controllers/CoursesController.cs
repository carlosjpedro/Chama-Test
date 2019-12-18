using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Chama.Signup.Api.Dtos;
using Chama.Signup.Services;
using Chama.Signup.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Chama.Signup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        private readonly IMapper _mapper;

        public CoursesController(IStudentManager studentManager, IMapper mapper)
        {
            _studentManager = studentManager;
            _mapper = mapper;
        }


        /// <summary>
        /// Add student to course
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <param name="student">New Student</param>
        /// <returns></returns>
        /// <response code="404">Course Not Found</response>
        /// <response code="400">Invalid Student Data</response>
        [HttpPost]
        [Route("{courseId:int}/students")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult AddStudent(int courseId, StudentDto student)
        {
            _studentManager.AddStudentToCourse(courseId, _mapper.Map<Student>(student));
            return Ok("Student added to course.");
        }
    }
}