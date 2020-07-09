using BaseDatos;
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
        public CrearPublicacion(USUARIO user)
        {
            InitializeComponent();
            lbl_publicador.Content = user.NOMBRE;
            lbl_telefono.Content = user.TELEFONO;
            cb_mascota.Items.Add("Perro");
            cb_mascota.Items.Add("Gato");
            cb_mascota.Items.Add("Ave");
            cb_mascota.Items.Add("Tortuga");
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
    }
}
