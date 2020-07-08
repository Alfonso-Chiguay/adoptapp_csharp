using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Con_Region
    {
        public List<string> listarRegiones()
        {
            using (adoptappEntities entidades = new adoptappEntities())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.REGION.ToList();
                foreach (REGION comuna in consulta)
                {
                    lista.Add(comuna.NOMBRE_REGION);
                }
                return lista;
            }
        }

        public string idRegion(string nombre_region)
        {
            using(adoptappEntities entidades = new adoptappEntities())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.REGION.Where(x => x.NOMBRE_REGION.Equals(nombre_region)).FirstOrDefault();
                return consulta.IDREGION.ToString();
            }
        }
    }
}
