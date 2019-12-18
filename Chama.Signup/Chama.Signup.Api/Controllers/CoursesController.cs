﻿using System.Threading.Tasks;
using AutoMapper;
using Chama.Signup.Api.Dtos;
using Chama.Signup.Api.QueueClient;
using Chama.Signup.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chama.Signup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IQueueClient _queueClient;
        private readonly IMapper _mapper;

        public CoursesController(IQueueClient queueClient, IMapper mapper)
        {
            _queueClient = queueClient;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("{courseId:int}/students")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddStudentAsync(int courseId, StudentDto student)
        {
            var message = new SignupMessageContent
            {
                CourseId = courseId,
                StudentAge = student.Age,
                StudentName = student.Name,
                StudentEmail = student.Email
            };

            await _queueClient.SendMessage(message);
            return Accepted();
        }
    }
}