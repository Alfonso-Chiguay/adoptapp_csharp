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
        public bool rutValido(string rut)
        {


            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;

        }

        public int validarNuevoUsuario(USUARIO usuario)
        {
            Con_Usuario ctrluser = new Con_Usuario();
            if (usuario.USU_NOMBRE.Equals("") || usuario.USU_NOMBRE.Length < 2)
                return 0;
            else if (!rutValido(usuario.USU_RUT.ToString()+"-"+usuario.USU_DV))
                return -1;
            else if (!emailValido(usuario.USU_CORREO))
                return -2;
            else if (DateTime.Now.Year - usuario.USU_FECHA_NACIMIENTO.Year < 14)
                return -3;
            else if (usuario.USU_TELEFONO.ToString().Length < 9)
                return -4;
            else if (ctrluser.existeUsername(usuario.USU_USERNAME))
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

        public int convertirIdComunaARegion(int id_comuna)
        {
            int id_region;
            if (id_comuna.ToString().Length == 4)
                id_region = Int32.Parse(id_comuna.ToString().Substring(0, 1));

            else
                id_region = Int32.Parse(id_comuna.ToString().Substring(0, 2));
            return id_region;
        }
    }
}
