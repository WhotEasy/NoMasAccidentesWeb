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
    
    public partial class PARTICIPANTES
    {
        public PARTICIPANTES()
        {
            this.PARTICIPANTE_CAPACITACION = new HashSet<PARTICIPANTE_CAPACITACION>();
        }
    
        public int RUT_PARTICIPANTE { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
    
        public virtual ICollection<PARTICIPANTE_CAPACITACION> PARTICIPANTE_CAPACITACION { get; set; }
    }
}
