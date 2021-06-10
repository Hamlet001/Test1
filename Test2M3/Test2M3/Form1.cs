using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test2M3.Model;

namespace Test2M3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        public Form1 ProductModel { get; private set; }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo f = new Catalogo();
            ProductModel = this;
            f.Text = "Form - " + this.MdiChildren.Length.ToString();
            f.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }

        }
    }
}
