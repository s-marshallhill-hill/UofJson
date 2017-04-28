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
    public class GradesController : Controller
    {
        private readonly SchoolContext _schoolContext;

        public GradesController(SchoolContext context)
        {
            _schoolContext = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Grade> Get()
        {
             return _schoolContext.Grades.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Grade Get(int id)
        {
          
               return _schoolContext.Grades.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object gradeData)
        {
            try
            {
                Grade grade = JsonConvert.DeserializeObject<Grade>(gradeData.ToString());
                    _schoolContext.Grades.Add(grade);
                    _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Grade grade)
        {
            try
            {
                    _schoolContext.Grades.Update(grade);
                    _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                    var grade = _schoolContext.Grades.Find(id);
                    _schoolContext.Entry(grade).State = EntityState.Deleted;
                    _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
