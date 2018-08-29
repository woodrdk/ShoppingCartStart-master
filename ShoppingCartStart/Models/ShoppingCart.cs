using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartStart.Models
{
	public static class ShoppingCart
	{
		public static List<Product> CreateEmptyShoppingCartList()
		{
			List<Product> products = new List<Product>();
			return products;
		}

		public static bool IsCartEmpty(List<Product> products)
		{
			if (products == null)
				return true;
			return false;
		}

		public static List<Product> GetProducts()
		{
			List<Product> products = new List<Product>();
			HttpCookie cartCookie = HttpContext.Current.Request.Cookies["cart"];
			if(cartCookie == null)
			{
				return products;
			}
			else
			{
                return JsonConvert.DeserializeObject<List<Product>>(cartCookie.Value);
			}
		}

		public static int GetCartQuanity()
        {
            List<Product> products = GetProducts();
            int quanity = 0;
            foreach(Product p in products)
            {
                quanity += p.Quantity;
            }
            return quanity;
        }
	}
}