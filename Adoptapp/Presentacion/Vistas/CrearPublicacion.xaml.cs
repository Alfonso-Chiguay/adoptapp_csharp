using BaseDatos;
using BaseDatos.Controlador;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para CrearPublicacion.xaml
    /// </summary>
    public partial class CrearPublicacion : Window
    {
        
        public CrearPublicacion(string user)
        {
            InitializeComponent();
            Con_Usuario c_user = new Con_Usuario();
            USUARIO usuario = c_user.getByUserName(user);
            lbl_publicador.Content = usuario.USU_NOMBRE;
            lbl_telefono.Content = usuario.USU_TELEFONO;
            cb_mascota.Items.Add("Perro");
            cb_mascota.Items.Add("Gato");
            cb_mascota.Items.Add("Ave");
            cb_mascota.Items.Add("Tortuga");
            lbl_user.Content = user;
        }



        private void btn_seleccionar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
                
        

            if (openFileDialog1.ShowDialog() == true)
            {
                lbl_ruta.Content = openFileDialog1.FileName;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(lbl_ruta.Content.ToString());
                img.EndInit();
                img_subida.Source = img;
            }

            
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            PUBLICACION pub = new PUBLICACION();
            bool exito = true;
            MASCOTA mascota = new MASCOTA();
            Con_Mascota c_masc = new Con_Mascota();
            Con_Publicacion c_pub = new Con_Publicacion();
            Con_Usuario c_user = new Con_Usuario();
            USUARIO usuario = c_user.getByUserName(lbl_user.Content.ToString());
            
            
            
            if (!txt_mascota.Text.Equals(""))
            {
                mascota.MAS_NOMBRE = txt_mascota.Text;
                pub.MAS_NOMBRE = txt_mascota.Text;
            }
                
            else
                exito = false;
            if (cb_mascota.SelectedIndex != -1)
                mascota.MAS_TIPO = cb_mascota.SelectedItem.ToString();
            else
                exito = false;
            
            mascota.MAS_ID_MASCOTA = c_masc.siguienteId();
            
            int edad;
            if (Int32.TryParse(txt_edad.Text, out edad))
                mascota.MAS_EDAD = edad;
            else
                exito = false;



            if (!txt_descripcion.Text.Equals(""))
                pub.PUB_DESCRIPCION = txt_descripcion.Text;
            else
                exito = false;

            int rut = usuario.USU_RUT;
            pub.MAS_ID_MASCOTA = mascota.MAS_ID_MASCOTA;
            
            pub.PUB_ID_PUBLICACION = c_pub.siguienteId();
            pub.PUB_FECHA = DateTime.Now;


           
            pub.PUB_USU_RUT = rut;
            pub.PUB_FOTO_URI = lbl_ruta.Content.ToString();
            pub.COM_ID_COMUNA = usuario.COM_ID_COMUNA;
            pub.COM_NOMBRE_COMUNA = usuario.COM_NOMBRE_COMUNA;

            if (exito)
            {
                c_masc.agregarMascota(mascota);
                c_pub.crearPublicacion(pub);
                MessageBox.Show("Muchas gracias, esperamos que pronto pueda encontrar un dueño :)", "Publicacion creada con exito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Debe llenar bien los campos");
        }
        
    }
}
