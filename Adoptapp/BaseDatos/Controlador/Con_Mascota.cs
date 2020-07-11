using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Con_Mascota
    {
        public int siguienteId()
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.MASCOTA.ToList();
                if (consulta.Count == 0)
                    return 0;
                else
                    return consulta.Count;
            }
        }
        public void agregarMascota(MASCOTA mas)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                entidades.MASCOTA.Add(mas);
                entidades.SaveChanges();
            }
        }

        public MASCOTA macotaPorID(int id)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.MASCOTA.Where(x => x.MAS_ID_MASCOTA == id).FirstOrDefault();
                return consulta;
            }
        }

        //public MASCOTA mascotaPorTipo(string tipo)
        //{
        //    using (adoptappEntidad entidades = new adoptappEntidad())

        //    {
        //        var consulta = (
        //                       from x in entidades.PUBLICACION
        //                       join y in entidades.MASCOTA on x.MAS_ID_MASCOTA equals y.MAS_ID_MASCOTA
        //                       join z in entidades.COMUNA on x.COM_NOMBRE_COMUNA equals z.COM_NOMBRE_COMUNA
        //                       select new Pub_Mas
        //                       {
        //                           idPublicacion = x.PUB_ID_PUBLICACION,
        //                           edadMascota = y.MAS_EDAD,
        //                           fechaPublicacion = x.PUB_FECHA,
        //                           nombreMascota = y.MAS_NOMBRE,
        //                           comuna = z.COM_NOMBRE_COMUNA,
        //                           tipoMascota = y.MAS_TIPO
        //                       }
        //                       ).ToList();

        //        return consulta;
        //    }
        //}
    }
}
