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
    
    public partial class ESTADO_CASO
    {
        public ESTADO_CASO()
        {
            this.CASOS = new HashSet<CASOS>();
        }
    
        public int ID_ESTADO_CASO { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<CASOS> CASOS { get; set; }
    }
}
