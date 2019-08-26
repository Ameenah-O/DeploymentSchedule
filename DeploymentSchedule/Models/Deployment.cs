using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeploymentSchedule.Models
{
    public class Deployment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduleTime { get; set; }
        public string Status { get; set; }
        public string IssuesEncoutered { get; set; }
        public string Description { get; set; }
        public string DeploymentDuration { get; set; }
    }
}