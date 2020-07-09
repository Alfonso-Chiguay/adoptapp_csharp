using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Con_Publicacion
    {
        public void crearPublicacion(PUBLICACION pub)
        {
            using(adoptappEntities entidades = new adoptappEntities())
            {
                entidades.PUBLICACION.Add(pub);
                entidades.SaveChanges();
            }
        }

        public int siguienteId()
        {
            using (adoptappEntities entidades = new adoptappEntities())
            {
                var consulta = entidades.PUBLICACION.ToList();
                if (consulta.Count == 0)
                    return 0;
                else
                    return consulta.Count;
            }
        }
    }
}
