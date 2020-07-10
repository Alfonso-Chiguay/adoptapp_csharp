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
            txt_telefono.Text = usuario.USU_TELEFONO.ToString();
            user = usuario;
        }

        private void btn_cambiar_contrasena_Click(object sender, RoutedEventArgs e)
        {
            CambiarContrasena ventana = new CambiarContrasena(user);
            ventana.ShowDialog();
        }

        private void btb_editar_correo_Click(object sender, RoutedEventArgs e)
        {
            txtCorreo.IsEnabled = true;
        }


        Con_Comuna ctrlcomuna = new Con_Comuna();
        Con_Region ctrlregion = new Con_Region();
        int primeravez = 1;
        private void btn_editar_direccion_Click(object sender, RoutedEventArgs e)
        {
            txtDireccion.IsEnabled = true;
            lbl_comuna.Visibility = Visibility.Visible;
            lbl_region.Visibility = Visibility.Visible;
            cb_region.Visibility = Visibility.Visible;
            cb_comuna.Visibility = Visibility.Visible;
            cb_region.IsEnabled = true;        
                       
            cb_region.ItemsSource = ctrlregion.listarRegiones();

            Validaciones busca = new Validaciones();
            int idregion = busca.convertirIdComunaARegion(user.COM_ID_COMUNA);
            string region = ctrlregion.nombreRegion(idregion);
            cb_region.SelectedItem = region;

            cb_comuna.IsEnabled = false;           
            

        }

        private void cb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           cb_comuna.IsEnabled = true;
           string id_region = cb_region.SelectedItem.ToString();
           cb_comuna.ItemsSource = ctrlcomuna.listarComunaPorRegion(ctrlregion.idRegion(id_region));
            if (primeravez == 1)
            {
                cb_comuna.SelectedItem = user.COM_NOMBRE_COMUNA;
                primeravez = 2;
            }
                

            

        }

        private void btn_editar_telefono_Click(object sender, RoutedEventArgs e)
        {
            txt_telefono.IsEnabled = true;
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            bool exito = true;
            Validaciones validar = new Validaciones();
            if(txtCorreo.IsEnabled && txtCorreo.Text.Length > 6)
            {
                if (validar.emailValido(txtCorreo.Text))
                    user.USU_CORREO = txtCorreo.Text;
                else
                {
                    MessageBox.Show("El correo no es valido", "Error en correo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    exito = false;
                }
            }
            

            if(txtDireccion.IsEnabled && txtDireccion.Text.Length > 5)
            {
                if(cb_region.SelectedIndex>=0 && cb_comuna.SelectedIndex >= 0)
                {
                    user.USU_DIRECCION = txtDireccion.Text;
                    user.COM_NOMBRE_COMUNA = cb_comuna.SelectedItem.ToString();
                    user.COM_ID_COMUNA = ctrlcomuna.getComunaPorNombre(cb_comuna.SelectedItem.ToString()).COM_ID_COMUNA;
                }
                else
                {
                    MessageBox.Show("Error en la informacion de direccion/region/comuna, debe llenar todos los campos", "Error en direccion", MessageBoxButton.OK, MessageBoxImage.Warning);
                    exito = false;
                }
            }
           

            if (txt_telefono.IsEnabled && txt_telefono.Text.Length >= 8)
            {
                int telefono;
                if(Int32.TryParse(txt_telefono.Text, out telefono))
                {
                    user.USU_TELEFONO = telefono;
                }
                else
                {
                    MessageBox.Show("Ingrese un telefono valido", "Error en telefono", MessageBoxButton.OK, MessageBoxImage.Warning);
                    exito = false;
                }

            }
           

            if (exito)
            {
                Con_Usuario con_us = new Con_Usuario();
                con_us.actualizarUsuario(user);
                MessageBox.Show("Informacion actualizada", "Exito!!", MessageBoxButton.OK, MessageBoxImage.Information);
                Home ventana = new Home(user.USU_USERNAME);
                this.Close();
                ventana.ShowDialog();
                
            }

                
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Home ventana = new Home(user.USU_USERNAME);
            this.Close();
            ventana.ShowDialog();
            

        }
    }
}
