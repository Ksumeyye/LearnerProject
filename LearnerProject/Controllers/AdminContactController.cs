using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminContactController : Controller
    {
        LearnerContext context=new LearnerContext();
        public ActionResult Index()
        {
            var values=context.Contacts.ToList();
            return View(values);
        }
        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact) 
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id) 
        {
        var value=context.Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact) 
        {
        var value=context.Contacts.Find(contact.ContactId);
            value.Address=contact.Address;
            value.OpenHours = contact.OpenHours;
            value.Email = contact.Email;
            value.Phone = contact.Phone;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}