using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCartStart.Models
{
    public class CartContext : DbContext
    {

        public CartContext() : base("name=CartContext")
        {
        }

        public System.Data.Entity.DbSet<ShoppingCartStart.Models.Product> Products { get; set; }
    }
}
