using EmpleadosEscritorio.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosEscritorio.datos
{
    internal class EmpleadoCAD
    {
        public static bool guardar(Empleado e)
        {
            try
            {
                Conexion con=new Conexion();
                string sql = "insert into tb_empleado values('" + e.Document + "','" + e.Nombres + "','" + e.Apellidos + "'," + e.Edad + ",'" + e.Direccion + "','" + e.Fecha_naciemiento + "')";
                SqlCommand comando = new SqlCommand(sql,con.Conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.Desconectar();
                    return true;
                }
                else
                {
                    con.Desconectar();
                    return false;
                }
                
                
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
