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
    /// Lógica de interacción para RecuperarPassword.xaml
    /// </summary>
    public partial class RecuperarPassword : Window
    {

        //automaticmail
        public RecuperarPassword()
        {
            InitializeComponent();
        }

        private void btn_enviar_Click(object sender, RoutedEventArgs e)
        {
            Con_Usuario c_user = new Con_Usuario();
            USUARIO user = new USUARIO();
            if (!c_user.existeCorreo(txt_email.Text))
            {
                MessageBox.Show("No existe una cuenta asociada al correo", "No existe cuenta", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                user = c_user.datosPorCorreo(txt_email.Text);
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(user.USU_CORREO);
                msg.Subject = "[Adoptapp] Recuperar contraseña";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Bcc.Add("adoptapp.mail@gmail.com");
                msg.Body = "Hola " + user.USU_NOMBRE + "!, tu usuario es: " + user.USU_USERNAME + ", y tu contraseña es: " + user.USU_PASSWORD;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.From = new System.Net.Mail.MailAddress("adoptapp.mail@gmail.com");
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("adoptapp.mail@gmail.com", "automaticmail");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";

                try
                {
                    cliente.Send(msg);
                    MessageBox.Show("Se ha enviado la informacion a tu correo", "Accion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error enviando correo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }
    }
}
