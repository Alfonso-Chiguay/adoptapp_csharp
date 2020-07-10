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
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                entidades.PUBLICACION.Add(pub);
                entidades.SaveChanges();
            }
        }

        public int siguienteId()
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.PUBLICACION.ToList();
                if (consulta.Count == 0)
                    return 0;
                else
                    return consulta.Count;
            }
        }

        public List<PUBLICACION> GetAll()
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                List<PUBLICACION> lista = new List<PUBLICACION>();
                var consulta = entidades.PUBLICACION.ToList();
                foreach (PUBLICACION publicacion in consulta)
                {
                    lista.Add(publicacion);
                }
                return lista;
            }
        }

        public PUBLICACION GetOne(int id)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                PUBLICACION obj = new PUBLICACION();
                obj = entidades.PUBLICACION.Where(x => x.PUB_ID_PUBLICACION.Equals(id)).FirstOrDefault();
                return obj;
            }

        }
    }
}
