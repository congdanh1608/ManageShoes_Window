using ManageShoes.Class;
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
    public partial class OptionForm : Form
    {
        DropboxNemiro dropboxNemiro;

        public OptionForm()
        {
            dropboxNemiro = new DropboxNemiro(null, this);
            this.CenterToScreen();
            InitializeComponent();

            cbSizePagePrint.SelectedIndex = 2;
            cbTimeSync.SelectedIndex = 0;
        }

        private void btnLoginDropbox_Click(object sender, EventArgs e)
        {
            dropboxNemiro.LoadDropbox();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            event_OK();
        }

        private void event_OK()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                DialogResult dr = MessageBox.Show("Lỗi không thể lấy mã truy cập từ Dropbox, vui lòng thử đăng nhập lại! \nBạn có muốn bỏ qua? \nNếu bạn bỏ qua ứng dụng sẽ không thể đồng bộ hóa!", "Lỗi chứng thực Dropbox", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {

                }
                else if (dr == DialogResult.Yes)
                {
                    saveData();
                }
            }
            else
            {
                saveData();
            }
        }

        private void saveData()
        {
            //Info owner
            Properties.Settings.Default.ShopName = tbShopName.Text;
            Properties.Settings.Default.OwnerName = tbNameOwner.Text;
            Properties.Settings.Default.OwnerPhone = tbPhone.Text;
            Properties.Settings.Default.OwnerSkype = tbSkype.Text;
            Properties.Settings.Default.OwnerFb = tbFb.Text;
            Properties.Settings.Default.OwnerEmail = tbEmail.Text;
            Properties.Settings.Default.OwnerAddress = tbAddress.Text;

            //Other setting     0-A2 / 1-A3 / 2 - A4 ...        --default A4
            Properties.Settings.Default.SizePagePrint = cbSizePagePrint.SelectedIndex;

            //TimeSync 0 Manual / 1 Hourly / 2 3Hourly / 3 Daily / 4 Never.
            Properties.Settings.Default.TimeSync = cbTimeSync.SelectedIndex;

            //Save and Close
            Properties.Settings.Default.Save();
            this.Close();
        }

    }
}
