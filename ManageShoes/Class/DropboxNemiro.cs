using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemiro.OAuth;
using Nemiro.OAuth.LoginForms;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ManageShoes.Class
{
    public class DropboxNemiro
    {
        String consumerKey, consumerSecret;
        Uri uri;
        MainForm mainForm;
        OptionForm optionForm;

        //Dropbox
        String CurrentPath = "/";
        List<UniValue> drop_Files = new List<UniValue>();

        public DropboxNemiro(MainForm mainForm, OptionForm optionForm)
        {
            if (mainForm != null)
            {
                this.mainForm = mainForm;
            }
            if (optionForm != null)
            {
                this.optionForm = optionForm;
            }
            consumerKey = "9sd472e7xntjrd6";
            consumerSecret = "2w4fs2o2i3fgnju";
            
        }

        public void LoadDropbox()
        {
            Properties.Settings.Default.AccessToken = null;
            if (String.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
            {
                this.GetAccessToken();
            }
            else
            {
                this.GetFiles();
            }
        }

        private void GetAccessToken()
        {
            var login = new DropboxLogin(consumerKey, consumerSecret);
            login.Owner = optionForm;
            login.ShowDialog();

            if (login.IsSuccessfully)
            {
                Properties.Settings.Default.AccessToken = login.AccessToken.Value;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Error AccessToken");
            }
        }

        private void GetFiles()
        {
            OAuthUtility.GetAsync
                (
                    "https://api.dropboxapi.com/1/metadata/auto/",
                    new HttpParameterCollection
                    {
                        {"path", this.CurrentPath},
                        {"access_token", Properties.Settings.Default.AccessToken}
                    },
                    callback: GetFiles_Result
                );
        }

        private void GetFiles_Result(RequestResult result)
        {
            if (optionForm != null)
            {
                if (optionForm.InvokeRequired)
                {
                    optionForm.Invoke(new Action<RequestResult>(GetFiles_Result), result);
                    return;
                }
            }
            else
            {
                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new Action<RequestResult>(GetFiles_Result), result);
                    return;
                }
            }

            if (result.StatusCode == 200)
            {
                foreach (UniValue file in result["contents"])
                {
                    drop_Files.Add(file["path"]);
                }
                if (optionForm != null)
                {
                    optionForm.cbTimeSync.Enabled = true;
                    optionForm.btnOk.Enabled = true;
                    MessageBox.Show("Login success! Go to Step 2.");
                }
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }

        public void createFolder(String folderPath)
        {
            OAuthUtility.PostAsync
                (
                    "https://api.dropboxapi.com/1/fileops/create_folder",
                    new HttpParameterCollection
                    {
                        {"access_token", Properties.Settings.Default.AccessToken},
                        {"root", "auto"},
                        {"path", Path.Combine(this.CurrentPath, folderPath).Replace("\\","/")}
                    },
                    callback: CreateFolder_Result
                );
        }

        private void CreateFolder_Result(RequestResult result)
        {
            if (optionForm.InvokeRequired)
            {
                optionForm.Invoke(new Action<RequestResult>(CreateFolder_Result), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                this.GetFiles();
            }
            else
            {
                if (result["error"].HasValue)
                {
                    MessageBox.Show(result["error"].ToString());
                }
                else
                {
                    MessageBox.Show("Error...");
                }
            }
        }
        
        public void uploadFileToDropbox(String pathFile)
        {
            //if (mainForm.openFileDialog1.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            OAuthUtility.PutAsync
                (
                    "https://content.dropboxapi.com/1/files_put/auto/",
                    new HttpParameterCollection
                    {
                       {"access_token", Properties.Settings.Default.AccessToken},
                       //{"path", Path.Combine(this.CurrentPath, Path.GetFileName(mainForm.openFileDialog1.FileName)).Replace("\\","/")},
                       {"path", Path.Combine(this.CurrentPath, Path.GetFileName(pathFile)).Replace("\\","/")},
                       {"overwrite", "true"},
                       {"autorename", "true"},
                       //{mainForm.openFileDialog1.OpenFile()}
                       {new FileStream(pathFile, FileMode.Open)}
                    },
                    callback: Upload_Result
                );
        }

        private void Upload_Result(RequestResult result)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action<RequestResult>(Upload_Result), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                this.GetFiles();
                //MessageBox.Show("Sync success!");
            }
            else
            {
                if (result["error"].HasValue)
                {
                    MessageBox.Show(result["error"].ToString());
                }
                else
                {
                    MessageBox.Show("Error...");
                }
            }
        }

        public void downloadFileVersionFromDropbox()
        {
            if (drop_Files.Count == 0)
            {
                this.GetFiles();
            }
            else
            {
                //mainForm.saveFileDialog1.FileName = Path.GetFileName(drop_Files[0].ToString());
                //if (mainForm.saveFileDialog1.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}
                foreach (UniValue file in drop_Files)
                {
                    if (Path.GetFileName(file.ToString()).Equals(ConstantPath.verJson))
                    {
                        var web = new WebClient();
                        UniValue str1 = file;
                        String str2 = Properties.Settings.Default.AccessToken;
                        String url = String.Format("https://content.dropboxapi.com/1/files/auto" + str1 + "?access_token=" + str2);
                        web.DownloadProgressChanged += DownloadProgressChange;
                        //web.DownloadFileAsync(new Uri(url), ConstantPath.jsonPath + Path.GetFileName(file.ToString()));
                        web.DownloadFile(new Uri(url), ConstantPath.jsonPath + Path.GetFileName(file.ToString()));
                    }
                }
            }
        }

        public void downloadFileFromDropbox()
        {
            if (drop_Files.Count == 0)
            {
                this.GetFiles();
            }
            else
            {
                //mainForm.saveFileDialog1.FileName = Path.GetFileName(drop_Files[0].ToString());
                //if (mainForm.saveFileDialog1.ShowDialog() != DialogResult.OK)
                //{
                //    return;
                //}
                foreach (UniValue file in drop_Files)
                {
                    var web = new WebClient();
                    UniValue str1 = file;
                    String str2 = Properties.Settings.Default.AccessToken;
                    String url = String.Format("https://content.dropboxapi.com/1/files/auto" + str1 + "?access_token=" + str2);
                    web.DownloadProgressChanged += DownloadProgressChange;
                    //web.DownloadFileAsync(new Uri(url), ConstantPath.jsonPath + Path.GetFileName(file.ToString()));
                    web.DownloadFile(new Uri(url), ConstantPath.jsonPath + Path.GetFileName(file.ToString()));
                }
            }
        }

        private void DownloadProgressChange(object sender, DownloadProgressChangedEventArgs e)
        {
            mainForm.progressBar1.Value = e.ProgressPercentage;
        }
    
    }
}
