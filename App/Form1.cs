using System;
using System.Drawing;
using System.Windows.Forms;
using LAB_3;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadAndDisplayImage();

        }
        private void LoadAndDisplayImage()
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                Bitmap image = new Bitmap(filename);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = image;
            }
        }


        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //pictureBox1.Image = Image.FromFile(@"../../../piesek.jpg");
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap originalImage1 = new Bitmap(pictureBox1.Image);
            Bitmap originalImage2 = new Bitmap(pictureBox1.Image);
            Bitmap originalImage3 = new Bitmap(pictureBox1.Image);
            Bitmap originalImage4 = new Bitmap(pictureBox1.Image);

            Thread[] threads = new Thread[4];

            threads[0] = new Thread(() =>
            {
                Bitmap originalImage3 = SetGrayscale(originalImage1);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = originalImage3;

            });

            threads[1] = new Thread(() =>
            {
                ApplyInvertFilter(originalImage2);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = originalImage2;

            });

            threads[2] = new Thread(() =>
            {
                Bitmap original1 = ApplyGreenFilter(originalImage3);
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.Image = original1;

            });
            threads[3] = new Thread(() =>
            {
                Bitmap original2 = ApplyRedFilter(originalImage4);
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox5.Image = original2;

            });

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Bitmap ApplyRedFilter(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color newPixel = Color.FromArgb(255, pixel.G, pixel.B); 
                    result.SetPixel(x, y, newPixel);
                }
            }

            return result;
        }

        private Bitmap ApplyGreenFilter(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color newPixel = Color.FromArgb(pixel.R, 255, pixel.B); 
                    result.SetPixel(x, y, newPixel);
                }
            }

            return result;
        }

        public Bitmap SetGrayscale(Bitmap image)
        {
            Bitmap temp = (Bitmap)image.Clone();

            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    Color c = temp.GetPixel(i, j);

                    byte gray = (byte)(.10 * c.R + .587 * c.G + .114 * c.B);

                    temp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            return temp;
        }

        private void ApplyInvertFilter(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);

                    Color invertedColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);

                    image.SetPixel(i, j, invertedColor);
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_2(object sender, EventArgs e)
        {

        }
    }
}











/* private void pictureBox1_Click(object sender, EventArgs e)
         {
             try
             {
                 OpenFileDialog openFileDialog = new OpenFileDialog();
                 openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                 openFileDialog.FilterIndex = 1;

                 if (openFileDialog.ShowDialog() == DialogResult.OK)
                 {
                     string filename = openFileDialog.FileName;
                     Bitmap image = new Bitmap(filename);

                     pictureBox1.Image = image;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Wyst¹pi³ b³¹d podczas wczytywania obrazu: " + ex.Message);
             }
         }*/
//**********STARY KOD***********//
//Bitmap originalImage = new Bitmap(pictureBox1.Image);

// Przefiltrowanie obrazu
//ApplyInvertFilter(originalImage);

// Wyœwietlenie przefiltrowanego obrazu w PictureBox2
//pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
//pictureBox2.Image = originalImage;

////////////////////////////////////////////////////

//Bitmap originalImage2 = new Bitmap(pictureBox1.Image);

// Przefiltrowanie obrazu i przypisanie przefiltrowanego obrazu do originalImage2
//originalImage2 = SetGrayscale(originalImage2);

// Wyœwietlenie przefiltrowanego obrazu w PictureBox2
//pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
//pictureBox3.Image = originalImage2;