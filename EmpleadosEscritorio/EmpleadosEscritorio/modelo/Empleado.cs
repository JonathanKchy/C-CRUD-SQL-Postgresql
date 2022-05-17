using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosEscritorio.modelo
{
    internal class Empleado
    {

		private string document;
        private string nombres;
        private string apellidos;
        private int edad;
        private string direccion;
        private string fecha_naciemiento;

        public Empleado()
        {
            this.document = "";
            this.nombres = "";
            this.apellidos = "";
            this.edad = 0;
            this.direccion = "";
            this.fecha_naciemiento = "";
        }

        public string Document { get => document; set => document = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Fecha_naciemiento { get => fecha_naciemiento; set => fecha_naciemiento = value; }
    }
}
