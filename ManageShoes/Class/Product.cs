using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes
{
    public class Product
    {
        public String pID { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public String size { get; set; }
        public String price { get; set; }
        public String quantity { get; set; }
        public String note { get; set; }
        public String image { get; set; } 

        public Product()
        {

        }

        public Product(String pID, String name, String desc, String size, String price, String quantity, String note, String image)
        {
            this.pID = pID;
            this.name = name;
            this.desc = desc;
            this.size = size;
            this.price = price;
            this.quantity = quantity;
            this.note = note;
            this.image = image;
        }

        public String getpID()
        {
            return pID;
        }

        public void setpID(String pID)
        {
            this.pID = pID;
        }

        public String getDesc()
        {
            return desc;
        }

        public void setDesc(String desc)
        {
            this.desc = desc;
        }

        public String getImage()
        {
            return image;
        }

        public void setImage(String image)
        {
            this.image = image;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getNote()
        {
            return note;
        }

        public void setNote(String note)
        {
            this.note = note;
        }

        public String getPrice()
        {
            return price;
        }

        public void setPrice(String price)
        {
            this.price = price;
        }

        public String getQuantity()
        {
            return quantity;
        }

        public void setQuantity(String quantity)
        {
            this.quantity = quantity;
        }

        public String getSize()
        {
            return size;
        }

        public void setSize(String size)
        {
            this.size = size;
        }
    }
}
