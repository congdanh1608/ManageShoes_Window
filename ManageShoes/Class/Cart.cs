using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes.Class
{
    class Cart
    {
        public String pID { get; set; }
        public String name { get; set; }
        public String price { get; set; }
        public String quantity { get; set; }

        public Cart(String pID_, String name_, String price_, String quality_)
        {
            pID = pID_;
            name = name_;
            price = price_;
            quantity = quality_;
        }

        public Cart()
        {
        }
    }
}
