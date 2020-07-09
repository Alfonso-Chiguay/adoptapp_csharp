using BaseDatos;
using BaseDatos.Controlador;
using Presentacion.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_registarse_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuario ventana = new RegistroUsuario();
            ventana.ShowDialog();

        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Con_Usuario user = new Con_Usuario();
            if (!user.inicioSesion(txt_usuario.Text, txt_password.Password))
                MessageBox.Show("Datos incorrectos", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Datos correctos", "Acceso correcto", MessageBoxButton.OK, MessageBoxImage.Information);
            Home home = new Home(txt_usuario.Text);
            this.Close();
            home.ShowDialog();
            
        }
    }
}
