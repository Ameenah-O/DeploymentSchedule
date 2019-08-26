using DeploymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeploymentSchedule.Data
{
    public class DeploymentData
    {
        private readonly DbContext _context = new DbContext();

        public DbSet<Deployment> DbSet { get; set; }
        public DeploymentData()
        {
            DbSet = _context.Set<Deployment>();
        }

        public bool Add(Deployment Item)
        {
            try
            {
                DbSet.Add(Item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Update(Deployment Item)
        {
            try
            {
                using (var context = new DbContext())
                {
                    _context.Entry(Item).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IList<Deployment> GetAll()
        {
            using (var context = new DbContext())
            {
                return DbSet.ToList();

            }

        }

        public Deployment Find(int id)
        {
            return DbSet.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(Deployment deployment)
        {
            _context.Deployments.Attach(deployment);
            _context.Entry(deployment).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}