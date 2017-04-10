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
    public partial class Cart : Form
    {
        public MainForm mainForm;
        Product product = null;

        public Cart(MainForm mainForm, Product product)
        {
            this.mainForm = mainForm;
            this.product = product;

            InitializeComponent();
            this.CenterToScreen();

            setDataFirst();
        }

        private void setDataFirst()
        {
            if (product != null)
            {
                tbID.Text = product.getpID();
                tbName.Text = product.getName();
                tbQuality.Text = product.getQuantity();
                tbPrice.Text = product.getPrice();
                tbNote.Text = product.getNote();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkError())
            {
                //Put value to Orders form (parent form)
                mainForm.SendBuyProductToParent(product);
                this.Close();
            }
            else
            {
                MessageBox.Show("Giá và số lượng không được để trống!");
            }
        }

        private bool checkError()
        {
            bool result = true;
            if (string.IsNullOrEmpty(tbQuality.Text) || Int32.Parse(tbQuality.Text) == 0)
                result = false;
            else product.setQuantity(tbQuality.Text);
            if (string.IsNullOrEmpty(tbPrice.Text) || Int32.Parse(tbPrice.Text) == 0)
                result = false;
            else product.setPrice(tbPrice.Text);
            if (!string.IsNullOrEmpty(tbNote.Text)) product.setNote(tbNote.Text);
            return result;
        }
    }
}
