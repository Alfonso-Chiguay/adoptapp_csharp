//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVENTARIO_REGISTROS
    {
        public int ID_REG { get; set; }
        public int CAN_ESPECIE { get; set; }
        public string TIPO_REG { get; set; }
    
        public virtual ADOPCION ADOPCION { get; set; }
        public virtual PUBLICACION PUBLICACION { get; set; }
    }
}
