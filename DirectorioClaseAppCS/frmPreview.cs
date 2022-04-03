using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectorioClaseAppCS
{
    public partial class frmPreview : Form
    {
        public frmPreview()
        {
            InitializeComponent();
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
        }

        public Image PreviewImage
        {
            get { return this.pictureBox1.Image;  }
            set { this.pictureBox1.Image = value; }
        }

        private void frmPreview_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmPreview_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if ((e.KeyChar == 'w') || (e.KeyChar == 'W'))
            {
                y -= 10;
            }
            if ((e.KeyChar == 's') || (e.KeyChar == 'S'))
            {
                y += 10;
            }
            if ((e.KeyChar == 'a') || (e.KeyChar == 'A'))
            {
                x -= 10;
            }
            if ((e.KeyChar == 'd') || (e.KeyChar == 'D'))
            {
                x += 10;
            }
            Point nuevo = new Point(x, y);
            pictureBox1.Location = nuevo;
        }
    }
}
