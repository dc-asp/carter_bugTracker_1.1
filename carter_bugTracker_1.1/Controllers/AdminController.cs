using carter_bugTracker_1._1.Models;
using carter_bugTracker_1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carter_bugTracker_1._1.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserRolesHelper roleHelper = new UserRolesHelper();
        // GET: Admin
        public ActionResult UserIndex()
        {
            var users = db.Users.Select(u => new UserProfileViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DisplayName = u.DisplayName,
                AvatarUrl = u.AvatarUrl,
                Email = u.Email
            }).ToList();

            return View(users);
        }

        public ActionResult ManageUserRole(string userId)
        {
            //How do I load up a DropDownList with Role Information??
            //new SelectList("The list of data pushed into the control", 
            //               "The column that will be used to communicate my selection(s) to the post", 
            //               "The column that we show the user inside the control", 
            //               "If they already occupy a role...show this instead of nothing")
            ViewBag.UserId = userId;
            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageuserRole(string userId, string userRole)
        {
            foreach(var role in roleHelper.ListUserRoles(userId))
            {
                roleHelper.RemoveUserfromRole(userId, role);
            }

            if(! string.IsNullOrEmpty(userRole))
            {
                roleHelper.AddUserToRole(userId, userRole);
            }

            return View();
        }
        public ActionResult ManageUserProjects()
        {
            return View();
        }
        public ActionResult ManageProjects()
        {
            return View();
        }
        public ActionResult ManageUsers()
        {
            return View();
        }
    }
}