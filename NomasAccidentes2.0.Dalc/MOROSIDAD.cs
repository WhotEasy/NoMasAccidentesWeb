//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NomasAccidentes2._0.Dalc
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOROSIDAD
    {
        public MOROSIDAD()
        {
            this.DOCUMENTOS = new HashSet<DOCUMENTOS>();
        }
    
        public int ID_MOROSIDAD { get; set; }
        public int CANTIDAD_PENDIENTE { get; set; }
    
        public virtual ICollection<DOCUMENTOS> DOCUMENTOS { get; set; }
    }
}
