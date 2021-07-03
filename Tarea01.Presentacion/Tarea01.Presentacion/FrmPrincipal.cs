using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea01.Negocio;

namespace Tarea01.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // Método para listar las personas almacenadas en la base de datos dentro de la tabla personas.
        private void Listar()
        {
            try
            {
                DgvPrincipal.DataSource = NPersona.Listar();
                this.Formato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        // Método para optimizar el uso de mensaje de error.
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tarea 01", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Método para optimizar el uso de mensaje de información.
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Tarea 01", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Formato para mostrar en el DataGridView.
        private void Formato()
        {
            DgvPrincipal.Columns[0].Visible = false;
            DgvPrincipal.Columns[1].Width = 200;
            DgvPrincipal.Columns[2].Width = 200;
            DgvPrincipal.Columns[3].Width = 50;
            DgvPrincipal.Columns[4].HeaderText = "Teléfono";
            DgvPrincipal.Columns[4].Width = 200;
            DgvPrincipal.Columns[5].Visible = false;
        }

        // Función para limpiar los TextBox y resetear el valor del NumericUpDown a 1.
        private void Limpiar()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtTelefono.Clear();
            NudEdad.Value = 1;

            ErrorProvider.Clear();
        }

        // Programación para cuando carga el formulario. De momento solo usa el método de Listar para mostrar los datos al inicar el form.
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        // Programación del botón Ingresar.
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";

                if (TxtNombre.Text == string.Empty) ErrorProvider.SetError(TxtNombre, "Ingrese un nombre.");
                if (TxtNombre.Text == string.Empty) ErrorProvider.SetError(TxtApellido, "Ingrese un apellido.");
                
                if (TxtNombre.Text != string.Empty && TxtApellido.Text != string.Empty)
                {
                    Rpta = NPersona.Insertar(TxtNombre.Text.Trim(), TxtApellido.Text.Trim(), Convert.ToInt32(NudEdad.Value), TxtTelefono.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro.");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
