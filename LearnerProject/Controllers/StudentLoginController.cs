using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class StudentLoginController : Controller
    {
        LearnerContext context= new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.UserName == student.UserName && x.Password == student.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["studentName"] = values.NameSurname;
                return RedirectToAction("Index", "StudentCourse");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalıdır.");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}