using DeploymentSchedule.Logic;
using DeploymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DeploymentSchedule.Controllers
{
    public class DeploymentsController : ApiController
    {
        DeploymentLogic _logic;
        public DeploymentsController()
        {
            _logic = new DeploymentLogic();
        }
        // GET api/<controller>
        public List<Deployment> Get()
        {
            var result = _logic.GetAll();
            return result;
        }

        // POST api/<controller>
        public void Post([FromBody]Deployment value)
        {
            var context = HttpContext.Current;
            var result = _logic.Create(value);
        }

        // GET api/<controller>/name
        public Deployment Get(string name)
        {
            var result = _logic.GetByName(name);
            return result;
        }

        // PUT api/<controller>/name
        public void Put(string name, [FromBody]Deployment deployment)
        {
            var result = _logic.Update(deployment, name);
        }

        // DELETE api/<controller>/name
        public void Delete(string name)
        {
            _logic.Delete(name);
        }

        // GET api/<controller>/name&status
        public Deployment Get(string name, string status)
        {
            var result = _logic.GetByNameAndStatus(name, status);
            return result;
        }
    }
}