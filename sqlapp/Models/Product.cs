using System;

namespace sqlapp.Models
{
    public class Product
    {
        public string product_name {  get; set; }
        public string category { get; set;}
        public decimal price { get; set; }
        public int stock_quantity { get; set; }
    }
}
