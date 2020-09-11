using System.Net.Http;
using System.Net;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MineCraft_Bedrock_Server_Manager.ServerControlHelpers
{
    public class Downloader
    {
        private readonly string _file;
        private readonly string localFile;
        private WebClient client;

        public Downloader(string file, string outfile)
        {
            _file = file;
            localFile = outfile;
        }

        public async Task BeginDownload(AsyncCompletedEventHandler downloadCompletedAction)
        {
            client = new WebClient();
            client.DownloadFileCompleted += downloadCompletedAction;
            await client.DownloadFileTaskAsync(new Uri(_file), localFile);
        }

        /*
        private void InstallPackage(string file)
        {
            // var installer = new PackageInstaller(file);
            // installer.ShowDialog(this);
            if (admin)
            {
                var info = new ProcessStartInfo(Application.StartupPath + @"\pkmgr.exe", file);
                info.Verb = "runas";
                Process.Start(info);
                DialogResult result = MessageBox.Show("Package Successfully Installed. Restart now to make changes ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Application.Restart();
                Close();
            }
            else
            {
                new PackageInstaller(file).Show(this);
            }
        }
        */
    }
}