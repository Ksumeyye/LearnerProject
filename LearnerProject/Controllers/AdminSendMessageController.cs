using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminSendMessageController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
        public ActionResult IsNotRead(int id) 
        {
            var item = context.Messages.Find(id);
            item.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsRead(int id) 
        {
            var item = context.Messages.Find(id);
            item.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSendMessage(int id) 
        {
        var value=context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}