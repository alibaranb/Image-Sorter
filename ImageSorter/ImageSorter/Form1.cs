using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(label1.Text);

                MessageBox.Show(files.Length.ToString() + " files found!", "Message");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {       
            string[] directoryList = Directory.GetFiles(label1.Text);

            foreach (string file in directoryList) {
                FileInfo fileInfo = new FileInfo(file);

                DateTime dateTime = fileInfo.LastWriteTime;
                
                String date = dateTime.ToString("yyyy-MM");
                String DestPath = label1.Text + @"\" + date;

                    //FOLDER CREATING AND MOVING
                   
                        Directory.CreateDirectory(DestPath);
                        fileInfo.MoveTo(DestPath + @"\" + fileInfo.Name);

                }
            }
        }
    }