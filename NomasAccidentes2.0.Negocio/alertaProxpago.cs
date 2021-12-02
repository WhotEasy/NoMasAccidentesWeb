using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class alertaProxpago
    {
        public int ID_ALERTA_PROXIMO_PAGO { get; set; }
        public DateTime FECHA_PAGO { get; set; }

        Entities db = new Entities();

        public List<alertaProxpago> ReadAll()
        {

            return db.ALERTA_PROXIMO_PAGO.Select(u => new alertaProxpago()
            {
                ID_ALERTA_PROXIMO_PAGO = u.ID_ALERTA_PROXIMO_PAGO,
                FECHA_PAGO = u.FECHA_PAGO
            }).ToList();
        }
    }
}
