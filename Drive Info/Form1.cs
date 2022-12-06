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

namespace Drive_Info
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter fis = new StreamWriter("C:\\Users\\elev\\Desktop\\12c.txt");
            DriveInfo drive = new DriveInfo("C");

            const double BytesInMB = 1048576;
            const double BytesInGB = 1073741824;

            if (drive.IsReady)
            {
                double freeSpacePerc =
                    (drive.AvailableFreeSpace / (float)drive.TotalSize) * 100;

                fis.WriteLine("\nDrive: {0} ({1}, {2})",
                drive.Name, drive.DriveType, drive.DriveFormat);

                fis.WriteLine("\nUsed space:\t{0:0.00} MB\t{1:0.00} GB",
                    (drive.TotalSize - drive.TotalFreeSpace) / BytesInMB,
                    (drive.TotalSize - drive.TotalFreeSpace) / BytesInGB);

                fis.WriteLine("\nTotal size:\t{0:0.00} MB\t{1:0.00} GB",
                    drive.TotalSize / BytesInMB,
                    drive.TotalSize / BytesInGB);
            }
            fis.Close();

            richTextBox1.Text = System.IO.File.ReadAllText("C:\\Users\\elev\\Desktop\\12c.txt");
        }
    }
}
