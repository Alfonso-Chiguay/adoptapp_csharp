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
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.REGION.ToList();
                foreach (REGION comuna in consulta)
                {
                    lista.Add(comuna.REG_NOMBRE_REGION);
                }
                return lista;
            }
        }

        public string idRegion(string nombre_region)
        {
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.REGION.Where(x => x.REG_NOMBRE_REGION.Equals(nombre_region)).FirstOrDefault();
                return consulta.REG_ID_REGION.ToString();
            }
        }
    }
}
