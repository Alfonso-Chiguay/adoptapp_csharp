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
    /// Lógica de interacción para AnunciosGuardados.xaml
    /// </summary>
    public partial class AnunciosGuardados : Window
    {
        public AnunciosGuardados()
        {
            InitializeComponent();
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MisPublicaciones ventana = new MisPublicaciones();
            this.Close();
            ventana.ShowDialog();
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
