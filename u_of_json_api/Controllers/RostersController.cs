using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using u_of_json_api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using u_of_json_api.Models.Transformer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace u_of_json_api.Controllers
{
    [Route("api/[controller]")]
    public class RostersController : Controller
    {

        private readonly SchoolContext _schoolContext;

        public RostersController(SchoolContext context)
        {
            _schoolContext = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<RosterTransformer> Get()
        {
            IEnumerable<RosterTransformer> rostersData;


            var rosters = _schoolContext.Rosters
                .Include(r => r.Course)
                .Include(r => r.Student)
                .Include(r => r.Grade)
                .ToList();
            rostersData = rosters.Select(r => new RosterTransformer(r));

            return rostersData;
        }

        [HttpGet]
        [Route("[action]/{studentId:int}")]
        public IEnumerable<RosterTransformer> FilterByStudent( int studentId)
        {
            IEnumerable<RosterTransformer> rostersData;
            var rosters = _schoolContext.Rosters
                .Include(r => r.Course)
                .Include(r => r.Student)
                .Include(r => r.Grade)
                .Where(r=> r.studentId == studentId)
                .ToList();
            rostersData = rosters.Select(r => new RosterTransformer(r));

            return rostersData;
        }

        [HttpGet]
        [Route("[action]/{courseId:int}")]
        public IEnumerable<RosterTransformer> FilterByCourse(int courseId)
        {
            IEnumerable<RosterTransformer> rostersData;
            var rosters = _schoolContext.Rosters
                .Include(r => r.Course)
                .Include(r => r.Student)
                .Include(r => r.Grade)
                .Where(r => r.courseId == courseId)
                .ToList();
            rostersData = rosters.Select(r => new RosterTransformer(r));

            return rostersData;
        }

        [HttpGet]
        [Route("[action]/{gradeId:int}")]
        public IEnumerable<RosterTransformer> FilterByGrade(int gradeId)
        {
            IEnumerable<RosterTransformer> rostersData;
            var rosters = _schoolContext.Rosters
                .Include(r => r.Course)
                .Include(r => r.Student)
                .Include(r => r.Grade)
                .Where(r => r.gradeId == gradeId)
                .ToList();
            rostersData = rosters.Select(r => new RosterTransformer(r));

            return rostersData;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Roster Get(int id)
        {
            Roster roster = null;
            roster = _schoolContext.Rosters.Find(id);

            return roster;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Roster roster)
        {
            try
            {
                _schoolContext.Rosters.Add(roster);
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Roster roster)
        {
            try
            {
                _schoolContext.Rosters.Update(roster);
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var roster = _schoolContext.Grades.Find(id);
                _schoolContext.Entry(roster).State = EntityState.Deleted;
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
