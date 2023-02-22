using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webhoconl.Models;


namespace Webhoconl.Controllers
{
    public class CategoryController : Controller
    {
        onllearningwebEntities1 ctx = new onllearningwebEntities1();

        // GET: Category
        public ActionResult Index()
        {
            var lstcate = ctx.Categories.ToList();
            return View(lstcate);
        }
        public ActionResult SubjectCategory(int Id)
        {
            var lts = ctx.Subjects.Where(n => n.Category_ID == Id).ToList();
            Category category = ctx.Categories.Where(n => n.Category_ID == Id).SingleOrDefault();
            ViewBag.Title = "Các Khóa" + category.Name;
            return View(lts);
        }
        public ActionResult SubjectDetail(int id)

        {//select *from Toys where
            Subject sjs = ctx.Subjects.Where(t => t.Subject_ID == id).SingleOrDefault();

            ViewBag.SubjectID = id;
            //passing data model to view
            return View(sjs);
        }
        
    }
}