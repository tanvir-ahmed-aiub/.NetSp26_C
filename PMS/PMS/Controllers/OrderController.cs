using PMS.Auth;
using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Logged]
    public class OrderController : Controller
    {
        PMS_Fall25_CEntities db = new PMS_Fall25_CEntities();
        // GET: Order
        public ActionResult AddtoCart(int id)
        {
            var pd = db.Products.Find(id);
            var mapper = DashboardController.GetMapper();
            var p = mapper.Map<ProductDTO>(pd);
            List<ProductDTO> cart = null;
            if (Session["Cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else {
                cart =(List<ProductDTO>) Session["Cart"];
            }
            p.Qty = 1;
            cart.Add(p);
            Session["Cart"] = cart; //boxing
            return RedirectToAction("MakeOrder","Dashboard");
        }
        public ActionResult ShowCart() {
            var cart = Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("MakeOrder", "Dashboard");
            }
            else {
                var data = (List<ProductDTO>)Session["Cart"];
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Place(decimal Total) {
            var customer =(Customer) Session["Logged"];

            var order = new Order() { 
                Amount = Total,
                Status = "Ordered",
                CusId = customer.Id,
                Date = DateTime.Now
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var cart = (List<ProductDTO>)Session["Cart"];
            foreach (var item in cart)
            {
                var od = new OrderDetail() { 
                    PId = item.Id,
                    OId = order.Id,
                    Price = item.Price,
                    Qty = item.Qty
                };
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            TempData["Msg"] = "Order Placed";
            return RedirectToAction("Customer","Dashboard");
        }
    }
}