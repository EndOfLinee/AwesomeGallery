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

        public AwesomePictureBox()
        {
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("TEst");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Image!=null)
            {
                double aspect = this.Image.Size.Width * 1.0 / this.Image.Size.Height;
                this.Height = this.Image.Size.Height;
                this.Width = this.Image.Size.Width;
            }
            base.OnPaint(pe);
        }
    }
}
