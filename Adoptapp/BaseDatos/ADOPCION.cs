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
    
    public partial class ADOPCION
    {
        public int ID_ADOP { get; set; }
        public System.DateTime FECHA_ADOP { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        public virtual MASCOTA MASCOTA { get; set; }
        public virtual INVENTARIO_REGISTROS INVENTARIO_REGISTROS { get; set; }
    }
}
