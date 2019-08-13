using carter_bugTracker_1._1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace carter_bugTracker_1._1.Helpers
{
    public class UserProjectsHelper
    {
        private UserManager<ApplicationUser>manager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool IsOnProject(string userId, int projectId)
        {
            if(db.Projects.Find(projectId).User.Contains(db.Users.Find(userId)))
            {
                return true;
            }
            return false;
        }
        public void AddUserToProject(string userId, int projectId)
        {
            if(!IsOnProject(userId, projectId))
            {
                var project = db.Projects.Find(projectId);
                project.User.Add(db.Users.Find(userId));
                db.Entry(project).State = EntityState.Modified;//just saves this obj instance
                db.SaveChanges();
            }
        }
        public void RemoveUserFromProject(string userId, int projectId)
        {
            if(IsOnProject(userId, projectId))
            {
                var project = db.Projects.Find(projectId);
                project.User.Remove(db.Users.Find(userId));
                db.Entry(project).State = EntityState.Modified;//just saves this obj instance
                db.SaveChanges();

            }
        }
        public ICollection<ApplicationUser>ListUsersOnProject(int projectId)
        {
            return db.Projects.Find(projectId).User;
        }
        public ICollection<Project>ListProjectsForUser(string userId)
        {
            return db.Users.Find(userId).Projects;
        }
        public ICollection<ApplicationUser>ListUsersNotOnProject(int projectId)
        {
            return db.Users.Where(u => u.Projects.All(p => p.Id != projectId)).ToList();
        }
    }
}