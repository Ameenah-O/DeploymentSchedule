using DeploymentSchedule.Data;
using DeploymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DeploymentSchedule.Logic
{
    public class DeploymentLogic
    {
        DeploymentData _data;
        public DeploymentLogic()
        {
            _data = new DeploymentData();
        }
        public string GetAll()
        {
            var deployments = _data.GetAll();
            var deploymentinJson = JsonConvert.SerializeObject(deployments);
            return deploymentinJson;
        }
        public string GetByName(string name)
        {
            var deployments = _data.GetAll();
            var deployment = deployments.Where(x => x.Name == name).SingleOrDefault();
            if (deployment!=null)
            {
                var deploymentinJson = JsonConvert.SerializeObject(deployment);
                return deploymentinJson;
            }
            else
            {
                return null;
            }
        }
        public string GetByNameAndStatus(string name, string status)
        {
            var deployments = _data.GetAll();
            var deployment = deployments.Where(x => x.Name == name && x.Status == status).SingleOrDefault();
            if (deployment != null)
            {
                var deploymentinJson = JsonConvert.SerializeObject(deployment);
                return deploymentinJson;
            }
            else
            {
                return null;
            }
        }
        public string GetByStatus(string name, string status)
        {
            var deployments = _data.GetAll();
            deployments = deployments.Where(x => x.Status == status).ToList();
            if (deployments.Count != 0)
            {
                var deploymentinJson = JsonConvert.SerializeObject(deployments);
                return deploymentinJson;
            }
            else
            {
                return null;
            }
        }
        public bool Create(string deploymentinJson)
        {
            var deployment = JsonConvert.DeserializeObject<Deployment>(deploymentinJson);
            if (IsNameUnique(deployment.Name))
            {
               return _data.Add(deployment);
            }
            return false;
        }
        public void Delete(string deploymentinJson)
        {
            var deployment = JsonConvert.DeserializeObject<Deployment>(deploymentinJson);
            _data.Delete(deployment);
        }
        public bool IsNameUnique(string name)
        {
            var deployments = _data.GetAll();
            var nameexists = deployments.Where(x => x.Name == name).Any();
            if (nameexists)
            {
                return false;
            }
            else return true;
        }
        public bool Update(string deploymentinJson, string name)
        {
            var deployment = JsonConvert.DeserializeObject<Deployment>(deploymentinJson);
            if (deployment.Name==null)
            {
                return false;
            }
            var deployments = _data.GetAll();
            var deploymentItem = deployments.Where(x => x.Name == deployment.Name).SingleOrDefault();
            //convert JSON deployment string to Deployment object
            if (deploymentItem != null)
            {
                //Update the values that have data
                if (deployment.DeploymentDuration != null) deploymentItem.DeploymentDuration = deployment.DeploymentDuration;
                if (deployment.Description != null) deploymentItem.Description = deployment.Description;
                if (deployment.IssuesEncoutered != null) deploymentItem.IssuesEncoutered = deployment.IssuesEncoutered;
                if (deployment.ScheduleTime != null) deploymentItem.ScheduleTime = deployment.ScheduleTime;
                if (deployment.Status != null) deploymentItem.Status = deployment.Status;
                return _data.Update(deploymentItem);
            }
            else
            {
                return false;
            }
        }
    }
}