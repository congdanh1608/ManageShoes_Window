namespace ManageShoes
{
    partial class Cart
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
            this.pInfo = new System.Windows.Forms.Panel();
            this.lOrder = new System.Windows.Forms.Label();
            this.pDetails = new System.Windows.Forms.Panel();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbQuality = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pInfo.SuspendLayout();
            this.pDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pInfo
            // 
            this.pInfo.Controls.Add(this.lOrder);
            this.pInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(609, 30);
            this.pInfo.TabIndex = 6;
            // 
            // lOrder
            // 
            this.lOrder.AutoSize = true;
            this.lOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOrder.Location = new System.Drawing.Point(13, 11);
            this.lOrder.Name = "lOrder";
            this.lOrder.Size = new System.Drawing.Size(63, 13);
            this.lOrder.TabIndex = 0;
            this.lOrder.Text = "Sản phẩm";
            // 
            // pDetails
            // 
            this.pDetails.Controls.Add(this.btnOk);
            this.pDetails.Controls.Add(this.tbID);
            this.pDetails.Controls.Add(this.label1);
            this.pDetails.Controls.Add(this.tbNote);
            this.pDetails.Controls.Add(this.tbPrice);
            this.pDetails.Controls.Add(this.label13);
            this.pDetails.Controls.Add(this.label11);
            this.pDetails.Controls.Add(this.tbQuality);
            this.pDetails.Controls.Add(this.label3);
            this.pDetails.Controls.Add(this.tbName);
            this.pDetails.Controls.Add(this.label2);
            this.pDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDetails.Location = new System.Drawing.Point(0, 6);
            this.pDetails.Name = "pDetails";
            this.pDetails.Size = new System.Drawing.Size(609, 270);
            this.pDetails.TabIndex = 7;
            // 
            // tbID
            // 
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(131, 44);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(417, 20);
            this.tbID.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(131, 148);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(417, 61);
            this.tbNote.TabIndex = 12;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(131, 122);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(177, 20);
            this.tbPrice.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Giảm giá còn:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Ghi chú:";
            // 
            // tbQuality
            // 
            this.tbQuality.Location = new System.Drawing.Point(131, 96);
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new System.Drawing.Size(177, 20);
            this.tbQuality.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số lượng:";
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(131, 70);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(417, 20);
            this.tbName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(247, 220);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 38);
            this.btnOk.TabIndex = 27;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 276);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.pDetails);
            this.Name = "Cart";
            this.Text = "Cart";
            this.pInfo.ResumeLayout(false);
            this.pInfo.PerformLayout();
            this.pDetails.ResumeLayout(false);
            this.pDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Label lOrder;
        private System.Windows.Forms.Panel pDetails;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
    }
}