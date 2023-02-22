using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webhoconl.Models;

namespace Webhoconl.Controllers
{
    public class PaymentController : Controller
    {
        onllearningwebEntities1 ctx = new onllearningwebEntities1();
        // GET: Payment
        
        public ActionResult Index(Oder oder,OderDetail oderDetail)
        {
            
            if (Session["idUser"]== null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //lay thong tin gio hang tu bien session
                var lstcart = (List<ItemCart>)Session["yourcart"];
                //gan du lieu cho oder
                Oder objoder = new Oder();
                
                objoder.name = "DonHang-" + DateTime.Now.ToString("yyyyMMddmmss");
                objoder.UserID=int.Parse(Session["idUser"].ToString());
                objoder.Oder_Date = DateTime.Now;
                 
               
                ctx.Oders.Add(objoder);

                //luu thong tin vao bang oder
                ctx.SaveChanges();
                //lay oderid vua tao luu vao bang oderdetail.
                int intoderid = objoder.Oder_ID;

                List<OderDetail> lstoderdetails = new List<OderDetail>();

                foreach(var item in lstcart)
                {
                    OderDetail obj = new OderDetail();
                    obj.Oder_detail_ID = intoderid;
                   // obj.Quantily = item.Quantity;
                    obj.Subject_ID = item.subject.Subject_ID;
                    obj.Line_Total = item.LineTotal;
                    obj.Price = item.subject.Price_discount;
                    lstoderdetails.Add(obj);
                }
                ctx.OderDetails.AddRange(lstoderdetails);
                ctx.SaveChanges();


            }
            return View();
        }
        
    }
}