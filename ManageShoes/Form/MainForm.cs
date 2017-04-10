using iTextSharp.text.pdf;
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
using System.Timers;
using System.Windows.Forms;

namespace ManageShoes
{
    public partial class MainForm : Form
    {
        DBConnection db;
        DatabaseHelper DBHelper;
        private MenuItems subMenu;
        private enum MenuItems { Products, AddProduct, Orders, AddOrder };
        DropboxNemiro dropboxNemiro;
        MainUtils mainUtils;

        private String IDItemCurrent;
        private int iIndex = 0;
        public static bool addNew = false;
        private String imgPath = "", imgName = "";
        private bool IDCheckAddNew = false;

        ListBox sugBox = null, sugDescBox;
        List<String> listNameProAutoComplete = null, listDescProAutoComplete = null;

        //Cart
        List<Product> productsCart = new List<Product>();

        public static int ItemSelected
        {
            get;
            set;
        }

        public MainForm()
        {
            //Check DB
            if (String.IsNullOrEmpty(MainUtils.readDataConnect()))
            {
                loadAttachDBFirst();
            }

            InitializeComponent();

            MainUtils.checkFolder();

            dropboxNemiro = new DropboxNemiro(this, null);
            DBHelper = new DatabaseHelper();
            mainUtils = new MainUtils();

            //CheckBox network
            mainUtils.runCheckConnection();

            SyncWithDropbox();

            updateDataGridView();

            loadProductDetail(IDItemCurrent);

            autoComplete();
        }

        //AutoComple
        private void autoComplete()
        {
            List<string> arrays = new List<string>();
            arrays.Add(ProductsTable.COLUMN_NAME);

            //Name
            listNameProAutoComplete = mainUtils.getListInfosOfAllProduct(arrays);
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(listNameProAutoComplete.ToArray());
            this.tbSearchName.AutoCompleteCustomSource = autoCollection;
            this.tbSearchName.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tbSearchName.AutoCompleteSource = AutoCompleteSource.CustomSource;


            List<string> arraysDesc = new List<string>();
            arraysDesc.Add(ProductsTable.COLUMN_DESC);
            //Desc
            listDescProAutoComplete = mainUtils.getListInfosOfAllProduct(arraysDesc);
            var autoDescCollection = new AutoCompleteStringCollection();
            autoDescCollection.AddRange(listDescProAutoComplete.ToArray());
            this.tbSearchDesc.AutoCompleteCustomSource = autoDescCollection;
            this.tbSearchDesc.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tbSearchDesc.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void connectDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new DBConnection();
            db.Connect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You really want to close the program?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDataGridView();
            subMenu = MenuItems.Products;
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subMenu = MenuItems.AddProduct;
            ProductsForm frm = new ProductsForm(this, "ADDNEW");
            frm.ShowDialog();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDataGridView_Orders();
            subMenu = MenuItems.Orders;
        }

        public void updateDataGridView_Orders()
        {
            BindingSource bs = DBHelper.getBindingSourceOrders();
            if (bs != null)
            {
                dgvProducts.DataSource = bs;
            }
            else
            {
                MessageBox.Show("No order in database.");
            }
        }

        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subMenu = MenuItems.AddOrder;
            OrdersForm ord = new OrdersForm(this, "ADDNEW");
            ord.ShowDialog();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (subMenu == MenuItems.Products || subMenu == MenuItems.AddProduct)
            {
                ItemSelected = dgvProducts.CurrentCell.RowIndex;
                ProductsForm frm = new ProductsForm(this, null);
                frm.ShowDialog();
            }
            else if (subMenu == MenuItems.Orders || subMenu == MenuItems.AddOrder)
            {
                ItemSelected = dgvProducts.CurrentCell.RowIndex;
                OrdersForm ord = new OrdersForm(this, null);
                ord.ShowDialog();
            }
        }

