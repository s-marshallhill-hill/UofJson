using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics;
using u_of_json_api.Models;

namespace u_of_json_api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SchoolContext _schoolContext;

        public ValuesController(SchoolContext context)
        {
            _schoolContext = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Models.Student> Get()
        {
            IEnumerable<Models.Student> students;

            students = _schoolContext.Students.Include(s => s.Rosters).ToList();
            //students =  schoolContext.Students.AsNoTracking().ToList();
            foreach (Student student in students)
            {
                Debug.WriteLine(student.ToString());
                if (student.Rosters != null)
                {
                    Debug.WriteLine(student.Rosters);
                }
            }
            return students;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
