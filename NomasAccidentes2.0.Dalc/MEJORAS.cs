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
    
    public partial class MEJORAS
    {
        public MEJORAS()
        {
            this.PLAN_MEJORAS = new HashSet<PLAN_MEJORAS>();
        }
    
        public int ID_MEJORAS { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual ICollection<PLAN_MEJORAS> PLAN_MEJORAS { get; set; }
    }
}
