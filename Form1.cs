using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Microsoft.WindowsAPICodePack.Dialogs;
using RestSharp;
using System.Diagnostics;
using System.Threading;

namespace FortS13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.exchange.Text = ((RestResponseBase)new RestClient("https://e01a4dfd-fc0a-4703-a22a-cd2bc83bfaf1.id.repl.co/").Execute(new RestRequest("/exchange?code=" + this.exchange.Text, (Method)0))).Content;
            if (this.exchange.Text.ToString() == "[]")
            {
                int num = (int)MessageBox.Show("The authorization code you supplied was invalid, please try again with a valid code!");
            }
            else
            {
                CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
                commonOpenFileDialog.Title = "Please select the path for 13.40";
                commonOpenFileDialog.IsFolderPicker = true;
                commonOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                commonOpenFileDialog.AddToMostRecentlyUsedList = false;
                commonOpenFileDialog.AllowNonFileSystemItems = false;
                commonOpenFileDialog.DefaultDirectory = "Desktop";
                commonOpenFileDialog.EnsureFileExists = true;
                commonOpenFileDialog.EnsurePathExists = true;
                commonOpenFileDialog.EnsureReadOnly = false;
                commonOpenFileDialog.EnsureValidNames = true;
                commonOpenFileDialog.Multiselect = false;
                commonOpenFileDialog.ShowPlacesList = true;
                if (commonOpenFileDialog.ShowDialog() != CommonFileDialogResult.Ok)
                    return;
                string fileName1 = commonOpenFileDialog.FileName;
                string str1 = fileName1 + "\\FortniteGame\\Binaries\\Win64";
                if (!System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                {
                    int num = (int)MessageBox.Show("The path selected does not have Fortnite installed correctly: " + fileName1 + "\\nPlease retry with a valid path");
                }
                if (!System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                    return;
                WebClient webClient = new WebClient();
                string fileName2 = fileName1 + "\\FortniteGame\\Binaries\\Win64\\aurora.dll";
                string fileName3 = fileName1 + "\\FortniteGame\\Binaries\\Win64\\FNTools.dll";
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/954515979658989588/1016770179000176640/FortniteTools.dll", fileName3);
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/876462386662494258/1020693774717943898/Aurora.Runtime.dll", fileName2);
                string fileName4 = System.IO.Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
                string str2 = System.IO.Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe");
                string str3 = System.IO.Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe");
                string arguments = "-AUTH_LOGIN=unused -AUTH_PASSWORD=" + this.exchange.Text + " -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -nobe -noeac -fromfl=eac -fltoken=3db3ba5dcbd2e16703f3978d -caldera=eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm-j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ - skippatchcheck";
                Process process1 = new Process()
                {
                    StartInfo = new ProcessStartInfo(fileName4, arguments)
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                Process process2 = new Process();
                process2.StartInfo.FileName = str3;
                process2.Start();
                Process process3 = new Process();
                process3.StartInfo.FileName = str2;
                process3.StartInfo.Arguments = "-epiclocale = en - nobe -noeac - fromfl = eac - fltoken = 3db3ba5dcbd2e16703f3978d - caldera = eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm - j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ";
                process3.Start();
                process1.Start();
                Thread.Sleep(2000);
                Thread.Sleep(6000);
                System.IO.File.Delete(fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe");
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/823233042788122685/828311722036690984/Injector.exe", fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe");
                process1.WaitForInputIdle();
                new Process()
                {
                    StartInfo = {
            Arguments = string.Format("\"{0}\" \"{1}\"", (object) process1.Id, (object) fileName2),
            CreateNoWindow = true,
            UseShellExecute = false,
            FileName = (fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe")
          }
                }.Start();
                Thread.Sleep(10);
                Thread.Sleep(60000);
                new Process()
                {
                    StartInfo = {
            Arguments = string.Format("\"{0}\" \"{1}\"", (object) process1.Id, (object) fileName3),
            CreateNoWindow = true,
            UseShellExecute = false,
            FileName = (fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe")
          }
                }.Start();
                process1.WaitForExit();
                try
                {
                    process2.Close();
                    process3.Close();
                }
                catch
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://rebrand.ly/authcode");
        }
    }
}