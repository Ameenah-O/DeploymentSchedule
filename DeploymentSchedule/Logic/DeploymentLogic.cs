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
        public List<Deployment> GetAll()
        {
            var deployments = _data.GetAll();
            //var deploymentinJson = JsonConvert.SerializeObject(deployments);
            return deployments.ToList();
        }
        public Deployment GetByName(string name)
        {
            var deployments = _data.GetAll();
            var deployment = deployments.Where(x => x.Name == name).SingleOrDefault();
            return deployment;
        }
        public Deployment GetByNameAndStatus(string name, string status)
        {
            var deployments = _data.GetAll();
            var deployment = deployments.Where(x => x.Name == name && x.Status == status).SingleOrDefault();
            return deployment;
        }
        public List<Deployment> GetByStatus(string name, string status)
        {
            var deployments = _data.GetAll();
            deployments = deployments.Where(x => x.Status == status).ToList();
            return deployments?.ToList();
        }
        public bool Create(Deployment deployment)
        {
            //var deployment = JsonConvert.DeserializeObject<Deployment>(deploymentinJson);
            if (IsNameUnique(deployment.Name))
            {
               return _data.Add(deployment);
            }
            return false;
        }
        public void Delete(string name)
        {
            var deployment = GetByName(name);
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
        public bool Update(Deployment deployment, string name)
        {
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