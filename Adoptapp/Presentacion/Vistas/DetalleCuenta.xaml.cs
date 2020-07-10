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
           

            

        }
    }
}
