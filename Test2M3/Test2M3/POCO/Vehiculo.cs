using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2M3.Enums;

namespace Test2M3.POCO
{
   public class Vehiculo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set;}
        public Brands  Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }

    }
}
