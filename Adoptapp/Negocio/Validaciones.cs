using BaseDatos;
using BaseDatos.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Validaciones
    {
        public bool rutValido(string rut, string dv)
        {
            int rut_numeros;


            if (rut.Length < 7 || rut.Length > 8)
            {
                return false;
            }
            else if (dv.Length != 1)
            {
                return false;
            }
            else if (!Int32.TryParse(rut, out rut_numeros))
            {
                return false;
            }
            else if (dv.ToLower() != "k" && !Int32.TryParse(dv, out rut_numeros))
            {
                return false;
            }
            else return true;

        }

        public int validarNuevoUsuario(USUARIO usuario)
        {
            Con_Usuario ctrluser = new Con_Usuario();
            if (usuario.NOMBRE.Equals("") || usuario.NOMBRE.Length < 2)
                return 0;
            else if (!rutValido(usuario.RUT.ToString(), usuario.DV))
                return -1;
            else if (!emailValido(usuario.CORREO))
                return -2;
            else if (DateTime.Now.Year - usuario.FECHA_NACIMIENTO.Year < 14)
                return -3;
            else if (usuario.TELEFONO.ToString().Length < 9)
                return -4;
            else if (ctrluser.existeUsername(usuario.USE_NAME))
                return -5;
            else return 1;
        }

        public bool emailValido(string email)
        {
            if (!email.Contains("@"))
                return false;
            else
            {
                var email_separado = email.Split('@');
                if (!email_separado[1].Contains("."))
                    return false;
                else if (email_separado[0].Length == 0)
                    return false;
                else
                    return true;
            }

            
        }
    }
}
