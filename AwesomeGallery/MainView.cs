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

        public MainView()
        {
            InitializeComponent();
            selectedImages = new ImageList();            
            listView1.MultiSelect = false;
        }

        private void MainView_Load(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            listView1.View = View.List;

        }

        public String[] files;
        public int globalImageIndex = 0;

        //Menu Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFileDialog1.ShowDialog().ToString().Equals("OK"))
            {
                if (listView1.Items.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Clear gallery?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        clearGallery();
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        listView1.Items[selectedItemIndex].Selected = false;
                    }
                }

                files = openFileDialog1.FileNames;

                listView1.View = View.LargeIcon;
                selectedImages.ImageSize = new Size(50, 50);
                listView1.LargeImageList = this.selectedImages;

                if (files.Count() != 0)
                {
                    for (int i = 0; i < files.Count(); i++)
                    {
                        
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = globalImageIndex;
                        globalImageIndex++;
                        item.Tag = files[i];
                        item.Text = Path.GetFileNameWithoutExtension(files[i]);

                        selectedImages.Images.Add(Image.FromFile(files[i]));

                        listView1.BeginUpdate();
                        listView1.Items.Add(item); 
                        listView1.EndUpdate();

                    }                
                }
                pictureBox1.Image = null;
                if (listView1.Items.Count != 0)
                {
                    listView1.Items[selectedItemIndex].Selected = false;

                }
            }
        }

        //Menu exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        int selectedItemIndex = 0;
        //ListView item select
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedItemIndex = i;
                }
            }
            pictureBox1.Image = Image.FromFile(listView1.Items[selectedItemIndex].Tag.ToString());
           
        }

      

        public void clearGallery()
        {
            selectedImages.Dispose();
            selectedImages = new ImageList();

            listView1.Clear();
            listView1.Refresh();

            pictureBox1.Image = null;
            globalImageIndex = 0;
        }

        //Clear ALL 
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearGallery();
        }

        private void clearSelectedItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items[selectedItemIndex].Remove();
            selectedImages.Images[selectedItemIndex].Dispose();
            pictureBox1.Image = null;
        }

    


    }
}
