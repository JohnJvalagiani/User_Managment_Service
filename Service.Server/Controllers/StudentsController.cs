using AutoMapper;
using Core.Services.Abstraction;
using Domain.Entities;
using Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Service.Server.Controllers
{

    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController: ControllerBase
    {
        private readonly IRepo<Student> _repo;
        private readonly IMapper _mapper;


        public StudentsController(IRepo<Student> repo, IMapper mapper)
        {

            this._repo = repo;

            this._mapper = mapper;

        }


        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto )
        {

            var thestudent =_mapper.Map<Student>(studentDto);



            var result = await _repo.Add(thestudent);

            return Ok(result);
        }

        
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _repo.GetAll();

            var theresult=result.Select(s => _mapper.Map<ReadStudentDto>(s)).AsEnumerable();

            return Ok(theresult);

        }


        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentById(int Id)
        {

            return Ok(await _repo.GetById(Id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
           return Ok(await  _repo.Update(student));
        }


        [HttpDelete]
        public async Task<IActionResult> Remove(int Id)
        {
          return Ok(await  _repo.Remove(Id));
        }


    }
}
