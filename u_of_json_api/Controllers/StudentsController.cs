using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using u_of_json_api.Models;
using u_of_json_api.Models.Transformer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace u_of_json_api.Controllers
{

    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly SchoolContext _schoolContext;

        public StudentsController(SchoolContext context)
        {
            _schoolContext = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {

            var students = _schoolContext.Students
                 //.Include(s => s.Rosters).ThenInclude(r => r.Course)
                 //.Include(s => s.Rosters).ThenInclude(r => r.Grade)
                 .ToList();

            //           IEnumerable<StudentTransformer> studentsData = students.Select(s => new StudentTransformer(s));
            return students;
 //           return studentsData;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student student = null;
                student = _schoolContext.Students.Find(id);

            return student;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Student student)
        {
            _schoolContext.ChangeTracker.TrackGraph(student, e => e.Entry.State = EntityState.Modified);
            _schoolContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _schoolContext.Students.Find(id);
            _schoolContext.Entry(student).State = EntityState.Deleted;
            _schoolContext.SaveChanges();
        }
    }
}
