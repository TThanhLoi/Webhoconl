using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webhoconl.Models;

namespace Webhoconl.Controllers
{
    public class CartController : Controller
    {
        onllearningwebEntities1 ctx = new onllearningwebEntities1();
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.yourSessionId = HttpContext.Session.SessionID;

            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();
                

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }


            // cal total of your cart

            float total = 0;

            foreach (ItemCart it in cart)
            {

                total += it.LineTotal;
            }

            ViewBag.Total = total;
            //passing to View
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart()
        {


            //step 1
            List<ItemCart> cart = null;
            if (HttpContext.Session["yourcart"] == null)
            {
                cart = new List<ItemCart>();
                Session["Count"] = 1;

            }
            else
            {
                cart = (List<ItemCart>)HttpContext.Session["yourcart"];
            }


            
           
            int Subject_ID = Convert.ToInt32(Request.Form["Subject_ID"]);

            //ItemCart 
            Subject subject = ctx.Subjects.Where(t => t.Subject_ID == Subject_ID).SingleOrDefault();
            int qty = 1; //Convert.ToInt32(Request.Form["txtQuantity"]);

            ItemCart item = new ItemCart()
            {

                subject = subject,
                Quantity = qty,
                LineTotal = (float)(qty * subject.Price_discount)

            };
            //step 2
            cart.Add(item);
            //step 3

            HttpContext.Session["yourcart"] = cart;

            return RedirectToAction("Index");
        }

        


    }
}
