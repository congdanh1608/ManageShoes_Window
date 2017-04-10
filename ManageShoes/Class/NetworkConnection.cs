using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes.Class
{
    class NetworkConnection
    {
        private bool iconeConnexion;

        public async Task CheckInternetAsync()
        {
            Ping myPing = new Ping();
            try
            {
                var pingReply = await myPing.SendPingAsync("google.com", 3000, new byte[32], new PingOptions(64, true));
                if (pingReply.Status == IPStatus.Success)
                {
                    this.iconeConnexion = true;
                }
            }
            catch (Exception e)
            {
                this.iconeConnexion = false;
                var dialogResult = MessageBox.Show("Không có kết nối mạng! Ứng dụng không thể làm việc.", "Kết nối mạng", MessageBoxButtons.OKCancel);
                Application.Exit();
            }
        }
    }
}
