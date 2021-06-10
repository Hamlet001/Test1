using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2M3.POCO;

namespace Test2M3.Model
{
    public class VehiculoModel
    {
       
        public VehiculoModel() { }
        public Vehiculo[] Vehiculos;


        public void Add(Vehiculo Emp)
        {
            if (Vehiculos == null)
            {
                Vehiculos = new Vehiculo[1];
                Vehiculos[0] = Emp;
                return;
            }
            Vehiculo[] tmp = new Vehiculo[Vehiculos.Length + 1];
            Array.Copy(Vehiculos, tmp, Vehiculos.Length);
            tmp[tmp.Length - 1] = Emp;

            Vehiculos = tmp;
        }

        public Vehiculo[] getAll()
        {
            return Vehiculos;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                return;
            }
            if (Vehiculos == null)
            {
                return;
            }
            if (index >= Vehiculos.Length)
            {
                throw new IndexOutOfRangeException($"El index {index} esta fuera del rango");
            }
            if (index == 0 && Vehiculos.Length == 1)
            {
                Vehiculos = null;
                return;
            }
            Vehiculo[] tmp = new Vehiculo[Vehiculos.Length - 1];
            if (index == 0)
            {
                Array.Copy(Vehiculos, index + 1, tmp, 0, tmp.Length);
                Vehiculos = tmp;
                return;
            }
            if (index == Vehiculos.Length - 1)
            {
                Array.Copy(Vehiculos, 0, tmp, 0, tmp.Length);
                Vehiculos = tmp;
                return;
            }

            Array.Copy(Vehiculos, 0, tmp, 0, index);
            Array.Copy(Vehiculos, index + 1, tmp, index, (tmp.Length - index - 1));
        }

    }
}