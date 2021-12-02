using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class EstadoSol
    {
        public int idEstadoSol { get; set; }
        public string Descripcion { get; set; }

        Entities db = new Entities();


        public List<EstadoSol> ReadAll()
        {

            return db.ESTADO_SOLICITUDES.Select(e => new EstadoSol()
            {
                idEstadoSol = e.ID_ESTADO_SOLICITUDES,
                Descripcion = e.DESCRIPCION
            }).ToList();
        }
    }
}
