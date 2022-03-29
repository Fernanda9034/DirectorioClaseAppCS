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
            }
        }
    }
}
