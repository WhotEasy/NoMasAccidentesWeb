using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class metodoPago
    {
        public int ID_METODOS_PAGOS { get; set; }
        public string DESCRIPCION { get; set; }

        Entities db = new Entities();

        public List<metodoPago> ReadAll()
        {

            return db.METODOS_PAGOS.Select(u => new metodoPago()
            {
                ID_METODOS_PAGOS = u.ID_METODOS_PAGOS,
                DESCRIPCION = u.DESCRIPCION
            }).ToList();
        }
    }
}
