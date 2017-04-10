using ManageShoes.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    public partial class ProductsForm : Form
    {
        DBConnection db;

        public MainForm mainForm;

        private String IDItemCurrent;
        private int iIndex = 0;
        public static bool addNew = false;
        private String imgPath = "", imgName = "";
        private bool IDCheckAddNew = false;

        public ProductsForm(MainForm mainForm, string value)
        {
            this.mainForm = mainForm;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductForm_Closing);

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
            else loadProductDetail(IDItemCurrent);
        }

        private void ProductForm_Closing(object sender, FormClosingEventArgs e)
        {
            //mainForm.PerformRefresh_Products();
        }

        private void updateDataGridViewFirst()
        {
            //Load database
            db = new DBConnection();
            db.Connect();
            db.LoadDataToTable(ProductsTable.ProductTableName);
            dgvProducts.DataSource = db.Dt;

            //Update data
            dgvProducts.DataSource = convertListToDataTable(loadProducts());

            //Update current cell selected.
            if (!addNew)
            {
                dgvProducts.CurrentCell = dgvProducts[0, MainForm.ItemSelected];
                updateIDItemCurrent();
            }
        }

        private void updateDataGridView()
        {
            //Load database
            db = new DBConnection();
            db.Connect();
            db.LoadDataToTable(ProductsTable.ProductTableName);
            dgvProducts.DataSource = db.Dt;

            //Update data
            dgvProducts.DataSource = convertListToDataTable(loadProducts());

            //Update current cell selected.
            dgvProducts.CurrentCell = dgvProducts[0, iIndex];
            //dgvProducts.CurrentCell = dgvProducts[0, iIndex];
            updateIDItemCurrent();
        }

        private List<Product> loadProducts()
        {
            List<Product> products = new List<Product>();
            String strReq = "select * from " + ProductsTable.ProductTableName;
            //db = new DBConnection();
            //db.Connect();
            using (SqlCommand command = new SqlCommand(strReq, db.Cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.setpID(reader.GetString(0));
                        product.setName(reader.GetString(1));
                        product.setDesc(reader.IsDBNull(2) ? null : reader.GetString(2));
                        product.setSize(Convert.ToString(reader.GetInt32(3)));
                        product.setPrice(Convert.ToString(reader.GetInt32(4)));
                        product.setQuantity(Convert.ToString(reader.GetInt32(5)));
                        product.setNote(reader.IsDBNull(6) ? null : reader.GetString(6));
                        product.setImage(reader.IsDBNull(7) ? null : reader.GetString(7));

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        private void loadProductDetail(String ID)
        {
            Product product = new Product();
            String strReq = "select * from " + ProductsTable.ProductTableName + " where " + ProductsTable.COLUMN_ID + "='" + ID + "'";
            //db = new DBConnection();
            //db.Connect();
            using (SqlCommand command = new SqlCommand(strReq, db.Cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.setpID(reader.GetString(0));
                        product.setName(reader.GetString(1));
                        product.setDesc(reader.IsDBNull(2) ? null : reader.GetString(2));
                        product.setSize(Convert.ToString(reader.GetInt32(3)));
                        product.setPrice(Convert.ToString(reader.GetInt32(4)));
                        product.setQuantity(Convert.ToString(reader.GetInt32(5)));
                        product.setNote(reader.IsDBNull(6) ? null : reader.GetString(6));
                        product.setImage(reader.IsDBNull(7) ? null : reader.GetString(7));
                    }
                }
            }

            txtID.Text = product.getpID();
            txtName.Text = product.getName();
            txtDesc.Text = product.getDesc();
            if (product.getImage() != null && File.Exists(ConstantPath.imagePath + product.getImage()))
            {
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage.Image = Image.FromFile(ConstantPath.imagePath + product.getImage());
            }
            else picImage.Image = null;
            txtQuantity.Text = product.getQuantity();
            txtPrice.Text = product.getPrice();
            txtSize.Text = product.getSize();
            txtNote.Text = product.getNote();
            if (product.getQuantity() != null && Int32.Parse(product.getQuantity()) > 0)
            {
                cmbStatus.Text = "Còn hàng";
            }
        }

        private DataTable convertListToDataTable(List<Product> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add(ProductsTable.COLUMN_ID_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_NAME_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_DESC_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_SIZE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_PRICE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_QUANTITY_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_NOTE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_IMAGE_NAME, typeof(string));

            foreach (Product p in list)
            {
                table.Rows.Add(p.getpID(), p.getName(), p.getDesc(), p.getSize(),
                    p.getPrice(), p.getQuantity(), p.getNote(), p.getImage());
            }

            return table;
        }

        private void updateIDItemCurrent()
        {
            DataGridViewRow selectedRow = dgvProducts.Rows[dgvProducts.CurrentCell.RowIndex];
            iIndex = dgvProducts.CurrentCell.RowIndex;
            IDItemCurrent = Convert.ToString(selectedRow.Cells[0].Value);
        }

        public void AddNew()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDesc.Text = "";
            imgPath = "";
            picImage.Refresh();
            txtSize.Text = "";
            cmbStatus.Text = "Còn hàng";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtNote.Text = "";

            addNew = true;
            txtID.Focus();
        }

        public void WriteData(DataTable dat)
        {

            DataRow newRow;
            if (addNew == true)
                newRow = dat.NewRow();
            else
                newRow = dat.Rows[iIndex];

            //Khởi tạo và gán dữ liệu
            newRow[ProductsTable.COLUMN_ID] = txtID.Text;
            newRow[ProductsTable.COLUMN_NAME] = txtName.Text;
            newRow[ProductsTable.COLUMN_DESC] = String.IsNullOrEmpty(txtDesc.Text) ? null : txtDesc.Text;
            if (imgPath != "")
            {
                newRow[ProductsTable.COLUMN_IMAGE] = String.IsNullOrEmpty(imgPath) ? null : ConstantPath.imagePath + imgName;
            }
            //newRow[COLUM] = String.IsNullOrEmpty(cmbStatus.Text) ? null : cmbStatus.Text;
            newRow[ProductsTable.COLUMN_SIZE] = String.IsNullOrEmpty(txtSize.Text) ? 0 : Int32.Parse(txtSize.Text);
            newRow[ProductsTable.COLUMN_QUANTITY] = txtQuantity.Text;
            newRow[ProductsTable.COLUMN_PRICE] = Int32.Parse(txtPrice.Text);
            newRow[ProductsTable.COLUMN_NOTE] = String.IsNullOrEmpty(txtNote.Text) ? null : txtNote.Text;
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
            if (txtID.Text == "" || txtName.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Các thông tin bắt buộc bao gồm: Mã sp, tên sp, số lượng và giá sp!");
                return false;
            }
            else if (addNew && !IDCheckAddNew)
            {
                MessageBox.Show("Mã sản phẩm bị trùng. Thử nhập mã khác.");
                return false;
            }

            return true;
        }

        public void RemoveRecord(DataTable dat)
        {
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            dat.Rows[iIndex].Delete();
            db.Adt.Update(dat);
            dat.AcceptChanges();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eventMove();
        }

        private void dgvProducts_KeyUp(object sender, KeyEventArgs e)
        {
            eventMove();
        }

        private void eventMove()
        {
            updateIDItemCurrent();
            loadProductDetail(IDItemCurrent);

            btnEdit.Enabled = true;
            btnRemove.Enabled = true;
            btnSave.Enabled = false;

            lbCheckID.Text = "";

            txtID.Enabled = false;
            txtName.Enabled = false;
            txtDesc.Enabled = false;
            txtQuantity.Enabled = false;
            txtPrice.Enabled = false;
            txtSize.Enabled = false;
            txtNote.Enabled = false;
            cmbStatus.Enabled = false;
            btnImage.Enabled = false;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "All Files (*.*)|*.*|JPEG Images (*.jpg)|*.jpg|Windows Bitmap (*.bmp)|*.bmp|GIF Images (*.gif)|*.gif|PNG Images (*.png)|*.png";
            openFileDialog.ShowDialog();
            imgPath = openFileDialog.FileName;
            imgName = openFileDialog.SafeFileName;
            if (imgPath != "")
            {
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage.Image = Image.FromFile(imgPath);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            eventEdit_Click();
        }

        private void eventEdit_Click()
        {
            txtID.Enabled = true;
            txtName.Enabled = true;
            txtDesc.Enabled = true;
            txtQuantity.Enabled = true;
            txtPrice.Enabled = true;
            txtSize.Enabled = true;
            txtNote.Enabled = true;
            cmbStatus.Enabled = true;
            btnImage.Enabled = true;

            addNew = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            eventAdd_Click();
        }

        private void eventAdd_Click()
        {
            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;

            txtID.Enabled = true;
            txtName.Enabled = true;
            txtDesc.Enabled = true;
            txtQuantity.Enabled = true;
            txtPrice.Enabled = true;
            txtSize.Enabled = true;
            txtNote.Enabled = true;
            cmbStatus.Enabled = true;
            btnImage.Enabled = true;

            AddNew();
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

                txtID.Enabled = false;
                txtName.Enabled = false;
                txtDesc.Enabled = false;
                txtQuantity.Enabled = false;
                txtPrice.Enabled = false;
                txtSize.Enabled = false;
                txtNote.Enabled = false;
                cmbStatus.Enabled = false;
                btnImage.Enabled = false;

                //Save image
                CreateNewImage(imgPath, imgName);
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

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (addNew)
            {
                if (txtID != null || !txtID.Equals(""))
                {
                    if (checkIDProductInput(txtID.Text))
                    {
                        lbCheckID.Text = "Mã đã tồn tại";
                        IDCheckAddNew = false;
                    }
                    else
                    {
                        lbCheckID.Text = "Mã có thể sử dụng được";
                        IDCheckAddNew = true;
                    }
                }
            }
        }

        private bool checkIDProductInput(String ID) //true - can not use
        {
            String strReq = "select * from " + ProductsTable.ProductTableName + " where " + ProductsTable.COLUMN_ID + "='" + ID + "'";
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

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eventEdit_Click();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
            }
        }

        private void CreateNewImage(String pathImage, String fileName)
        {
            if (!string.IsNullOrEmpty(pathImage))
            {
                String newImagePath = ConstantPath.imagePath + fileName;
                Image image = Image.FromFile(pathImage);
                if (image != null)
                {
                    Image newImage = MainUtils.ScaleImage(image, ConstantPath.imageW, ConstantPath.imageH);
                    newImage.Save(newImagePath, ImageFormat.Jpeg);
                }
            }
        }

    }
}
