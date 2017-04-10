namespace ManageShoes
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.pInfo = new System.Windows.Forms.Panel();
            this.lOrder = new System.Windows.Forms.Label();
            this.pDetails = new System.Windows.Forms.Panel();
            this.tbQuality = new System.Windows.Forms.TextBox();
            this.txtAddProduct = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuatityProduct = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pControl = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tvPrice = new System.Windows.Forms.TextBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pInfo.SuspendLayout();
            this.pDetails.SuspendLayout();
            this.pControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 30);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(844, 137);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOrders_KeyUp);
            // 
            // pInfo
            // 
            this.pInfo.Controls.Add(this.lOrder);
            this.pInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(844, 30);
            this.pInfo.TabIndex = 2;
            // 
            // lOrder
            // 
            this.lOrder.AutoSize = true;
            this.lOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOrder.Location = new System.Drawing.Point(13, 11);
            this.lOrder.Name = "lOrder";
            this.lOrder.Size = new System.Drawing.Size(85, 13);
            this.lOrder.TabIndex = 0;
            this.lOrder.Text = "Đơn đặt hàng";
            // 
            // pDetails
            // 
            this.pDetails.Controls.Add(this.tbNote);
            this.pDetails.Controls.Add(this.tvPrice);
            this.pDetails.Controls.Add(this.tbName);
            this.pDetails.Controls.Add(this.tbQuality);
            this.pDetails.Controls.Add(this.txtAddProduct);
            this.pDetails.Controls.Add(this.label9);
            this.pDetails.Controls.Add(this.label8);
            this.pDetails.Controls.Add(this.label6);
            this.pDetails.Controls.Add(this.txtQuatityProduct);
            this.pDetails.Controls.Add(this.btnAddProduct);
            this.pDetails.Controls.Add(this.txtProducts);
            this.pDetails.Controls.Add(this.label4);
            this.pDetails.Controls.Add(this.txtDate);
            this.pDetails.Controls.Add(this.label5);
            this.pDetails.Controls.Add(this.txtPhone);
            this.pDetails.Controls.Add(this.label1);
            this.pDetails.Controls.Add(this.txtTotalPrice);
            this.pDetails.Controls.Add(this.txtDiscount);
            this.pDetails.Controls.Add(this.label13);
            this.pDetails.Controls.Add(this.label7);
            this.pDetails.Controls.Add(this.label11);
            this.pDetails.Controls.Add(this.label10);
            this.pDetails.Controls.Add(this.label3);
            this.pDetails.Controls.Add(this.label2);
            this.pDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDetails.Location = new System.Drawing.Point(0, 203);
            this.pDetails.Name = "pDetails";
            this.pDetails.Size = new System.Drawing.Size(844, 258);
            this.pDetails.TabIndex = 5;
            // 
            // tbQuality
            // 
            this.tbQuality.Enabled = false;
            this.tbQuality.Location = new System.Drawing.Point(143, 43);
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new System.Drawing.Size(177, 20);
            this.tbQuality.TabIndex = 37;
            // 
            // txtAddProduct
            // 
            this.txtAddProduct.Enabled = false;
            this.txtAddProduct.Location = new System.Drawing.Point(462, 38);
            this.txtAddProduct.Name = "txtAddProduct";
            this.txtAddProduct.Size = new System.Drawing.Size(159, 20);
            this.txtAddProduct.TabIndex = 13;
            this.txtAddProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddProduct_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(626, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Số lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Tên sản phẩm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Thêm sp:";
            // 
            // txtQuatityProduct
            // 
            this.txtQuatityProduct.Enabled = false;
            this.txtQuatityProduct.Location = new System.Drawing.Point(629, 38);
            this.txtQuatityProduct.Name = "txtQuatityProduct";
            this.txtQuatityProduct.Size = new System.Drawing.Size(57, 20);
            this.txtQuatityProduct.TabIndex = 14;
            this.txtQuatityProduct.Text = "1";
            this.txtQuatityProduct.TextChanged += new System.EventHandler(this.txtQuatityProduct_TextChanged);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(692, 36);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(49, 23);
            this.btnAddProduct.TabIndex = 15;
            this.btnAddProduct.Text = "Thêm";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // txtProducts
            // 
            this.txtProducts.Enabled = false;
            this.txtProducts.Location = new System.Drawing.Point(462, 65);
            this.txtProducts.Multiline = true;
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(279, 103);
            this.txtProducts.TabIndex = 16;
            this.txtProducts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtProducts_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Sản phẩm:";
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(143, 120);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(177, 20);
            this.txtDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ngày mua:";
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(143, 94);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(177, 20);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Số điện thoại:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Location = new System.Drawing.Point(144, 175);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(92, 20);
            this.txtTotalPrice.TabIndex = 11;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(143, 147);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(93, 20);
            this.txtDiscount.TabIndex = 10;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(91, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tổng giá:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(90, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Ghi chú:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Giảm giá:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên người mua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã đơn hàng";
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.btnPrint);
            this.pControl.Controls.Add(this.btnSave);
            this.pControl.Controls.Add(this.btnRemove);
            this.pControl.Controls.Add(this.btnEdit);
            this.pControl.Controls.Add(this.btnAdd);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pControl.Location = new System.Drawing.Point(0, 167);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(844, 36);
            this.pControl.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::ManageShoes.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(397, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 35);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(259, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(117, 1);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(50, 35);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(61, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 35);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "";
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(5, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(143, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(177, 20);
            this.tbName.TabIndex = 38;
            // 
            // tvPrice
            // 
            this.tvPrice.Enabled = false;
            this.tvPrice.Location = new System.Drawing.Point(144, 69);
            this.tvPrice.Name = "tvPrice";
            this.tvPrice.Size = new System.Drawing.Size(177, 20);
            this.tvPrice.TabIndex = 39;
            // 
            // tbNote
            // 
            this.tbNote.Enabled = false;
            this.tbNote.Location = new System.Drawing.Point(144, 201);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(165, 57);
            this.tbNote.TabIndex = 40;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.pControl);
            this.Controls.Add(this.pDetails);
            this.Name = "OrdersForm";
            this.Text = "OrdersForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pInfo.ResumeLayout(false);
            this.pInfo.PerformLayout();
            this.pDetails.ResumeLayout(false);
            this.pDetails.PerformLayout();
            this.pControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Label lOrder;
        private System.Windows.Forms.Panel pDetails;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pControl;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuatityProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox txtAddProduct;
        public System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox tbQuality;
        private System.Windows.Forms.TextBox tvPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbNote;

    }
}