using BaseDatos;
using BaseDatos.Controlador;
using Negocio;
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
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public RegistroUsuario()
        {
            InitializeComponent();
            
            Con_Region ctrlregion = new Con_Region();
            
            cb_region.ItemsSource = ctrlregion.listarRegiones();
        }
        
        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        Con_Comuna ctrlcomuna = new Con_Comuna();
        Con_Region ctrlregion = new Con_Region();
        private void cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id_region = cb_region.SelectedItem.ToString();
            cb_comuna.ItemsSource = ctrlcomuna.listarComunaPorRegion(ctrlregion.idRegion(id_region));
        }

        private void btn_registrarse_Click(object sender, RoutedEventArgs e)
        {
            bool intentar = true;
            USUARIO nuevo_usuario = new USUARIO();
            int rut;
            if (Int32.TryParse(txt_rut.Text, out rut))
                nuevo_usuario.RUT = rut;
            else
            {
                MessageBox.Show("Debe ingresar solo numero en el RUT", "Error en RUT", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }


            nuevo_usuario.DV = txt_dv.Text;
            nuevo_usuario.NOMBRE = txt_nombre_completo.Text;
            nuevo_usuario.CORREO = txt_email.Text;
            int telefono;
            if (Int32.TryParse(txt_telefono.Text, out telefono))
                nuevo_usuario.TELEFONO = telefono;
            else
            {
                MessageBox.Show("Debe ingresar solo numeros en el telefono", "Error en Telefono", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }

            nuevo_usuario.FECHA_NACIMIENTO = dp_fecha_nacimiento.SelectedDate.Value;
            if (cb_region.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una region", "Error en region", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }
            else
                nuevo_usuario.REGION = cb_region.SelectedItem.ToString();
            if (cb_comuna.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una comuna", "Error en comuna", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }
            else
                nuevo_usuario.COMUNA = cb_comuna.SelectedItem.ToString();
            if (txt_direccion.Text.Length < 5)
            {
                MessageBox.Show("Ingrese una direccion valida", "Error en direccion", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }
            else
                nuevo_usuario.DIRECCION = txt_direccion.Text;

            if (chk_tiene_mascota.IsChecked == true)
                nuevo_usuario.TIENE_MACOTA = true;
            else nuevo_usuario.TIENE_MACOTA = false;
            nuevo_usuario.USE_NAME = txt_usuario.Text;
            if (txt_password.Password.Equals(txt_password2.Password))
                nuevo_usuario.PASSWORD = txt_password.Password;
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error en contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                intentar = false;
            }

            if (intentar)
            {
                Validaciones validar = new Validaciones();
                int resultado = validar.validarNuevoUsuario(nuevo_usuario);
                if (resultado == 1)
                {

                    Con_Usuario crear = new Con_Usuario();
                    crear.registrarUsuario(nuevo_usuario);
                    MessageBox.Show("Usuario registrado con exito!", "Usuario creado", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
                else if(resultado == 0)
                    MessageBox.Show("Debe ingresar nombre completo", "Error en Nombre", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if(resultado == -1)
                    MessageBox.Show("El RUT no es valido", "Error en RUT", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (resultado == -2)
                    MessageBox.Show("El correo electronico no es valido", "Error en email", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (resultado == -3)
                    MessageBox.Show("Debes tener al menos 14 años", "Error en edad", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (resultado == -4)
                    MessageBox.Show("El telefono no es valido", "Error en telefono", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (resultado == -5)
                    MessageBox.Show("El nombre de usuario ya existe", "Usuario ya existe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
