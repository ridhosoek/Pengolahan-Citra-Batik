using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;

namespace BATIK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseCitra_Click(object sender, EventArgs e)
        {
            OpenFileDialog pemilihFile = new OpenFileDialog();
            pemilihFile.RestoreDirectory = true;

            if (pemilihFile.ShowDialog() == DialogResult.OK)
            {
             //untuk mengambil citra
                this.pictureBoxcitra.Image = new Bitmap(new Bitmap(pemilihFile.FileName), 400, 400);
                this.Invalidate();
            }
        }

        private void btnProsesGrascale_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.pictureBoxcitra.Image);

            int width = bmp.Width;
            int height = bmp.Height;

            Color p;
            //buat perulangan sebanyak tinggi dan lebarnya citra
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //find average
                    int avg = (r + g + b) / 3;

                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            pictureBoxGrayscale.Image = bmp;
            bmp.Save("C:\\Users\\ASUS\\Pictures\\BATIK\\Grayscale.jpg");
        }

        private void btnBiner_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.pictureBoxGrayscale.Image);

            int width = bmp.Width;
            int height = bmp.Height;

            Color p;

            int i;
            int trheshold = 100;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    i = p.R;

                    if (i >= trheshold)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBoxBiner.Image = bmp;
            bmp.Save("C:\\Users\\ASUS\\Pictures\\BATIK\\Biner.png");
        }

        private void btnProsesdilasi_Click(object sender, EventArgs e)
        {

        }



        
    }
}
