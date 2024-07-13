using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminProfileController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            var values=context.Admins.ToList();
            return View(values);
        }
        public ActionResult DeleteProfile(int id) 
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProfile(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
        var value=context.Admins.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Admin admin)
        {
            var value=context.Admins.Find(admin.AdminId);
            value.NameSurname = admin.NameSurname;
            value.UserName = admin.UserName;
            value.Password = admin.Password;
            value.ImageUrl = admin.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}