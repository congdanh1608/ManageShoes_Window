using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    public partial class SelectProductsFrom : Form
    {
        List<BuyProduct> buyPros, newBuyPros;
        MainUtils mainUtils;
        public SelectProductsFrom(List<BuyProduct> buyPros)
        {
            mainUtils = new MainUtils();

            InitializeComponent();
            this.CenterToScreen();
            this.buyPros = buyPros;
            newBuyPros = new List<BuyProduct>();

            loadCheckListBox();
        }

        private void loadCheckListBox(){
            foreach (BuyProduct b in buyPros)
            {
                clbProducts.Items.Add(mainUtils.getName_ID_QuantityFromBuyProduct(b));
            }
        }

        private void loadNewCheckListBox()
        {
            for (int i = 0; i < clbProducts.Items.Count; i++)
            {
                if (clbProducts.GetItemChecked(i))
                {
                    newBuyPros.Add(mainUtils.getBuyProductFromName_ID_Quantity(clbProducts.Items[i].ToString()));
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            loadNewCheckListBox();

            //Put value to Orders form (parent form)
            OrdersForm ordFrm = (OrdersForm)this.Owner;
            ordFrm.SendBuyProductsToParent(newBuyPros);
            this.Close();
        }
    }
}
