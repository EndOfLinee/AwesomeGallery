using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeGallery
{
    class AwesomePictureBox : PictureBox
    {
        private double zoom = 1.0;
        public AwesomePictureBox()
        {
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("TEst");
        }


        public void zoomIn()
        {
            zoom *= 2 ;
        }

        public void zoomOut()
        {
            zoom /= 2;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Image != null)
            {
                this.Height = (int)(this.Image.Size.Width);
                this.Width = (int)(this.Image.Size.Height);
                Console.Write(this.Height * zoom + " " + this.Width);
            }
            base.OnPaint(pe);
        }
    }
}
