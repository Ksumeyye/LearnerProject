using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TeacherCourseController : Controller
    {
        // GET: TeacherCourse
        LearnerContext context = new LearnerContext();

        public ActionResult Index()
        {
            string name = Session["teacherName"].ToString();
            var values = context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();
            return View(values);
        }

        public ActionResult DeleteCourse(int id)
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            string name = Session["teacherName"].ToString();  //Loginle giriş yapıyoruz,giriş yaptıktan sonra cookiye yani sessione bir teacher name ataması yapıyoruz. Giriş yapmış olduğumuz süre boyunca session da bir değer tutuyor. Eğitmen olarak giriş yaptığımız için yeni kurs eklerken view tarafında eğitmeni seçmemize gerek kalmıyor. Bu yuzden teacher ıd parametresine atama yapıyoruz. Teacher tabosunda eğitmenin id sini seçip bu kısma atıyoruz. Böylelikle teacher id seçimi controller tarafında yapılır.
            course.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}