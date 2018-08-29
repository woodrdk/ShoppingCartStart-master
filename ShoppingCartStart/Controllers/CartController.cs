using ShoppingCartStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartStart.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Add() 
        {
            
            int prodID = Convert.ToInt32(Request.Form["product_id"]);
                        
            CartContext db = new CartContext();
            Product p = db.Products.Find(prodID);
                        
            short qty = Convert.ToInt16(Request.Form["qty"]);
            p.Quantity = qty;

			List<Product> products = cookieHelper.GetProducts();
			cookieHelper.AddProduct(p, products, qty);

            return RedirectToAction("Index", "Home");
        }
		public ActionResult ViewCart()
		{
			List<Product> cartProducts = ShoppingCart.GetProducts();
			return View(cartProducts);
		}
    }
}