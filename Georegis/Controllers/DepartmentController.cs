using AutoMapper;
using Context;
using Entities;
using Georegis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Georegis.Controllers
{


    public class DepartmentController : Controller
    {

        NpgsqlContext dbContext = new NpgsqlContext();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deps()
        {
            var deps = from d in dbContext.Departments
                       select d;
            return View(deps.ToList());
        }

        public ActionResult RegNewDep()
        {
            var depModel = new DepartmentViewModel();
            var depList = new List<SelectListItem>();
            var users = GetUsers();
            foreach (var user in users)
            {
                depList.Add(new SelectListItem() { Text = user.FullName, Value = user.Id.ToString() });
            }
            depModel.UsersList = depList;
            return View(depModel);
        }

        [HttpPost]
        public void SaveDep(DepartmentViewModel model)
        {
            var user = dbContext.Users.Find(model.ManagedBy);
            var dep = dbContext.Departments.Create();
            dep.Title = model.Title;
            dep.Description = model.Description;
            dep.DepartmentCode = model.DepartmentCode;
            dep.UserGroupManager = user;
            dbContext.Departments.Add(dep);
            dbContext.SaveChanges();
        }

        private List<User> GetUsers()
        {
            var users = from u in dbContext.Users
                        select u;
            return users.ToList();
        }
    }
}