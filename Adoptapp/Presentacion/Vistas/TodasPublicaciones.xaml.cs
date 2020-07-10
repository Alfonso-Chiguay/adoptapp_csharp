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
            cbbTipoMascota.Items.Add("Perro");
            cbbTipoMascota.Items.Add("Gato");
            cbbTipoMascota.Items.Add("Ave");
            cbbTipoMascota.Items.Add("Tortuga");
            cbbComuna.IsEnabled = false;

            cbbEdad.Items.Add("3");
            cbbEdad.Items.Add("6");
            cbbEdad.Items.Add("12");
            cbbEdad.Items.Add("Cualquier edad");
            

        }

        private void Actualizar()
        {            
            dtgPublicaciones.Items.Refresh();
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            conCom = new Con_Comuna();
            conReg = new Con_Region();
            cbbComuna.IsEnabled = true;
            string id_region = cbbRegion.SelectedItem.ToString();
            cbbComuna.ItemsSource = conCom.listarComunaPorRegion(conReg.idRegion(id_region));
        }

        private void btn_todo_Click(object sender, RoutedEventArgs e)
        {
            var lista = conPub.GetAll();
            List<Carga> cargar = new List<Carga>();
            Con_Mascota cmas = new Con_Mascota();
            foreach (PUBLICACION pub in lista)
            {
                MASCOTA info = cmas.macotaPorID(pub.MAS_ID_MASCOTA);
                Carga car = new Carga();
                car.Nombre = pub.MAS_NOMBRE;
                car.Tipo = info.MAS_TIPO;
                car.Edad = info.MAS_EDAD.ToString();
                cargar.Add(car);
                
            }
            
            
            dtgPublicaciones.ItemsSource = cargar;
        }

        private class Carga
        {
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Edad { get; set; }
        }
    }
}
