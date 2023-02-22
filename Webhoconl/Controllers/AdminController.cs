using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webhoconl.Models;
using PagedList;

namespace Webhoconl.Controllers
{
    public class AdminController : Controller
    {
        
        onllearningwebEntities1 ctx = new onllearningwebEntities1();
        public ActionResult ListSubject(int? page)
        {
            if (page == null) page = 1;
            var links = (from l in ctx.Subjects
                         select l).OrderBy(x => x.Subject_ID);

            int pageSize = 9;
            return View(links.ToPagedList((int)page, pageSize));
        }
        public ActionResult Search(string SearchString)
        {
            //1.db --> subjects
            var lstproduct = ctx.Subjects.Where(n => n.Name.Contains(SearchString)).ToList();

            //2.passing data to view

            return View(lstproduct);
        }
        public ActionResult SubjectDetail(int id)

        {//select *from subjects where
            Subject sjs = ctx.Subjects.Where(t => t.Subject_ID == id).SingleOrDefault();
            ViewBag.SubjectID = id;
            //passing data model to view
            return View(sjs);
        }
        public ActionResult DeleteSubject(int id)

        {
            Subject sjs = ctx.Subjects.Where(t => t.Subject_ID == id).SingleOrDefault();
            //xoa
            ctx.Subjects.Remove(sjs);
            ctx.SaveChanges();

            //redirect view
            return RedirectToAction("ListSubject");
        }
        // GET: Admin
        public ActionResult AddSubject()
        {
            Subject subject = new Subject();
            List<Category> categories = ctx.Categories.ToList();
            ViewBag.categories = categories;

            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Subject subject)
        {

            ctx.Subjects.Add(subject);
            ctx.SaveChanges();
            return RedirectToAction("ListSubject");

        }
        [HttpGet]
        public ActionResult EditSubjects(int id)
        {
            List<Category> categories = ctx.Categories.ToList();
            ViewBag.categories = categories;



            Subject subject = ctx.Subjects.Where(t => t.Subject_ID == id).SingleOrDefault();
            ViewBag.subject = id;


            return View(subject);
        }
        [HttpPost]
        public ActionResult UpdateSubjects(Subject subject)
        {
            //search old entity
            Subject oldsubject = ctx.Subjects.Where(t => t.Subject_ID == subject.Subject_ID).SingleOrDefault();
            //update
            oldsubject.Name = subject.Name;
            oldsubject.Lecturer = subject.Lecturer;
            oldsubject.Img = subject.Img;
            oldsubject.Price = subject.Price;
            oldsubject.Price_discount = subject.Price_discount;
            oldsubject.Category = subject.Category;
            oldsubject.Description = subject.Description;

            ctx.SaveChanges();

            return RedirectToAction("ListSubject");
        }
        public ActionResult Index()
        {
            return View();
        }
       
    }
}