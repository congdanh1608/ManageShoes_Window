namespace ManageShoes
{
    partial class SelectProductsFrom
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
            this.lbProductsPick = new System.Windows.Forms.Label();
            this.clbProducts = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProductsPick
            // 
            this.lbProductsPick.AutoSize = true;
            this.lbProductsPick.Location = new System.Drawing.Point(21, 9);
            this.lbProductsPick.Name = "lbProductsPick";
            this.lbProductsPick.Size = new System.Drawing.Size(81, 13);
            this.lbProductsPick.TabIndex = 0;
            this.lbProductsPick.Text = "Chọn sản phẩm";
            // 
            // clbProducts
            // 
            this.clbProducts.FormattingEnabled = true;
            this.clbProducts.Location = new System.Drawing.Point(24, 30);
            this.clbProducts.Name = "clbProducts";
            this.clbProducts.Size = new System.Drawing.Size(210, 289);
            this.clbProducts.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(159, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // RemoveBuyProductsFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 325);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clbProducts);
            this.Controls.Add(this.lbProductsPick);
            this.Name = "RemoveBuyProductsFrom";
            this.Text = "RemoveBuyProductsFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductsPick;
        private System.Windows.Forms.CheckedListBox clbProducts;
        private System.Windows.Forms.Button btnOK;
    }
}