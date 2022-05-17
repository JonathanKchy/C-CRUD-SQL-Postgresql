using EmpleadosEscritorio.datos;
using EmpleadosEscritorio.modelo;
using System.Data;

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
            llenarGrid();
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
                        llenarGrid();
                        limpiarDatos();
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

        private void llenarGrid()
        {
            DataTable datos=EmpleadoCAD.listar();
            if (datos==null)
            {
                MessageBox.Show("no se logró");
            }
            else
            {
                dtgLista.DataSource = datos.DefaultView;
            }
        }

        private void limpiarDatos()
        {
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtDocument.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDocument.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento valido");
            }
            else
            {
                Empleado em=EmpleadoCAD.consultar(txtDocument.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("No existe el empleado: "+txtDocument.Text);
                }
                else
                {
                    txtApellido.Text = em.Apellidos;
                    txtDireccion.Text = em.Direccion;
                    txtDocument.Text = em.Document;
                    txtEdad.Text = em.Edad.ToString();
                    txtNombre.Text = em.Nombres;
                    dtFecha.Text = em.Fecha_naciemiento;
                }
            }
        }
    }
}