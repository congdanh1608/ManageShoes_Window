using iTextSharp.text;
using iTextSharp.text.pdf;
using ManageShoes.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    public partial class OrdersForm : Form
    {
        DBConnection db;
        DatabaseHelper DBhelper;
        MainUtils mainUtils;
       
        public MainForm mainForm;

        public static List<BuyProduct> buyProductsSelected = new List<BuyProduct>();
        private String IDItemCurrent;
        private int iIndex = 0;
        public static bool addNew = false;
        //private bool IDCheckAddNew = false;

        //AutoComplete add product
        List<String> listNameProAutoComplete = null;
        ListBox sugBox = null;

        public OrdersForm(MainForm mainForm, String value)
        {
            this.mainForm = mainForm;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_Closing);

            mainUtils = new MainUtils();
            DBhelper = new DatabaseHelper();

            if (value == null)
            {   // Nothings
            }
            else if (value.Equals("ADDNEW"))
            {
                addNew = true;
            }

            InitializeComponent();
            this.CenterToScreen();

            updateDataGridViewFirst();

            if (addNew)
            {
                eventAdd_Click();
            }
            else loadOrderDetail(IDItemCurrent);

            //AutoComple
            List<string> arrays = new List<string>();
            arrays.Add(ProductsTable.COLUMN_NAME);
            arrays.Add(ProductsTable.COLUMN_ID);
            listNameProAutoComplete = mainUtils.getListInfosOfAllProduct(arrays);
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(listNameProAutoComplete.ToArray());
            this.txtAddProduct.AutoCompleteCustomSource = autoCollection;
            this.txtAddProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtAddProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
           
        }

        private void OrderForm_Closing(object sender, FormClosingEventArgs e)
        {
            //mainForm.PerformRefresh_Orders();
        }

        private void updateDataGridViewFirst()
        {
            //Load database
            db = new DBConnection();
            db.Connect();
            db.LoadDataToTable(OrdersTable.OrdersTableName);
            dgvOrders.DataSource = db.Dt;

            //Update data
            dgvOrders.DataSource = convertListToDataTable(loadOrders());

            //Update current cell selected.
            if (!addNew)
            {
                dgvOrders.CurrentCell = dgvOrders[0, MainForm.ItemSelected];
                updateIDItemCurrent();
            }
        }

        private void updateDataGridView()
        {
            //Load database
            db = new DBConnection();
            db.Connect();
            db.LoadDataToTable(OrdersTable.OrdersTableName);
            dgvOrders.DataSource = db.Dt;

            //Update data
            dgvOrders.DataSource = convertListToDataTable(loadOrders());

            //Update current cell selected.
            dgvOrders.CurrentCell = dgvOrders[0, iIndex];
            //dgvProducts.CurrentCell = dgvProducts[0, iIndex];
            updateIDItemCurrent();
        }

        private List<Order> loadOrders()
        {
            List<Order> orders = new List<Order>();
            String strReq = "select * from " + OrdersTable.OrdersTableName;
            using (SqlCommand command = new SqlCommand(strReq, db.Cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.setoID(reader.GetString(0));
                        order.setBuyer(reader.IsDBNull(1) ? null : reader.GetString(1));
                        order.setAddress(reader.IsDBNull(2) ? null : reader.GetString(2));
                        order.setPhone(reader.IsDBNull(3) ? null : reader.GetString(3));
                        order.setDate(reader.IsDBNull(4) ? null : reader.GetString(4));
                        order.setProducts(reader.GetString(5));
                        order.setTotalprice(Convert.ToString(reader.GetInt32(6)));
                        order.setDiscount(reader.IsDBNull(7) ? null : Convert.ToString(reader.GetInt32(7)));
                        order.setNote(reader.IsDBNull(8) ? null : reader.GetString(8));

                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        private void loadOrderDetail(String ID)
        {
            Order order = new Order();
            String strReq = "select * from " + OrdersTable.OrdersTableName + " where " + OrdersTable.COLUMN_ID + "='" + ID + "'";
            using (SqlCommand command = new SqlCommand(strReq, db.Cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order.setoID(reader.GetString(0));
                        order.setBuyer(reader.IsDBNull(1) ? null : reader.GetString(1));
                        order.setAddress(reader.IsDBNull(2) ? null : reader.GetString(2));
                        order.setPhone(reader.IsDBNull(3) ? null : reader.GetString(3));
                        order.setDate(reader.IsDBNull(4) ? null : reader.GetString(4));
                        order.setProducts(reader.GetString(5));
                        order.setTotalprice(Convert.ToString(reader.GetInt32(6)));
                        order.setDiscount(reader.IsDBNull(7) ? null : Convert.ToString(reader.GetInt32(7)));
                        order.setNote(reader.IsDBNull(8) ? null : reader.GetString(8));
                    }
                }
            }

            //Add product to List Product Selected
            buyProductsSelected = mainUtils.getListProductFromString(order.getProducts());

            tbName.Text = order.getoID();
            tbQuality.Text = order.getBuyer();
            tvPrice.Text = order.getAddress();
            txtPhone.Text = order.getPhone();
            txtDate.Text = order.getDate();
            txtProducts.Text = mainUtils.getListName_ID_QuantityFromListBuyProducts(buyProductsSelected);
            txtTotalPrice.Text = order.getTotalprice();
            txtDiscount.Text = order.getDiscount();
            tbNote.Text = order.getNote();
        }

        private DataTable convertListToDataTable(List<Order> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add(OrdersTable.COLUMN_ID_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_BUYER_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_ADDRESS_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_PHONE_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_DATE_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_PRODUCTS_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_TOTALPRICE_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_DISCOUNT_NAME, typeof(string));
            table.Columns.Add(OrdersTable.COLUMN_NOTE_NAME, typeof(string));

            foreach (Order o in list)
            {
                table.Rows.Add(o.getoID(), o.getBuyer(), o.getAddress(), o.getPhone(),
                    o.getDate(), o.getProducts(), o.getTotalprice(), o.getDiscount(), o.getNote());
            }

            return table;
        }

        private void updateIDItemCurrent()
        {
            DataGridViewRow selectedRow = dgvOrders.Rows[dgvOrders.CurrentCell.RowIndex];
            iIndex = dgvOrders.CurrentCell.RowIndex;
            IDItemCurrent = Convert.ToString(selectedRow.Cells[0].Value);
        }

        public void AddNew()
        {
            tbName.Text = "";
            tbQuality.Text = "";
            tvPrice.Text = "";
            txtPhone.Text = "";
            txtDate.Text = MainUtils.getCurrentDate();
            txtProducts.Text = "";
            txtTotalPrice.Text = "";
            txtDiscount.Text = "0";
            tbNote.Text = "";

            addNew = true;
            tbName.Focus();
        }

        public void WriteData(DataTable dat)
        {
            DataRow newRow;
            if (addNew == true)
                newRow = dat.NewRow();
            else
                newRow = dat.Rows[iIndex];

            //Khởi tạo và gán dữ liệu
            newRow[OrdersTable.COLUMN_ID] = tbName.Text;
            newRow[OrdersTable.COLUMN_BUYER] = String.IsNullOrEmpty(tbQuality.Text) ? null : tbQuality.Text;
            newRow[OrdersTable.COLUMN_ADDRESS] = String.IsNullOrEmpty(tvPrice.Text) ? null : tvPrice.Text;
            newRow[OrdersTable.COLUMN_PHONE] = String.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text;
            newRow[OrdersTable.COLUMN_DATE] = String.IsNullOrEmpty(txtDate.Text) ? null : txtDate.Text;
            newRow[OrdersTable.COLUMN_PRODUCTS] = mainUtils.getStringFromListBuyProduct(buyProductsSelected);
            newRow[OrdersTable.COLUMN_TOTALPRICE] = Int32.Parse(txtTotalPrice.Text);
            newRow[OrdersTable.COLUMN_DISCOUNT] = String.IsNullOrEmpty(txtDiscount.Text) ? 0 : Int32.Parse(txtDiscount.Text);
            newRow[OrdersTable.COLUMN_NOTE] = String.IsNullOrEmpty(tbNote.Text) ? null : tbNote.Text;

            if (addNew == true)
            {
                dat.Rows.Add(newRow);
            }
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            db.Adt.Update(dat);
            if (addNew)
            {
                iIndex = dat.Rows.Count - 1;
            }
            dat.AcceptChanges();
            addNew = false;
        }

        bool CheckInfo()
        {
            if (tbName.Text == "" || txtTotalPrice.Text == "" || txtProducts.Text == "")
            {
                MessageBox.Show("Các thông tin bắt buộc bao gồm: Mã đơn hàng, tổng giá tiền và sản phẩm!");
                return false;
            }
            //else if (addNew && !IDCheckAddNew)
            //{
            //    MessageBox.Show("Mã đơn hàng bị trùng. Thử nhập mã khác.");
            //    return false;
            //}

            return true;
        }

        public void RemoveRecord(DataTable dat)
        {
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            dat.Rows[iIndex].Delete();
            db.Adt.Update(dat);
            dat.AcceptChanges();
        }

        private void eventMove()
        {
            updateIDItemCurrent();
            loadOrderDetail(IDItemCurrent);

            btnEdit.Enabled = true;
            btnRemove.Enabled = true;
            btnSave.Enabled = false;

            tbName.Enabled = false;
            tbQuality.Enabled = false;
            tvPrice.Enabled = false;
            txtPhone.Enabled = false;
            txtDate.Enabled = false;
            txtProducts.Enabled = false;
            txtTotalPrice.Enabled = false;
            txtDiscount.Enabled = false;
            tbNote.Enabled = false;
            txtAddProduct.Enabled = false;
            txtQuatityProduct.Enabled = false;
        }

        private void eventEdit_Click()
        {
            tbName.Enabled = true;
            tbQuality.Enabled = true;
            tvPrice.Enabled = true;
            txtPhone.Enabled = true;
            txtDate.Enabled = true;
            txtProducts.Enabled = true;
            txtTotalPrice.Enabled = true;
            txtDiscount.Enabled = true;
            tbNote.Enabled = true;
            txtAddProduct.Enabled = true;
            txtQuatityProduct.Enabled = true;

            addNew = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void eventAdd_Click()
        {
            buyProductsSelected.Clear();

            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            tbName.Enabled = true;
            tbQuality.Enabled = true;
            tvPrice.Enabled = true;
            txtPhone.Enabled = true;
            txtDate.Enabled = true;
            txtProducts.Enabled = true;
            txtTotalPrice.Enabled = true;
            txtDiscount.Enabled = true;
            tbNote.Enabled = true;
            txtAddProduct.Enabled = true;
            txtQuatityProduct.Enabled = true;

            AddNew();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eventMove();
        }

        private void dgvOrders_KeyUp(object sender, KeyEventArgs e)
        {
            eventMove();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            eventEdit_Click();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            eventAdd_Click();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == true)
            {
                WriteData(db.Dt);
                updateDataGridView();

                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnRemove.Enabled = true;
                addNew = false;

                tbName.Enabled = false;
                tbQuality.Enabled = false;
                tvPrice.Enabled = false;
                txtPhone.Enabled = false;
                txtDate.Enabled = false;
                txtProducts.Enabled = false;
                txtTotalPrice.Enabled = false;
                txtDiscount.Enabled = false;
                tbNote.Enabled = false;
                txtAddProduct.Enabled = false;
                txtQuatityProduct.Enabled = false;
                btnAddProduct.Enabled = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RemoveRecord(db.Dt);
                btnRemove.Enabled = false;
                iIndex -= 1;
                updateDataGridView();
            }
        }

        private bool checkIDProductInput(String ID) //true - can not use
        {
            String strReq = "select * from " + OrdersTable.OrdersTableName + " where " + OrdersTable.COLUMN_ID + "='" + ID + "'";
            using (SqlCommand command = new SqlCommand(strReq, db.Cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            }
            return false;
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eventEdit_Click();
        }

        private void txtAddProduct_KeyDown(object sender, KeyEventArgs e)
        {
            //show the your own suggestion box when pressing down arrow and the text box is empty
            if (e.KeyCode == Keys.Down && txtAddProduct.Text.Trim().Equals(""))
            {
                sugBox = new ListBox();
                //define the box
                sugBox.Width = txtAddProduct.Width;
                Point p = txtAddProduct.Location;
                p.Y += txtAddProduct.Height;
                sugBox.Location = p;
                sugBox.Items.AddRange(listNameProAutoComplete.ToArray());
                //copy the value to the textbox when selected index changed.
                sugBox.SelectedIndexChanged += new EventHandler(sugBox_SelectedIndexChanged);
                //show box
                if (sugBox.Items.Count > 0)
                {
                    sugBox.SelectedIndex = 0;
                    this.Controls.Add(sugBox);
                    sugBox.Focus();
                }
            }
            //remove and hide your own suggestion box when other operation
            else
            {
                if (sugBox != null && this.Controls.Contains(sugBox))
                {
                    this.Controls.Remove(sugBox);
                    sugBox.Dispose();
                    sugBox = null;
                }
            }
        }

        void sugBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selText = this.sugBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selText))
            {
                this.txtAddProduct.Text = selText;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            event_AddProduct();
        }

        private void event_AddProduct()
        {
            Product p = mainUtils.getProductInAutoComplete(txtAddProduct.Text);
            int quatityProduct = Int32.Parse(txtQuatityProduct.Text);
            if (p != null)
            {
                buyProductsSelected.Add(new BuyProduct(p, quatityProduct));
                refreshTxtProducts();
                txtAddProduct.Text = "";
            }

            //Calcul price
            showTotalPrice();
        }

        private void refreshTxtProducts()
        {
            txtProducts.Clear();
            txtProducts.Text = mainUtils.getListName_ID_QuantityFromListBuyProducts(buyProductsSelected);
        }

        private void txtProducts_MouseClick(object sender, MouseEventArgs e)
        {
            SelectProductsFrom reFrm = new SelectProductsFrom(buyProductsSelected);
            reFrm.ShowDialog(this);
        }

        //Get value from child form
        public void SendBuyProductsToParent(List<BuyProduct> buyPros)
        {
            buyProductsSelected = buyPros;
            refreshTxtProducts();
            showTotalPrice();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtPhone.Text.Remove(txtPhone.Text.Length - 1);
            }
        }

        private void txtQuatityProduct_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtPhone.Text.Remove(txtPhone.Text.Length - 1);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            showTotalPrice();
        }

        private void showTotalPrice()
        {
            if (txtDiscount.Text.Equals("")) txtDiscount.Text = "0";
            txtTotalPrice.Text = Convert.ToString(mainUtils.calculatorTotalPrice(
               buyProductsSelected, Int32.Parse(txtDiscount.Text)));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!tbName.Text.Equals("") && tbName.Text != null)
            {
                var file = Path.GetTempFileName();
                string filepath = Path.GetTempPath();
                string strFilename = "Order " + tbName.Text + ".pdf";
                using (MemoryStream ms = new MemoryStream())
                {
                    Document document = new Document(PageSize.A5, 20, 20, 15, 15);

                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Path.Combine(filepath, strFilename), FileMode.Create));
                    document.AddTitle("Document Title");
                    document.Open();

                    iTextSharp.text.pdf.BaseFont Vn_Helvetica = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", "Identity-H", iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(Vn_Helvetica, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font subTitleFont = new iTextSharp.text.Font(Vn_Helvetica, 14, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font boldTableFont = new iTextSharp.text.Font(Vn_Helvetica, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font endingMessageFont = new iTextSharp.text.Font(Vn_Helvetica, 10, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(Vn_Helvetica, 12, iTextSharp.text.Font.NORMAL);

                    document.Add(new Paragraph("Giày Hiền Phượng", titleFont));

                    var orderInfoTable = new PdfPTable(2);
                    orderInfoTable.HorizontalAlignment = 0;
                    orderInfoTable.SpacingBefore = 10;
                    orderInfoTable.SpacingAfter = 10;
                    orderInfoTable.DefaultCell.Border = 0;
                    orderInfoTable.SetWidths(new int[] { 70, 150 });

                    //Id of Order
                    orderInfoTable.AddCell(new Phrase("Mã đơn hàng: ", boldTableFont));
                    orderInfoTable.AddCell(tbName.Text);

                    //Products
                    for (int i = 0; i < buyProductsSelected.Count; i++)
                    {
                        int c = i + 1;
                        orderInfoTable.AddCell(new Phrase("Sản phẩm " + c + ": ", boldTableFont));
                        orderInfoTable.AddCell(new Phrase(buyProductsSelected[i].getProduct().getName(), bodyFont));
                        orderInfoTable.AddCell(new Phrase("Mã sản phẩm " + c + ": ", boldTableFont));
                        orderInfoTable.AddCell(buyProductsSelected[i].getProduct().getpID());
                        orderInfoTable.AddCell(new Phrase("Số lượng " + c + ": ", boldTableFont));
                        orderInfoTable.AddCell(buyProductsSelected[i].getQuantity().ToString());
                    }

                    //Total price
                    orderInfoTable.AddCell(new Phrase("Tổng giá:", boldTableFont));
                    orderInfoTable.AddCell(Convert.ToDecimal(txtTotalPrice.Text).ToString("###,###,###.00") + " dong");

                    document.Add(orderInfoTable);

                    document.Close();
                }
                System.Diagnostics.Process.Start(filepath + strFilename);
            }
            else MessageBox.Show("Chưa chọn đơn hàng!");
        }
    }
}
