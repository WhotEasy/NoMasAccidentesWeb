using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class EstadoInforme
    {
        public int ID_ESTADO_INFO { get; set; }
        public string DESCRIPCION { get; set; }
        Entities db = new Entities();
        public List<EstadoInforme> ReadAll()
        {

            return db.ESTADO_INFORME.Select(e => new EstadoInforme()
            {
                ID_ESTADO_INFO = e.ID_ESTADO_INFO,
                DESCRIPCION = e.DESCRIPCION
            }).ToList();
        }
    }
}
