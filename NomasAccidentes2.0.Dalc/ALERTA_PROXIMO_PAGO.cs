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
    
    public partial class ALERTA_PROXIMO_PAGO
    {
        public ALERTA_PROXIMO_PAGO()
        {
            this.PAGOS = new HashSet<PAGOS>();
        }
    
        public int ID_ALERTA_PROXIMO_PAGO { get; set; }
        public System.DateTime FECHA_PAGO { get; set; }
    
        public virtual ICollection<PAGOS> PAGOS { get; set; }
    }
}
