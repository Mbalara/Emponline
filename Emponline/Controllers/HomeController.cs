using Emponline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emponline.Controllers
{
    public class HomeController : Controller
    {
        TextEntities _context = new TextEntities();
        public ActionResult Index()
        {
            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student Model)
        {
            var data = _context.Students.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}