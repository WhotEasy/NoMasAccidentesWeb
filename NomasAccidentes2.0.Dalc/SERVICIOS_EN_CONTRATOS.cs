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
    
    public partial class SERVICIOS_EN_CONTRATOS
    {
        public SERVICIOS_EN_CONTRATOS()
        {
            this.CONTRATO = new HashSet<CONTRATO>();
        }
    
        public int ID_SERVICIOS_EN_CONTRATOS { get; set; }
        public System.DateTime FECHA_INICIO { get; set; }
        public System.DateTime FECHA_FIN { get; set; }
        public int ID_SERVICIOS { get; set; }
    
        public virtual ICollection<CONTRATO> CONTRATO { get; set; }
        public virtual SERVICIOS SERVICIOS { get; set; }
    }
}