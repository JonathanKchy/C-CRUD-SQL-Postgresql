using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosEscritorio.datos
{
    internal class Conexion
    {
        SqlConnection con;
        public Conexion()
        {
            con = new SqlConnection("Server=DESKTOP-3CKFDQE;Database=empleado_db;integrated security=true");

        }

        public SqlConnection Conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public bool Desconectar()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