        private void toJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionForm op = new OptionForm();
            op.ShowDialog();
        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncToDropboxNow();
        }

        public void SyncToDropboxNow()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                MessageBox.Show("Bạn chưa đăng nhập tài khoản Dropbox! (File -> Cài đặt)");
            }
            else
            {
                String versionJsonPath = ConstantPath.jsonPath + ConstantPath.verJson;
                String productJsonPath = ConstantPath.jsonPath + ConstantPath.productJson;
                String orderJsonPath = ConstantPath.jsonPath + ConstantPath.orderJson;

                //Check
                bool newData = mainUtils.checkVersionUpload(dropboxNemiro);

                //Download + Update Data
                if (!newData)
                {
                    mainUtils.updateDataBaseFromJson(dropboxNemiro);
                    MessageBox.Show("Đã cập nhật data xong!");
                }
                else
                {
                    //Upload
                    mainUtils.prepareJsonFile();

                    if (File.Exists(productJsonPath) && File.Exists(versionJsonPath))
                    {
                        dropboxNemiro.uploadFileToDropbox(versionJsonPath);
                        dropboxNemiro.uploadFileToDropbox(productJsonPath);
                        //dropboxNemiro.uploadFileToDropbox(orderJsonPath);

                        MessageBox.Show("Đã upload data xong!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi tạo file json!");
                    }
                }
                iIndex = 0;     //reset index
                updateDataGridView();
            }
        }


        private void SyncWithDropbox()
        {
            int sync = Properties.Settings.Default.TimeSync;
            System.Timers.Timer aTimer;
            switch (sync)
            {
                case 0: //Nothing
                    break;
                case 1: //Hourly
                    aTimer = new System.Timers.Timer(120 * 1000);
                    aTimer.Elapsed += new ElapsedEventHandler(OnHourlyEvent);
                    break;
                case 2: //3 Hourly
                    aTimer = new System.Timers.Timer(3 * 60 * 60 * 1000);
                    aTimer.Elapsed += new ElapsedEventHandler(On3HourlyEvent);
                    break;
                case 3: //Daily
                    aTimer = new System.Timers.Timer(24 * 60 * 60 * 1000);
                    aTimer.Elapsed += new ElapsedEventHandler(OnDailyEvent);
                    break;
                case 4: //Nothing
                    break;
            }
        }

        private void OnHourlyEvent(object source, ElapsedEventArgs e)
        {
            //Do s.th every hour;
            SyncToDropboxNow();
        }

        private void On3HourlyEvent(object source, ElapsedEventArgs e)
        {
            //Do s.th every 3 hour;
            SyncToDropboxNow();
        }

        private void OnDailyEvent(object source, ElapsedEventArgs e)
        {
            //Do s.th every day;
            SyncToDropboxNow();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Development by Công Danh");
        }


        private void loadAttachDBFirst()
        {
            AttachDBFormcs frm = new AttachDBFormcs();
            frm.ShowDialog();
        }

        private void updateDataGridViewFirst()
        {
            //Load database
            dgvProducts.DataSource = DBHelper.getDBConnection().Dt;

            //Update data
            dgvProducts.DataSource = MainUtils.convertListToDataTable(DBHelper.getAllProduct());

            //Update current cell selected.
            if (!addNew)
            {
                dgvProducts.CurrentCell = dgvProducts[0, MainForm.ItemSelected];
                updateIDItemCurrent();
            }
        }

        private void updateDataGridView()
        {
            List<Product> products = DBHelper.getAllProduct();
            if (products != null)
            {

                //Load database
                dgvProducts.DataSource = DBHelper.getDBConnection().Dt;

                //Update data
                dgvProducts.DataSource = MainUtils.convertListToDataTable(products);

                //Update current cell selected.
                if(iIndex>0)
                dgvProducts.CurrentCell = dgvProducts[0, iIndex];

                updateIDItemCurrent();
            }
            else MessageBox.Show("Không có sản phẩm nào trong dữ liệu!");
        }


        private void loadProductDetail(String id)
        {
            if (id != null)
            {
                Product product = DBHelper.getProductBy(ProductsTable.COLUMN_ID, id);

                txtID.Text = product.getpID();
                txtName.Text = product.getName();
                txtDesc.Text = product.getDesc();
                if (product.getImage() != null && File.Exists(ConstantPath.imagePath + product.getImage()))
                {
                    picImage.SizeMode = PictureBoxSizeMode.Zoom;
                    picImage.Image = System.Drawing.Image.FromFile(ConstantPath.imagePath + product.getImage());
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
        }



        private void updateIDItemCurrent()
        {
            if (dgvProducts.RowCount > 0 && dgvProducts.CurrentCell!=null)
            {
                DataGridViewRow selectedRow = dgvProducts.Rows[dgvProducts.CurrentCell.RowIndex];
                iIndex = dgvProducts.CurrentCell.RowIndex;
                IDItemCurrent = Convert.ToString(selectedRow.Cells[0].Value);
            }
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

        public void WriteData()
        {
            Product product = new Product();

            //create data
            product.setpID(txtID.Text);
            product.setName(txtName.Text);
            product.setDesc(txtDesc.Text);
            if (imgPath != "")
            {
                product.setImage(imgName);
            }
            //newRow[COLUM] = String.IsNullOrEmpty(cmbStatus.Text) ? null : cmbStatus.Text;
            product.setSize(txtSize.Text);
            product.setQuantity(txtQuantity.Text);
            product.setPrice(txtPrice.Text);
            product.setNote(txtNote.Text);

            if (addNew)
            {
                DBHelper.addProduct(product);
                iIndex = DBHelper.getDBConnection().Dt.Rows.Count - 1;
                addNew = false;
            }
            else
            {
                DBHelper.updateProduct(product, iIndex);
            }


        }

        private bool CheckInfo()
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
            btnAddCart.Enabled = true;

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
                picImage.SizeMode = PictureBoxSizeMode.Zoom;
                picImage.Image = System.Drawing.Image.FromFile(imgPath);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            eventEdit_Click();
        }

        private void eventEdit_Click()
        {
            if (mainUtils.checkVersionWithDialog(dropboxNemiro, this))
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

                btnAddCart.Enabled = false;
                addNew = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            eventAdd_Click();
        }

        private void eventAdd_Click()
        {
            if (mainUtils.checkVersionWithDialog(dropboxNemiro, this))
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

                picImage.Image = null;

                AddNew();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInfo())
            {
                WriteData();
                updateDataGridView();

                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnRemove.Enabled = true;
                btnAddCart.Enabled = true;
                addNew = false;

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

                //Save image
                CreateNewImage(imgPath, imgName);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            event_removeProduct();
        }

        private void event_removeProduct()
        {
            if (mainUtils.checkVersionWithDialog(dropboxNemiro, this))
            {
                List<int> rowsSelected = getListRowSelected();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (int i in rowsSelected)
                    {
                        DBHelper.removeProduct(i);
                        btnRemove.Enabled = false;
                        if (i > 0)
                            iIndex = i - 1;
                        updateDataGridView();
                    }
                }
            }
        }

        private List<int> getListRowSelected()
        {
            List<int> rows = new List<int>();
            foreach (DataGridViewCell cell in dgvProducts.SelectedCells)
            {
                rows.Add(cell.RowIndex);
            }
            return rows;
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
                    else if (string.IsNullOrEmpty(txtID.Text))
                    {
                        lbCheckID.Text = "";
                    }
                    else
                    {
                        lbCheckID.Text = "Mã có thể sử dụng được";
                        IDCheckAddNew = true;
                    }
                }
            }
        }

        private bool checkIDProductInput(String id) //true - can not use
        {
            Product product = DBHelper.getProductBy(ProductsTable.COLUMN_ID, id);
            if (product != null) return true;
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

        private void txtSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            //show the your own suggestion box when pressing down arrow and the text box is empty
            if (e.KeyCode == Keys.Down && tbSearchName.Text.Trim().Equals(""))
            {
                sugBox = new ListBox();
                //define the box
                sugBox.Width = tbSearchName.Width;
                Point p = tbSearchName.Location;
                p.Y += tbSearchName.Height;
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

        private void txtSearchDesc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        void sugBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selText = this.sugBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selText))
            {
                this.tbSearchName.Text = selText;
            }
        }

        void sugDescBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selText = this.sugDescBox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(selText))
            {
                this.tbSearchDesc.Text = selText;
            }
        }

        private void tbSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateSearchNameDataGridView(tbSearchName.Text);
            }
        }

        private void updateSearchNameDataGridView(String value)
        {
            List<Product> products = DBHelper.getProductsLike(ProductsTable.COLUMN_NAME, value);
            if (products.Count > 0)
            {
                //Load database
                dgvProducts.DataSource = DBHelper.getDBConnection().Dt;

                //Update data
                dgvProducts.DataSource = MainUtils.convertListToDataTable(products);

                //Update current cell selected.
                //dgvProducts.CurrentCell = dgvProducts[0, iIndex];

                updateIDItemCurrent();
            }
        }

        private void tbSearchDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateSearchDescDataGridView(tbSearchDesc.Text);
            }
        }

        private void updateSearchDescDataGridView(String value)
        {
            List<Product> products = DBHelper.getProductsLike(ProductsTable.COLUMN_DESC, value);
            if (products.Count > 0)
            {
                //Load database
                dgvProducts.DataSource = DBHelper.getDBConnection().Dt;

                //Update data
                dgvProducts.DataSource = MainUtils.convertListToDataTable(products);

                //Update current cell selected.
                //dgvProducts.CurrentCell = dgvProducts[0, iIndex];

                updateIDItemCurrent();
            }
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            event_AddProductToCart();
        }

        private void event_AddProductToCart()
        {
            if (mainUtils.checkVersionWithDialog(dropboxNemiro, this))
            {
                List<int> rows = getListRowSelected();
                foreach (int i in rows)
                {
                    String id = dgvProducts.Rows[i].Cells[0].Value.ToString();
                    Product product = DBHelper.getProductBy(ProductsTable.COLUMN_ID, id);
                    if (mainUtils.checkProductExitsInCart(productsCart, product))
                    {
                        String nameProduct = product.getName().ToUpper().ToString();
                        MessageBox.Show("Sản phẩm " + nameProduct + " đã tồn tại trong giỏ hàng!");
                    }
                    else
                    {
                        productsCart.Add(product);
                    }
                }
                updateDataForCart();
            }
        }

        private void updateDataForCart()
        {
            //Load database
            dgvCart.DataSource = DBHelper.getDBConnection().Dt;

            //Update data
            dgvCart.DataSource = MainUtils.convertListToDataTableCart(productsCart);

            mainUtils.addButtonToGridView(dgvCart);

            //show / hidden cart gridview
            if (productsCart.Count == 0)
            {
                dgvCart.Visible = false;
            }
            else
            {
                dgvCart.Visible = true;
            }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            event_dgvCartClick(e);
        }

        private void event_dgvCartClick(DataGridViewCellEventArgs e)
        {
            // Delete
            if (e.ColumnIndex == dgvCart.Columns[Constant.NAME_VALUE_BTN_REMOVE].Index && e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                String nameProduct = productsCart[index].getName().ToUpper().ToString();
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa " + nameProduct + " khỏi giỏ hàng?", "Giỏ hàng", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    removeProductFromCart(index);
                }
            }
            //Edit
            else
            {
                int index = dgvCart.CurrentCell.RowIndex;
                Cart frm = new Cart(this, productsCart[index]);
                frm.ShowDialog();
            }
        }

        private void removeProductFromCart(int index)
        {
            if (productsCart.Count > index && index >= 0)
            {
                productsCart.RemoveAt(index);
            }
            updateDataForCart();
        }

        public void SendBuyProductToParent(Product product)
        {
            foreach (Product pro in productsCart)
            {
                if (product.getpID().Equals(pro.getpID()))
                {
                    pro.setPrice(product.getPrice());
                    pro.setQuantity(product.getQuantity());
                    pro.setNote(product.getNote());
                }
            }
            updateDataForCart();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            if (picImage.Image != null)
            {
                Form frm = new Form();
                PictureBox pb = new PictureBox();
                pb.Image = picImage.Image;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                //pb.Image = myImage;
                pb.Dock = DockStyle.Fill;
                frm.Controls.Add(pb);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You really want to close the program?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (productsCart.Count > 0)
            {
                mainUtils.printOrder(productsCart);
            }
            else MessageBox.Show("Giỏ hàng trống!");
        }

        private void btnFinishCart_Click(object sender, EventArgs e)
        {
            event_FinishCart();
        }

        private void event_FinishCart()
        {
            if (productsCart.Count > 0)
            {
                mainUtils.exportOther(productsCart);
                updateDataGridView();
                productsCart.Clear();
                updateDataForCart();
                MessageBox.Show("Đã xuất đơn hàng!");
            }
            else
            {
                MessageBox.Show("Giỏ hàng trống");
            }
        }
    }
}