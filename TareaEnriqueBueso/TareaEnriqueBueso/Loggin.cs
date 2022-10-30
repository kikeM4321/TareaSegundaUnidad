using Datos;
using Loggin;

namespace TareaEnriqueBueso
{
    public partial class Loggin : Form
    {
        public Loggin()
        {
            InitializeComponent();
        }

        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            if (CorreoTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(CorreoTextBox, "Ingrese su correo");
                CorreoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if(ContraseñaTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(ContraseñaTextBox, "Ingrese la contraseña correcta");
                ContraseñaTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            DatosPrincipales userDatos = new DatosPrincipales();
            bool valido = await userDatos.LoginAsync(CorreoTextBox.Text, ContraseñaTextBox.Text);

            if (valido)
            {
                MenuAcceso formulario = new MenuAcceso();
                Hide();
                formulario.Show();



            }
            else
            {
                MessageBox.Show("Datos de Usuarios incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}