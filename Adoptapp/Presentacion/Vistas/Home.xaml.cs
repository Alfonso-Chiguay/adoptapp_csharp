﻿using BaseDatos;
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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        USUARIO usuario;
        public Home(string userName)
        {
            usuario = new USUARIO();
            InitializeComponent();
            Con_Usuario userDao = new Con_Usuario();
            usuario = userDao.getByUserName(userName);
            txtNombre.Text = usuario.USU_NOMBRE;
            txtPublicaciones.Text = "2";
            txtFechaNacimiento.Text = usuario.USU_FECHA_NACIMIENTO.ToShortDateString();
            txtDireccion.Text = usuario.USU_DIRECCION;
            txtCorreo.Text = usuario.USU_CORREO;
            txtComuna.Text = usuario.COM_NOMBRE_COMUNA;
            txtAdopciones.Text = "3";
        }

        private void btn_crear_publicacion_Click(object sender, RoutedEventArgs e)
        {
            CrearPublicacion ventana = new CrearPublicacion(usuario.USU_USERNAME);
            ventana.ShowDialog();
        }

        private void btn_ver_publicaciones_Click(object sender, RoutedEventArgs e)
        {
            TodasPublicaciones obj = new TodasPublicaciones();
            this.Close();
            obj.ShowDialog();
        }

        private void btn_detalle_Click(object sender, RoutedEventArgs e)
        {
            DetalleCuenta ventana = new DetalleCuenta(usuario);
            this.Close();
            ventana.ShowDialog();
            
        }
    }
}
