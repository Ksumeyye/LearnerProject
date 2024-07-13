using LearnerProject.Models;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
        public ActionResult MakeActive(int id)
        {
            var item = context.SocialMedias.Find(id);
            item.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id) 
        {
            var item= context.SocialMedias.Find(id);
            item.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value=context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia socialmedia)
        {
            socialmedia.Status= true;
            context.SocialMedias.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            var value = context.SocialMedias.Find(socialmedia.SocialMediaId);
            value.SocialMediaName = socialmedia.SocialMediaName;
            value.SocialMediaUrl = socialmedia.SocialMediaUrl;
            value.Icon = socialmedia.Icon;
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}