using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            string studentName = Session["studentName"].ToString();
            var student = context.Students.Where(x => x.NameSurname == studentName).Select(x=>x.StudentId).FirstOrDefault();
            var values = context.CourseRegisters.Where(x => x.StudentId ==student ).ToList();
            return View(values);
        }
        public ActionResult MyCourseList(int id)
        {
            var values = context.CourseVideos.Where(x=>x.CourseId==id).ToList();
            return View(values);
        }
    }
}