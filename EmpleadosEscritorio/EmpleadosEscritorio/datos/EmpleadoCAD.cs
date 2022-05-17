using EmpleadosEscritorio.modelo;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "select *from tb_empleado;";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.Desconectar();
                return dt;
                
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public static Empleado consultar(string documento)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = "select * from tb_empleado where documento='"+documento+"';";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader dr = comando.ExecuteReader();
                Empleado em=new Empleado();
                if (dr.Read())
                {
                    em.Document = dr["documento"].ToString();
                    em.Nombres = dr["nombres"].ToString();
                    em.Apellidos = dr["apellidos"].ToString();
                    em.Edad = Convert.ToInt32(dr["edad"].ToString());
                    em.Direccion = dr["direccion"].ToString();
                    em.Fecha_naciemiento = dr["fecha_naciemiento"].ToString();
                    con.Desconectar();
                    return em;
                }
                else
                {
                    con.Desconectar();
                    return null;
                }
                

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
