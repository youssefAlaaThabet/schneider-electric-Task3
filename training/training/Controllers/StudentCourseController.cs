using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using training.Data;
using training.help.dtos;
using training.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace training.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public StudentCourseController(IMapper mapper, DemoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/<StudentCourse>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentCourses = await _context.StudentsCourses.ToListAsync();
  
                return Ok(_mapper.Map<List<StudentCourseDto>>(studentCourses));

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = " an error happened while getting all courses studends are enrolled in" });
            }
        }

        // GET api/<StudentCourse>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var studentCourse = await _context.StudentsCourses.SingleOrDefaultAsync(sc => sc.Id == id);
                //var student = _students.SingleOrDefault(st => st.Id == id);
                if (studentCourse == null)
                    return NotFound(new { Error = " student Course with the given id does not exist" });
                var studentDto = _mapper.Map<StudentCourseDto>(studentCourse);
                return Ok(studentDto);
            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " student Course with the given id does not exist" });
            }
        }

        // POST api/<StudentCourse>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCourse studentCourse)
        {
            try
            {
                await _context.StudentsCourses.AddAsync(studentCourse);
                await _context.SaveChangesAsync();
                var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
                return Ok(studentCourseDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while Adding  student to the course " });
            }
        }

        // PUT api/<StudentCourse>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentCourse studentCourse)
        {
            try
            {
                var LocalstudentCourse = await _context.StudentsCourses.SingleOrDefaultAsync(sc => sc.Id == id);
                _context.Remove(LocalstudentCourse);
                await _context.StudentsCourses.AddAsync(studentCourse);
                await _context.SaveChangesAsync();

                var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
                return Ok(studentCourseDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " an error occured while Updating student with id=" + id });
            }
        }

        // DELETE api/<StudentCourse>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var studentCourse = await _context.StudentsCourses.SingleOrDefaultAsync(sc => sc.Id == id);
                _context.Remove(studentCourse);
                await _context.SaveChangesAsync();


                var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
                return Ok(studentCourseDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while deleting student from course" });
            }

        }
    }
}
