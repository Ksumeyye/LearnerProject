using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace LearnerProject.Controllers
{
    public class CourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Courses.Count();
            return View();
        }
        public PartialViewResult CourseInformation()
        {
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).ToList();
            return PartialView(values);
        }
    }
}