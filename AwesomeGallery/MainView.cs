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
        private List<byte[]> pictures;
        public MainView()
        {
            InitializeComponent();
            selectedImages = new ImageList();
            pictures = new List<byte[]>();
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
                    pictures.Add(File.ReadAllBytes(files[0]));
                    using (var ms = new MemoryStream(pictures[i]))
                    {
                        selectedImages.Images.Add(openFileDialog1.SafeFileNames[i], Image.FromStream(ms));
                    }
                }
                using (var ms = new MemoryStream(pictures.ElementAt(0)))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
                selectedImages.ImageSize = new Size(100, 100);
                listView1.LargeImageList = selectedImages;
                List<string> names = new List<string>() { "1", "2" };
                int count = 0;
                foreach (string s in names)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.ImageIndex = count++;
                    listView1.Items.Add(lst);
                }
            }
        }

        //Menu exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //ListView item select
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainView_Load(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }


    }
}
