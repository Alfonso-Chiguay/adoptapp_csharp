using BaseDatos;
using BaseDatos.Controlador;
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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        USUARIO usuario;
        public Home(string userName)
        {
            usuario = new USUARIO();
            InitializeComponent();
            Con_Usuario userDao = new Con_Usuario();
            usuario = userDao.getByUserName(userName);
            txtNombre.Text = usuario.NOMBRE;
            txtPublicaciones.Text = "2";
            txtFechaNacimiento.Text = usuario.FECHA_NACIMIENTO.ToShortDateString();
            txtDireccion.Text = usuario.DIRECCION;
            txtCorreo.Text = usuario.CORREO;
            txtComuna.Text = usuario.COMUNA;
            txtAdopciones.Text = "3";
        }

        private void btn_crear_publicacion_Click(object sender, RoutedEventArgs e)
        {
            CrearPublicacion ventana = new CrearPublicacion(usuario);
            ventana.ShowDialog();
        }
    }
}
