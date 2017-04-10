namespace ManageShoes
{
    partial class OptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoginDropbox = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTimeSync = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSkype = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFb = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNameOwner = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbShopName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSizePagePrint = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bước 1:";
            // 
            // btnLoginDropbox
            // 
            this.btnLoginDropbox.Location = new System.Drawing.Point(194, 82);
            this.btnLoginDropbox.Name = "btnLoginDropbox";
            this.btnLoginDropbox.Size = new System.Drawing.Size(155, 23);
            this.btnLoginDropbox.TabIndex = 1;
            this.btnLoginDropbox.Text = "Login Dropbox";
            this.btnLoginDropbox.UseVisualStyleBackColor = true;
            this.btnLoginDropbox.Click += new System.EventHandler(this.btnLoginDropbox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bước 2:";
            // 
            // cbTimeSync
            // 
            this.cbTimeSync.FormattingEnabled = true;
            this.cbTimeSync.Items.AddRange(new object[] {
            "Thủ công",
            "Hằng giờ",
            "Mỗi sau 3 giờ (Khuyến nghị)",
            "Hằng ngày ",
            "Không bao giờ"});
            this.cbTimeSync.Location = new System.Drawing.Point(194, 135);
            this.cbTimeSync.Name = "cbTimeSync";
            this.cbTimeSync.Size = new System.Drawing.Size(155, 21);
            this.cbTimeSync.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(260, 422);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(142, 35);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đồng bộ hóa với Dropbox";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Đăng nhập với tài khoản Dropbox";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cài đặt thời gian đồng bộ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLoginDropbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbTimeSync);
            this.groupBox1.Location = new System.Drawing.Point(6, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 166);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lưu trữ đám mây";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(376, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 30);
            this.label9.TabIndex = 13;
            this.label9.Text = "Cài đặt thời gian tự động đồng bộ hóa hoặc đồng bộ hóa thủ công (File -> Đồng bộ " +
    "hóa...)";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(167, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(325, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ứng dụng sẽ sử dụng Dropbox làm nơi lưu trữ và đồng bộ hóa dữ liệu";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(376, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bạn cần đăng nhập cùng một tài Dropbox trên các máy tính sử dụng ứng dụng.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSkype);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tbEmail);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbFb);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbAddress);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbPhone);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbNameOwner);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbShopName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 136);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cửa hàng";
            // 
            // tbSkype
            // 
            this.tbSkype.Location = new System.Drawing.Point(427, 22);
            this.tbSkype.Name = "tbSkype";
            this.tbSkype.Size = new System.Drawing.Size(191, 20);
            this.tbSkype.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(331, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Skype:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(427, 48);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(191, 20);
            this.tbEmail.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(331, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Email:";
            // 
            // tbFb
            // 
            this.tbFb.Location = new System.Drawing.Point(427, 74);
            this.tbFb.Name = "tbFb";
            this.tbFb.Size = new System.Drawing.Size(191, 20);
            this.tbFb.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(331, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Facebook page:";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(102, 100);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(516, 20);
            this.tbAddress.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Địa chỉ:";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(102, 74);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(191, 20);
            this.tbPhone.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Số điện thoại:";
            // 
            // tbNameOwner
            // 
            this.tbNameOwner.Location = new System.Drawing.Point(102, 48);
            this.tbNameOwner.Name = "tbNameOwner";
            this.tbNameOwner.Size = new System.Drawing.Size(191, 20);
            this.tbNameOwner.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Tên chủ cửa hàng:";
            // 
            // tbShopName
            // 
            this.tbShopName.Location = new System.Drawing.Point(102, 22);
            this.tbShopName.Name = "tbShopName";
            this.tbShopName.Size = new System.Drawing.Size(191, 20);
            this.tbShopName.TabIndex = 9;
            this.tbShopName.Text = "Giày Phố";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tên cửa hàng:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbSizePagePrint);
            this.groupBox3.Location = new System.Drawing.Point(6, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 90);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cài đặt khác";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Khổ giấy in:";
            // 
            // cbSizePagePrint
            // 
            this.cbSizePagePrint.FormattingEnabled = true;
            this.cbSizePagePrint.Items.AddRange(new object[] {
            "A2",
            "A3",
            "A4",
            "A4 - Chiều ngang",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10"});
            this.cbSizePagePrint.Location = new System.Drawing.Point(102, 23);
            this.cbSizePagePrint.Name = "cbSizePagePrint";
            this.cbSizePagePrint.Size = new System.Drawing.Size(97, 21);
            this.cbSizePagePrint.TabIndex = 9;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "OptionForm";
            this.Text = "Cài đặt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnLoginDropbox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbTimeSync;
        public System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbShopName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbSkype;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbFb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNameOwner;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cbSizePagePrint;
    }
}