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
    }
}
