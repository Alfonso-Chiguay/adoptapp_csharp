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
            using(adoptappEntities entidades = new adoptappEntities())
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
            using (adoptappEntities entidades = new adoptappEntities())
            {
                entidades.MASCOTA.Add(mas);
                entidades.SaveChanges();
            }
        }
    }
}
