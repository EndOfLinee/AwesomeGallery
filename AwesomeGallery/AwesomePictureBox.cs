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
        private Image safeCopy;
        public AwesomePictureBox()
        {
        }

        public Image getSafeSrc()
        {
            return safeCopy;
        }
        public void setImage(Image set)
        {
            if (set != null)
            {
                safeCopy = set;
                double z1 = (safeCopy.Width > this.Width) ? this.Width / (double)safeCopy.Width : 1.0;
                double z2 = (safeCopy.Height > this.Height) ? this.Height / (double)safeCopy.Height : 1.0;
                if (z1 < 1.0 || z2 < 1.0)
                {
                    if (z1 < z2)
                    {
                        zoom = z1;
                    }
                    else
                    {
                        zoom = z2;
                    }
                }
                else
                {
                    zoom = 1.0;
                }
                handleZoom();
            }
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("TEst");
        }

        public void handleZoom()
        {
            Bitmap newImage = new Bitmap(safeCopy, new Size((int)(safeCopy.Size.Width * zoom), (int)(safeCopy.Size.Height * zoom)));
            this.Image = (Image)newImage;
        }


        public void zoomIn()
        {

            if (this.Image != null)
            {
                if (this.Height > (int)(safeCopy.Size.Height * zoom) && this.Width > (int)(safeCopy.Size.Width * zoom))
                {
                    zoom *= 1.5;
                    handleZoom();
                }
            }

        }

        public void zoomOut()
        {
            if (this.Image != null)
            {
                if (zoom > 0.01)
                {
                    zoom /= 1.5;
                    handleZoom();
                }
            }

        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Image != null)
            {
                Console.Write(this.Height * zoom + " " + this.Width);
            }
            base.OnPaint(pe);
        }
    }
}
