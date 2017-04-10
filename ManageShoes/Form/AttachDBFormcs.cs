using ManageShoes.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    public partial class AttachDBFormcs : Form
    {
        String pathToDatbase = null;

        public AttachDBFormcs()
        {
            InitializeComponent();
            this.CenterToScreen();

            addDefaultTextToTbox();
        }

        private void addDefaultTextToTbox()
        {
            txtPath.Text = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + ConstantPath.DBFileMDF;
            txtServer.Text = "SILVERWOLF\\SQLEXPRESS";
            txtDatabase.Text = "oneidea";
            pathToDatbase = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\";
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            string str = @"server=" + txtServer.Text.ToString() +";database=master;integrated security=true;";
            AutoAttachDB(str, txtPath.Text);
        }

        private void AutoAttachDB(string str, string DBname)
        {
            if (!String.IsNullOrEmpty(DBname))
            {
                try
                {
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("EXEC sp_attach_db @dbname = N'oneidea',  @filename1 = N'" + pathToDatbase + ConstantPath.DBFileMDF +
                        "', @filename2 = N'" + pathToDatbase + ConstantPath.DBPFileLDF + "'");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attach Database success!");

                    saveInfoConnect();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            ofd_path.Filter =
               "txt files (*.mdf)|*.mdf|All files (*.*)|*.*";
            ofd_path.InitialDirectory = ConstantPath.DBFileMDF;
            ofd_path.Title = "Select a database file";
            if (ofd_path.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd_path.SafeFileName;
                string fname = ofd_path.FileName.Replace(fileName, ""); ;
                txtPath.Text = fname;
                pathToDatbase = fname; 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void saveInfoConnect()
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            String strCon = ("server=" + server + ";" + "Trusted_Connection=yes;" +
                                          "database=" + database + "; " +
                                          "connection timeout=30");
            String strConTest = ("server=" + server + ";" + "Trusted_Connection=yes;" +
                                          "database=" + database + "; " +
                                          "connection timeout=5");
            if (testConnect(strConTest))
            {
                string path = Application.StartupPath + "\\Connection.DAT";
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(strCon);
                sw.Close();
                Application.Restart();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveInfoConnect();
        }

        private bool testConnect(String strCon)
        {
            try
            {
                SqlConnection Cnn = new SqlConnection(strCon);
                Cnn.Open();
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("You failed!" + ex.Message);
                return false;
            }
        }
    }
}
