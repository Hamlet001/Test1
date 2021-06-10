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
using Test2M3.Enums;
using Test2M3.POCO;

namespace Test2M3
{
    public partial class Catalogo : Form
    {
        public string Busqueda = "";
        public VehiculoModel TModel { get; private set; }
        public Catalogo()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void LoadComponents()
        {
            TModel = new VehiculoModel();
            dgvVehicle.ReadOnly = true;
            dgvVehicle.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvVehicle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVehicle.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Buscador(Busqueda);
        }

        public void Buscador(string Buscador)
        {
            Buscador = txtSearch.Text;
            try
            {
                foreach (DataGridViewRow Row in dgvVehicle.Rows)
                {
                    foreach (DataGridViewCell Cell in Row.Cells)
                    {
                        if (Cell.Value.ToString() == Buscador)
                        {
                            dgvVehicle.CurrentCell = Cell;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }




        private void BtnAdd1_Click(object sender, EventArgs e)
        {
            AddProd frm = new AddProd();
            frm.TModel = TModel;
            frm.Show();
        }

        private void btnEliminate_Click(object sender, EventArgs e)
        {
            if (dgvVehicle.Rows.Count == 0)
            {
                return;
            }
            int index = dgvVehicle.CurrentCell.RowIndex;
            TModel.Remove(index);
            dgvVehicle.DataSource = TModel.getAll();
        }

        private void dgvVehicle_Click(object sender, EventArgs e)
        {
            dgvVehicle.DataSource = TModel.getAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AddProd frm = new AddProd();
            frm.TModel = TModel;
            frm.Show();
        }
    }
}
