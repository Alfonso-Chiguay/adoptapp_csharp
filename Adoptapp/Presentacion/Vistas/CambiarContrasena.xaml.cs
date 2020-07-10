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
    /// Lógica de interacción para CambiarContrasena.xaml
    /// </summary>
    public partial class CambiarContrasena : Window
    {

        USUARIO user;
        public CambiarContrasena(USUARIO usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_actual.Password.Equals(user.USU_PASSWORD))
            {
                if (txt_nueva.Password.Equals(txt_repite.Password))
                {
                    if(txt_nueva.Password.Length < 2)
                    {
                        MessageBox.Show("La contraseña es muy corta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Con_Usuario control = new Con_Usuario();
                        control.cambiarContrasena(user.USU_RUT, txt_nueva.Password);
                        MessageBox.Show("Contraseña actualizada", "Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    
                }
                else
                    MessageBox.Show("La contraseña nueva no coincide en ambos campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else           
                MessageBox.Show("La contraseña no coincide con la actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }
    }
}
