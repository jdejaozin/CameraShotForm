using AForge.Video;
using AForge.Video.DirectShow;
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

namespace camerashotform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        private VideoCaptureDevice videoCapture;
        FilterInfoCollection filterInfo;
        void StartCamera()
        {
            try
            {
                filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoCapture = new VideoCaptureDevice(filterInfo[0].MonikerString);
                videoCapture.NewFrame += new NewFrameEventHandler(Camera_On);
                videoCapture.Start();
                Console.WriteLine("a");
            }
            catch (Exception e)
            {

            }
        }
        private void Camera_On(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartCamera();
        }
        int i = 1;
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void capture_Click(object sender, EventArgs e)
        {
            label1.Text = "Fotos tiradas = " + i + "/20";
            string path = @"C:\Test\";
            Directory.CreateDirectory(path);
            string fileName = path + i + ".jpg";
            i++;
            
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
            System.Drawing.Imaging.ImageFormat imageFormat = null;
            imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

            bitmap.Save(fileName);

            if(i > 20)
            {
                this.Invoke((Action)delegate
                {
                   capture.Enabled = false;
                });
                this.Invoke((Action)delegate
                {
                    button1.Enabled = true;
                });
            }
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
