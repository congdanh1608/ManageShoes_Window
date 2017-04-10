using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes
{
    public class BuyProduct
    {
        public Product product;
        public int quatity;

        public BuyProduct()
        {
        }

        public BuyProduct(Product _product, int _quantity)
        {
            this.product = _product;
            this.quatity = _quantity;
        }

        public Product getProduct()
        {
            return product;
        }

        public int getQuantity()
        {
            return quatity;
        }

        public void setProduct(Product p)
        {
            this.product = p;
        }

        public void setQuantity(int q)
        {
            this.quatity = q;
        }
    }
}
