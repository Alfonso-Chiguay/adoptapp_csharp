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
            using (adoptappEntities entidades = new adoptappEntities())
            {
                entidades.USUARIO.Add(usuario);
                entidades.SaveChanges();
            }
        }

        public bool existeUsername(string nombre_usuario)
        {
            using (adoptappEntities entidades = new adoptappEntities())
            {
                var consulta = entidades.USUARIO.Where(x => x.USE_NAME.ToLower().Equals(nombre_usuario.ToLower())).ToList();
                return consulta.Count == 1;                    
            }            
        }

        public bool inicioSesion(string usuario, string contrasena)
        {
            using (adoptappEntities entidades = new adoptappEntities())
            {
                return entidades.USUARIO.Any(x => x.USE_NAME.ToLower().Equals(usuario.ToLower()) &&
                                                             x.PASSWORD.Equals(contrasena));                
                   
            }
        }
    }
}
