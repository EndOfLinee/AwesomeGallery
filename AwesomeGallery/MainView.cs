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
        private ImageList selectedImages1;
        private List<byte[]> pictures;

        public MainView()
        {
            InitializeComponent();
            selectedImages = new ImageList();
            selectedImages1 = new ImageList();
            
            pictures = new List<byte[]>();
            listView1.MultiSelect = false;
        }
        public String[] files;
        public List<string> allFiles = new List<string>();
        

        //Menu Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (openFileDialog1.ShowDialog().ToString().Equals("OK"))
            {
                //if (listView1.Items.Count != 0)
                //{
                //    DialogResult result = MessageBox.Show("Clear gallery?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //    if ( result == DialogResult.Yes)
                //    {
                //        selectedImages.Dispose();
                //        selectedImages = new ImageList();
                //        listView1.Clear();
                //    }
                //}
                
                files = openFileDialog1.FileNames;
               
                if (files.Count() != 0)
                {
                    for (int i = 0; i < files.Count(); i++)
                    {
                        
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = i;
                        item.Text = Path.GetFileNameWithoutExtension(files[i]);

                        selectedImages.Images.Add(Image.FromFile(files[i]));
                        listView1.BeginUpdate();
                        listView1.Items.Add(item); 
                        listView1.EndUpdate();

                        allFiles.Add(files[i]);
                    }
                    this.listView1.View = View.LargeIcon;
                    this.selectedImages.ImageSize = new Size(50, 50);
                    this.listView1.LargeImageList = this.selectedImages;

                    pictureBox1.Image = Image.FromFile(files[0]);
                    
                 
                }

                //for (int i = 0; i < files.Length; i++)
                //{
                //    pictures.Add(File.ReadAllBytes(files[0]));
                //    using (var ms = new MemoryStream(pictures[i]))
                //    {
                //        selectedImages.Images.Add(openFileDialog1.SafeFileNames[i], Image.FromStream(ms));
                //    }
                //}

                //using (var ms = new MemoryStream(pictures.ElementAt(0)))
                //{
                //    pictureBox1.Image = Image.FromStream(ms);
                //}

                //selectedImages.ImageSize = new Size(50, 50);
                //listView1.LargeImageList = selectedImages;
                //List<string> names = new List<string>() { "1", "2" };
                //int count = 0;
                //foreach (string s in names)
                //{
                //    ListViewItem lst = new ListViewItem();
                //    lst.ImageIndex = count++;
                //    listView1.Items.Add(lst);
                //}
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
            int a = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    a = i;
                }
            }
            pictureBox1.Image = Image.FromFile(allFiles[a]);
        }

        private void MainView_Load(object sender, EventArgs e)
        {

           pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
           listView1.View = View.List;
         
        }

    


    }
}
