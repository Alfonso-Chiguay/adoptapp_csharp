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
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                List<string> lista = new List<string>();
                var consulta = entidades.COMUNA.ToList();
                foreach(COMUNA comuna in consulta)
                {
                    lista.Add(comuna.COM_NOMBRE_COMUNA);
                }
                return lista;
            }
        }

        public List<string> listarComunaPorRegion(string id_region)
        {
            using (adoptappEntidad entidades = new adoptappEntidad())
            {
                List<string> lista = new List<string>();
                List<COMUNA> consulta = new List<COMUNA>();
                if (id_region.Length == 1)
                {
                    consulta = entidades.COMUNA.Where(x => x.COM_ID_COMUNA.ToString().Substring(0,1).Equals(id_region) && x.COM_ID_COMUNA.ToString().Length == 4).ToList();
                }
                else
                {
                    consulta = entidades.COMUNA.Where(x => x.COM_ID_COMUNA.ToString().Substring(0, 2).Equals(id_region)).ToList();
                }
                
                foreach(COMUNA comuna in consulta)
                {
                    lista.Add(comuna.COM_NOMBRE_COMUNA);
                }
                return lista;
            }
        }

        public COMUNA getComunaPorNombre(string nombre_comuna)
        {
            using(adoptappEntidad entidades = new adoptappEntidad())
            {
                return entidades.COMUNA.Where(x => x.COM_NOMBRE_COMUNA.Equals(nombre_comuna)).FirstOrDefault();
                
            }
        }
    }
}
