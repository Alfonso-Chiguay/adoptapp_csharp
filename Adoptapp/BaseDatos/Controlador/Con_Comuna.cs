using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Controlador
{
    public class Con_Comuna
    {
        public List<string> listarComunas()
        {
            using(adoptappEntities entidades = new adoptappEntities())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.COMUNA.ToList();
                foreach(COMUNA comuna in consulta)
                {
                    lista.Add(comuna.NOMBRECOMUNA);
                }
                return lista;
            }
        }

        public List<string> listarComunaPorRegion(string id_region)
        {
            using (adoptappEntities entidades = new adoptappEntities())
            {
                List<string> lista = new List<string>();
                List<COMUNA> consulta = new List<COMUNA>();
                if (id_region.Length == 1)
                {
                    consulta = entidades.COMUNA.Where(x => x.IDCOMUNA.ToString().Substring(0,1).Equals(id_region) && x.IDCOMUNA.ToString().Length == 4).ToList();
                }
                else
                {
                    consulta = entidades.COMUNA.Where(x => x.IDCOMUNA.ToString().Substring(0, 2).Equals(id_region)).ToList();
                }
                
                foreach(COMUNA comuna in consulta)
                {
                    lista.Add(comuna.NOMBRECOMUNA);
                }
                return lista;
            }
        }
    }
}
