using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
        LearnerContext context=new LearnerContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CourseRegister courseRegister) 
        {
            return View();
        }
    }
}