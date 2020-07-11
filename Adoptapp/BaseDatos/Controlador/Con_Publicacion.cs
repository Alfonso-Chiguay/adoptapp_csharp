using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Pub_Mas
    {
        public int idPublicacion { get; set; } 
        public int edadMascota { get; set; }
        public string tipoMascota { get; set; }
        public string nombreMascota { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string comuna { get; set; }
    }
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

        public List<Pub_Mas> GetAllMix()
        {

            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = (
                                from x in entidades.PUBLICACION
                                join y in entidades.MASCOTA on x.MAS_ID_MASCOTA equals y.MAS_ID_MASCOTA
                                join z in entidades.COMUNA on x.COM_NOMBRE_COMUNA equals z.COM_NOMBRE_COMUNA
                                select new Pub_Mas
                                {
                                    idPublicacion = x.PUB_ID_PUBLICACION,
                                    edadMascota = y.MAS_EDAD,
                                    fechaPublicacion = x.PUB_FECHA,
                                    nombreMascota = y.MAS_NOMBRE,
                                    comuna = z.COM_NOMBRE_COMUNA,
                                    tipoMascota = y.MAS_TIPO
                                }
                                ).ToList();

                return consulta;
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
