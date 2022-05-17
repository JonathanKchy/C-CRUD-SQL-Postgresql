using EmpleadosEscritorio.datos;
using EmpleadosEscritorio.modelo;

namespace EmpleadosEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDocument.Text.Trim()=="")
            {
                MessageBox.Show("Debe ingresar un documento valido");
            }else if (txtNombre.Text.Trim().Length <5)
            {
                MessageBox.Show("Debe ingresar un nombre m'as largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Document = txtDocument.Text.Trim();
                    em.Nombres = txtNombre.Text.Trim();
                    em.Apellidos = txtApellido.Text.Trim();
                    em.Direccion = txtDireccion.Text.Trim();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Fecha_naciemiento = dtFecha.Value.Year + "-" + dtFecha.Value.Month + "-" + dtFecha.Value.Day;

                    if (EmpleadoCAD.guardar(em))
                    {
                        MessageBox.Show("Empleado guardado");
                    }else
                    {
                        MessageBox.Show("ya existe el mismo empleado");
                    }
                }
                catch (Exception exep)
                {

                    MessageBox.Show(exep.Message);
                }
            }
        }
    }
}