namespace ManageShoes
{
    partial class ProductsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            this.pInfo = new System.Windows.Forms.Panel();
            this.lProduct = new System.Windows.Forms.Label();
            this.pControl = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pDetails = new System.Windows.Forms.Panel();
            this.lbCheckID = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pStatus = new System.Windows.Forms.Panel();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.tsslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pInfo.SuspendLayout();
            this.pControl.SuspendLayout();
            this.pDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pStatus.SuspendLayout();
            this.stsStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.Controls.Add(this.lProduct);
            this.pInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(844, 30);
            this.pInfo.TabIndex = 0;
            // 
            // lProduct
            // 
            this.lProduct.AutoSize = true;
            this.lProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProduct.Location = new System.Drawing.Point(13, 11);
            this.lProduct.Name = "lProduct";
            this.lProduct.Size = new System.Drawing.Size(63, 13);
            this.lProduct.TabIndex = 0;
            this.lProduct.Text = "Sản phẩm";
            // 
            // pControl
            // 
            this.pControl.AutoSize = true;
            this.pControl.Controls.Add(this.btnSave);
            this.pControl.Controls.Add(this.btnRemove);
            this.pControl.Controls.Add(this.btnEdit);
            this.pControl.Controls.Add(this.btnAdd);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pControl.Location = new System.Drawing.Point(0, 209);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(844, 39);
            this.pControl.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(259, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 35);
            this.btnSave.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSave, "Lưu");
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
            this.toolTip1.SetToolTip(this.btnRemove, "Xóa");
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
            this.toolTip1.SetToolTip(this.btnEdit, "Sửa");
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
            this.toolTip1.SetToolTip(this.btnAdd, "Thêm");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pDetails
            // 
            this.pDetails.AutoSize = true;
            this.pDetails.Controls.Add(this.lbCheckID);
            this.pDetails.Controls.Add(this.txtNote);
            this.pDetails.Controls.Add(this.picImage);
            this.pDetails.Controls.Add(this.btnImage);
            this.pDetails.Controls.Add(this.cmbStatus);
            this.pDetails.Controls.Add(this.txtSize);
            this.pDetails.Controls.Add(this.label4);
            this.pDetails.Controls.Add(this.txtDesc);
            this.pDetails.Controls.Add(this.txtPrice);
            this.pDetails.Controls.Add(this.txtQuantity);
            this.pDetails.Controls.Add(this.label13);
            this.pDetails.Controls.Add(this.label7);
            this.pDetails.Controls.Add(this.label12);
            this.pDetails.Controls.Add(this.label11);
            this.pDetails.Controls.Add(this.label10);
            this.pDetails.Controls.Add(this.label8);
            this.pDetails.Controls.Add(this.txtName);
            this.pDetails.Controls.Add(this.label3);
            this.pDetails.Controls.Add(this.txtID);
            this.pDetails.Controls.Add(this.label2);
            this.pDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDetails.Location = new System.Drawing.Point(0, 248);
            this.pDetails.Name = "pDetails";
            this.pDetails.Size = new System.Drawing.Size(844, 192);
            this.pDetails.TabIndex = 3;
            // 
            // lbCheckID
            // 
            this.lbCheckID.AutoSize = true;
            this.lbCheckID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckID.ForeColor = System.Drawing.Color.Red;
            this.lbCheckID.Location = new System.Drawing.Point(231, 16);
            this.lbCheckID.Name = "lbCheckID";
            this.lbCheckID.Size = new System.Drawing.Size(0, 13);
            this.lbCheckID.TabIndex = 29;
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Location = new System.Drawing.Point(494, 126);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(177, 63);
            this.txtNote.TabIndex = 13;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(144, 91);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(84, 71);
            this.picImage.TabIndex = 28;
            this.picImage.TabStop = false;
            // 
            // btnImage
            // 
            this.btnImage.Enabled = false;
            this.btnImage.Location = new System.Drawing.Point(234, 143);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(31, 20);
            this.btnImage.TabIndex = 8;
            this.btnImage.Text = "...";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Còn hàng",
            "Hết hàng"});
            this.cmbStatus.Location = new System.Drawing.Point(494, 13);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(127, 21);
            this.cmbStatus.TabIndex = 9;
            // 
            // txtSize
            // 
            this.txtSize.Enabled = false;
            this.txtSize.Location = new System.Drawing.Point(494, 92);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(70, 20);
            this.txtSize.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Size:";
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(144, 65);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(177, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(494, 66);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(69, 20);
            this.txtPrice.TabIndex = 11;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(494, 39);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(69, 20);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Mô tả:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Giá bán:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Ảnh sản phẩm:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(441, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Ghi chú:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(436, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Số lượng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tình trạng:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(144, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 20);
            this.txtName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tên sản phẩm:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(144, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 5;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // pStatus
            // 
            this.pStatus.Controls.Add(this.stsStatus);
            this.pStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pStatus.Location = new System.Drawing.Point(0, 440);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new System.Drawing.Size(844, 21);
            this.pStatus.TabIndex = 4;
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCount});
            this.stsStatus.Location = new System.Drawing.Point(0, -1);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(844, 22);
            this.stsStatus.TabIndex = 6;
            this.stsStatus.Text = "statusStrip1";
            // 
            // tsslCount
            // 
            this.tsslCount.Name = "tsslCount";
            this.tsslCount.Size = new System.Drawing.Size(0, 17);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 30);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(844, 179);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProducts_KeyUp);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 461);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.pControl);
            this.Controls.Add(this.pDetails);
            this.Controls.Add(this.pStatus);
            this.Name = "ProductsForm";
            this.Text = "Products";
            this.pInfo.ResumeLayout(false);
            this.pInfo.PerformLayout();
            this.pControl.ResumeLayout(false);
            this.pDetails.ResumeLayout(false);
            this.pDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pStatus.ResumeLayout(false);
            this.pStatus.PerformLayout();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.Panel pDetails;
        private System.Windows.Forms.Panel pStatus;
        private System.Windows.Forms.Label lProduct;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslCount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lbCheckID;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}