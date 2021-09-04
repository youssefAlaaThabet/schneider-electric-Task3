using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using training.Data;
using training.help.docs;
using training.modes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public StudentsController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/<Students>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                return Ok(_mapper.Map<List<StudentDto>>(students));

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = " an error happened while getting all students" });
            }
        }
        // GET api/<Students>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var student = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                //var student = _students.SingleOrDefault(st => st.Id == id);
                if (student == null)
                    return NotFound(new { Error = " student with the given id does not exist" });
                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);
            }
            catch (Exception) {
                return StatusCode(404, new { Error = " student with the given id does not exist" });
            }

        }

       //  POST api/<Students>
        [HttpPost]
         public async Task<IActionResult> Post([FromBody] Student student)
          {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);

            }
            catch (Exception ex)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the student " });
            }

        }

          // PUT api/<Students>/5
          [HttpPut("{id}")]
          public async Task<IActionResult> Put(int id, [FromBody] Student student)
          {
            try
            {
                var Localstudent = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                _context.Remove(Localstudent);
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " an error occured while Updating student with id=" + id });
            }



        }

          // DELETE api/<Students>/5
          [HttpDelete("{id}")]
          public async Task<IActionResult> Delete(int id)
          {
            try
            {
                var student = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                _context.Remove(student);
                await _context.SaveChangesAsync();


                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while deleting student with id=" + id });
            }


        }
    }
}

