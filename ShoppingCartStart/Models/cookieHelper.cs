using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartStart.Models
{
	public class cookieHelper
	{
		public static List<Product> GetProducts()
		{  

			List<Product> prods = new List<Product>();
			HttpCookie cartCookie = HttpContext.Current.Request.Cookies["cart"];
			if (cartCookie == null)
				return prods;
            return JsonConvert.DeserializeObject<List<Product>>(cartCookie.Value);
			 
		}

		public static void AddProduct(Product p, List<Product> GetProducts, short qty)
		{
			List<Product> products = GetProducts;
			
			products.Add(p);

			string jsonData = JsonConvert.SerializeObject(products);
			HttpCookie cookie = new HttpCookie("cart");
			cookie.Value = jsonData;
			cookie.Expires = DateTime.Now.AddYears(5);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}    
	}
}