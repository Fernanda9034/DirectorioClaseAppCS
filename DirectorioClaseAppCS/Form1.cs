using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DirectorioClaseAppCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }
        public void ChooseFolder()
        {
            FolderBrowserDialog dialogo = new FolderBrowserDialog();
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = dialogo.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(dialogo.SelectedPath);

                treeView1.AfterSelect += TreeView1_AfterSelect;
                LlenarArbol(di, treeView1.Nodes);
            }
        }
        private void LlenarArbol(DirectoryInfo di, TreeNodeCollection tnc)
        {
            TreeNode nodo = tnc.Add(di.Name);
            foreach (FileInfo archivo in di.GetFiles())
            {
                nodo.Nodes.Add(archivo.FullName, archivo.Name);
            }
            foreach (DirectoryInfo sdi in di.GetDirectories())
            {
                LlenarArbol(sdi, nodo.Nodes);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Node.Name.EndsWith("txt") || e.Node.Name.EndsWith("cs"))
            {
                richTextBox1.Clear();
                StreamReader lector = new StreamReader(e.Node.Name);
                richTextBox1.Text = lector.ReadToEnd();
                lector.Close();
                pictureBox1.Visible = false;
                richTextBox1.Visible = true;
            }
            if (e.Node.Name.EndsWith("png") || e.Node.Name.EndsWith("jpg") || e.Node.Name.EndsWith("gif"))
            {
                pictureBox1.Load(e.Node.Name);
                pictureBox1.Visible = true;
                richTextBox1.Visible = false;
            }
        }
        private void frmMain_Load(object sender, TreeViewEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(e.Node.Name);
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            frmPreview f = new frmPreview();
            f.PreviewImage = pictureBox1.Image;
            f.Show();
        }
    }
}
