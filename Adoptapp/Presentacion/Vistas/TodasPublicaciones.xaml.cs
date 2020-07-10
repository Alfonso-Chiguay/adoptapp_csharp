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
    /// Lógica de interacción para TodasPublicaciones.xaml
    /// </summary>
    public partial class TodasPublicaciones : Window
    {
        Con_Publicacion conPub;
        Con_Region conReg;
        Con_Comuna conCom;
        public TodasPublicaciones()
        {
            InitializeComponent();
            conPub = new Con_Publicacion();

            Actualizar();
            LoadCombobox();
        }

        private void LoadCombobox()
        {
            conReg = new Con_Region();
            cbbRegion.ItemsSource = conReg.listarRegiones();

            conCom = new Con_Comuna();
            cbbComuna.ItemsSource = conCom.listarComunas();

        }

        private void Actualizar()
        {
            
            dtgPublicaciones.ItemsSource = conPub.GetAll();
            dtgPublicaciones.Items.Refresh();
        }
    }
}
