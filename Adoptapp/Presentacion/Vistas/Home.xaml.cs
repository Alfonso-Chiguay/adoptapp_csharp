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
            
            InitializeComponent();
            MessageBox.Show(userName);
            Con_Usuario user = new Con_Usuario();
            usuario = user.GetUSUARIO(userName);
            usuario.NOMBRE
        }
    }
}
