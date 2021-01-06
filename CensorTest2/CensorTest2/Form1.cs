using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CensorTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.TransparencyKey = Color.LimeGreen;
            //this.BackColor = Color.LimeGreen;
        }

        private void CaptureMyScreen()

        {

            try

            {

                //Creating a new Bitmap object

                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);


                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

                //Creating a Rectangle object which will  

                //capture our Current Screen

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                //Creating a New Graphics Object

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                //Copying Image from The Screen

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);


                //Saving the Image File (I am here Saving it in My E drive).
                if (System.IO.File.Exists(@"C:\Capture.png"))
                {
                    using (FileStream fs = new FileStream(@"C:\Capture.png", FileMode.Open))
                    {
                        pictureBox1.Image = Image.FromStream(fs);
                        fs.Close();
                    }

                }



                captureBitmap.Save(@"C:\Capture.png", ImageFormat.Png);


                //Displaying the Successfull Result

                MessageBox.Show("Screen Captured");

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //this.BackgroundImage = Resource1.Capture;
        //    pictureBox1.Image = Image.FromFile(@"C:\Capture.png");
        //    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
          
        }

       
    }
}
