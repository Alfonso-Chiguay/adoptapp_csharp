using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Con_Usuario
    {
        public void registrarUsuario(USUARIO usuario)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                entidades.USUARIO.Add(usuario);
                entidades.SaveChanges();
            }
        }

        public bool existeUsername(string nombre_usuario)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.USUARIO.Where(x => x.USU_USERNAME.ToLower().Equals(nombre_usuario.ToLower())).ToList();
                return consulta.Count == 1;                    
            }            
        }

        public bool inicioSesion(string usuario, string contrasena)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.USUARIO.Any(x => x.USU_USERNAME.ToLower().Equals(usuario.ToLower()) &&
                                                             x.USU_PASSWORD.Equals(contrasena));                
                   
            }
        }

        public bool existeCorreo(string email)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.USUARIO.Any(x => x.USU_CORREO.ToLower().Equals(email.ToLower()));
            }
        }

        public bool existeRut(int rut)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.USUARIO.Any(x => x.USU_RUT == rut);
            }
        }

        public USUARIO datosPorCorreo(string email)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.USUARIO.Where(x => x.USU_CORREO.ToLower().Equals(email.ToLower())).FirstOrDefault();
            }
        }

        public USUARIO getByUserName(string username)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.USUARIO.Where(x => x.USU_USERNAME.ToLower().Equals(username.ToLower())).FirstOrDefault();
            }
        }

        public void cambiarContrasena(int rut, string nueva_pass)
        {
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.USUARIO.Where(x => x.USU_RUT == rut).FirstOrDefault();
                consulta.USU_PASSWORD = nueva_pass;
                entidades.SaveChanges();
            }
        }

        public void actualizarUsuario(USUARIO usuario)
        {
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.USUARIO.Where(x => x.USU_RUT == usuario.USU_RUT).FirstOrDefault();
                consulta.USU_DIRECCION = usuario.USU_DIRECCION;
                consulta.USU_TELEFONO = usuario.USU_TELEFONO;
                consulta.USU_CORREO = usuario.USU_CORREO;

                entidades.SaveChanges();
            }
        }
    }
}
