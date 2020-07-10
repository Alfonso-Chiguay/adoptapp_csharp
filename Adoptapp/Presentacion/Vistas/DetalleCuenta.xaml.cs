using BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion.Vistas
{
    /// <summary>
    /// Lógica de interacción para DetalleCuenta.xaml
    /// </summary>
    public partial class DetalleCuenta : Window
    {
        USUARIO user;
        public DetalleCuenta(USUARIO usuario)
        {
            
            InitializeComponent();
            txt_username.Text = usuario.USU_USERNAME;
            txtNombre.Text = usuario.USU_NOMBRE;
            txtCorreo.Text = usuario.USU_CORREO;
            txtFechaNacimiento.Text = usuario.USU_FECHA_NACIMIENTO.ToShortDateString();
            txtDireccion.Text = usuario.USU_DIRECCION;
            cb_comuna.Items.Add(usuario.COM_NOMBRE_COMUNA);
            cb_comuna.SelectedIndex = 0;
            txt_telefono.Text = usuario.USU_TELEFONO.ToString();
            user = usuario;
        }

        private void btn_cambiar_contrasena_Click(object sender, RoutedEventArgs e)
        {
            CambiarContrasena ventana = new CambiarContrasena(user);
            ventana.ShowDialog();
        }
    }
}
