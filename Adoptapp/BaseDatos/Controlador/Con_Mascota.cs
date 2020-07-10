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
            using(adoptappEntidad entidades = new adoptappEntidad())
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
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                var consulta = entidades.MASCOTA.Where(x => x.MAS_ID_MASCOTA == id).FirstOrDefault();
                return consulta;
            }
        }
    }
}
