using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeGallery
{
    public partial class MainView : Form
    {
        private ImageList selectedImages;
        private byte[] image;
        public MainView()
        {
            InitializeComponent();
            selectedImages = new ImageList();
        }

        //Menu Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog1.ShowDialog().ToString().Equals("OK"))
            {
                String[] files = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    selectedImages.Images.Add(openFileDialog1.SafeFileNames[i], Image.FromFile(files[i]));
                }
                image = File.ReadAllBytes(files[0]);
                Image myImage;
                using (var ms = new MemoryStream(image))
                {
                    myImage = Image.FromStream(ms);
                }
                listView1.LargeImageList = selectedImages;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = myImage;
            }
        }

        //Menu exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
