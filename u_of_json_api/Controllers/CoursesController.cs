using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using u_of_json_api.Models;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace u_of_json_api.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {

        private readonly SchoolContext _schoolContext;

        public CoursesController(SchoolContext context)
        {
            _schoolContext = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Course> Get()
        {

            var courses = _schoolContext.Courses
                .Include(c => c.Rosters).ThenInclude(r => r.Student)
                .Include(c => c.Rosters).ThenInclude(r => r.Grade)
                .ToList();
            return courses;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            Course course = _schoolContext.Courses.Find(id);

            return course;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Course course)
        {
            try
            {
                _schoolContext.Courses.Add(course);
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Course course)
        {
            _schoolContext.ChangeTracker.TrackGraph(course, e => e.Entry.State = EntityState.Modified);
            _schoolContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var course = _schoolContext.Courses.Find(id);
                _schoolContext.Entry(course).State = EntityState.Deleted;
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
