using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes
{
    public class Order
    {
        public String oID { get; set; }
        public String buyer { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String date { get; set; }
        public String products { get; set; }
        public String totalprice { get; set; }
        public String discount { get; set; }
        public String note { get; set; }

        public Order()
        {

        }

        public Order(String oID, String buyer, String address, String phone, String date, String products, String totalprice, String discount, String note)
        {
            this.oID = oID;
            this.buyer = buyer;
            this.address = address;
            this.phone = phone;
            this.date = date;
            this.products = products;
            this.totalprice = totalprice;
            this.discount = discount;
            this.note = note;
        }

        public String getNote()
        {
            return note;
        }

        public String getAddress()
        {
            return address;
        }

        public String getBuyer()
        {
            return buyer;
        }

        public String getDate()
        {
            return date;
        }

        public String getDiscount()
        {
            return discount;
        }

        public String getoID()
        {
            return oID;
        }

        public String getPhone()
        {
            return phone;
        }

        public String getProducts()
        {
            return products;
        }

        public String getTotalprice()
        {
            return totalprice;
        }

        public void setNote(String note)
        {
            this.note = note;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }

        public void setBuyer(String buyer)
        {
            this.buyer = buyer;
        }

        public void setDate(String date)
        {
            this.date = date;
        }

        public void setDiscount(String discount)
        {
            this.discount = discount;
        }

        public void setoID(String oID)
        {
            this.oID = oID;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public void setProducts(String products)
        {
            this.products = products;
        }

        public void setTotalprice(String totalprice)
        {
            this.totalprice = totalprice;
        }
    }
}
