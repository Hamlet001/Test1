using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test2M3.Enums;
using Test2M3.Model;
using Test2M3.POCO;

namespace Test2M3
{
    public partial class AddProd : Form
    {
        public Catalogo Catalogo;
        public VehiculoModel TModel { get; set; }
        public AddProd()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void LoadComponents()
        {
            Catalogo = new Catalogo();
            TModel = new VehiculoModel();
            cmbBrands.Items.AddRange(Enum.GetValues(typeof(Brands)).Cast<Object>().ToArray());
            cmbBrands.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBrands.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                int Id = r.Next(0, 100);
                string Nombre = txtName.Text;
                int Existencia = Int32.Parse(txtStock.Text);
                int index = cmbBrands.SelectedIndex;
                Brands Marca = (Brands)Enum.GetValues(typeof(Brands)).GetValue(index);
                string Modelo = txtModel.Text;
                decimal.TryParse(txtPrice.Text, out decimal Precio);
                string Descripcion = txtDescription.Text;
                string Imagen = txtImagePATH.Text;
                ValidateVehiculo(Nombre, Existencia, out Precio, Modelo);

                Vehiculo T = new Vehiculo()
                {
                    ID = Id,
                    Nombre = Nombre,
                    Existencia = Existencia,
                    Marca = Marca,
                    Modelo = Modelo,
                    Precio = Precio,
                    Descripcion = Descripcion,
                    ImagePath = Imagen,
                };

                TModel.Add(T);
                MessageBox.Show("El Vehiculo ha sido agregado!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void ValidateVehiculo(string Nombre, int NoExistencias, out decimal Precio, string Modelo)
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new ArgumentException("El nombres es requerido!!");
            }
            if (!int.TryParse(txtStock.Text, out int No))
            {
                throw new ArgumentException("El No. de productos es inválido!!");
            }
            NoExistencias = No;
            if (!decimal.TryParse(txtPrice.Text, out decimal PrecioT))
            {
                throw new ArgumentException($"El salario '{txtPrice.Text}' es inválido");
            }
            Precio = PrecioT;
            if (string.IsNullOrWhiteSpace(Modelo))
            {
                throw new ArgumentException("El modelo es requerido!!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            if (Imagen.ShowDialog() == DialogResult.OK)
            {
                txtImagePATH.Text = Imagen.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}
