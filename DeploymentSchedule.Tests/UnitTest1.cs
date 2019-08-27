using System;
using DeploymentSchedule.Logic;
using DeploymentSchedule.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeploymentSchedule.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //method to test Create and GetByName method
        [TestMethod]
        public void TestCreate()
        {
            var deployment = new Deployment
            {
                Name = "TestCreate",
                DeploymentDuration = "2 hours",
                Description = "Test Deployment",
                IssuesEncoutered = "None yet",
                ScheduleTime = new DateTime(2019, 9, 1),
                Status = "To Do"
            };
            var logic = new DeploymentLogic();
            logic.Create(deployment);
            Assert.IsNotNull(logic.GetByName(deployment.Name));
        }
        //Method to test update logic
        [TestMethod]
        public void TestUpdate()
        {
            var logic = new DeploymentLogic();
            var deployment = logic.GetByName("TestCreate");
            deployment.Description = "Update Test Deployment";
            logic.Update(deployment, "TestCreate");
            var updatedDeployment = logic.GetByName("TestCreate");
            Assert.Equals(deployment.Description, updatedDeployment.Description);
        }
        //Method to test delete logic
        [TestMethod]
        public void TestDelete()
        {
            var logic = new DeploymentLogic();
            logic.Delete("TestCreate");
            Assert.IsNull(logic.GetByName("TestCreate"));
        }
    }
}
