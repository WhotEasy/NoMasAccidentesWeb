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
    
    public partial class ALERTA_ACCIDENTE
    {
        public int ID_ALERTA_ACCIDENTE { get; set; }
        public int ID_REGISTRO_ACCIDENTE { get; set; }
        public int RUT_CLIENTE { get; set; }
        public int ID_REGISTRO_ACCIDENTES { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual REGISTRO_ACCIDENTES REGISTRO_ACCIDENTES { get; set; }
    }
}
