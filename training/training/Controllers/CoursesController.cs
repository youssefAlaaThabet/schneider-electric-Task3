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
    public class CoursesController : ControllerBase  
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;
        public CoursesController(IMapper mapper, DemoContext context)
    {
        _mapper = mapper;
        _context = context;

    }
        // GET: api/<Courses>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();
                return Ok(_mapper.Map<List<CourseDto>>(courses));
                

            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = " an error happened while getting all Courses" });
            }
        }

        // GET api/<Courses>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var courses = await _context.Courses.SingleOrDefaultAsync(co => co.Id == id);
                var coursesDto = _mapper.Map<CourseDto>(courses);
                return Ok(coursesDto);
                

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while getting Course with id="+id });
            }
        }

        // POST api/<Courses>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                var coursesDto = _mapper.Map<CourseDto>(course);
                return Ok(coursesDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while Adding the Course "});
            }
        }

    

        // PUT api/<Courses>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
        try
        {
                var courses = await _context.Courses.SingleOrDefaultAsync(co => co.Id == id);
                _context.Remove(courses);
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                var coursesDto = _mapper.Map<CourseDto>(course);
                return Ok(coursesDto);

            }
        catch (Exception)
        {
            return StatusCode(400, new { Error = " an error occured while Updating Course with id=" + id });
        }
    }

        // DELETE api/<Courses>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var courses = await _context.Courses.SingleOrDefaultAsync(co => co.Id == id);
                _context.Remove(courses);
                await _context.SaveChangesAsync();

                var coursesDto = _mapper.Map<CourseDto>(courses);
                return Ok(coursesDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " an error occured while deleting Course with id=" + id });
            }
        }
    }
}
