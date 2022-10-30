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

            if(Contrase�aTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(Contrase�aTextBox, "Ingrese la contrase�a correcta");
                Contrase�aTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            DatosPrincipales userDatos = new DatosPrincipales();
            bool valido = await userDatos.LoginAsync(CorreoTextBox.Text, Contrase�aTextBox.Text);

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