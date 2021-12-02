using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Pago
    {
        public int id_pagos { get; set; }
        public short Cuota { get; set; }
        public int montoCuota { get; set; }
        public int IdAlertaPago { get; set; }
        public int IdMetodo { get; set; }
        
        public  alertaProxpago AlertaProxpago { get; set; }
        public  metodoPago MetodoPago { get; set; }



        Entities db = new Entities();
        public List<Pago> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.PAGOS.Select(u => new Pago()
            {
                id_pagos = u.ID_PAGOS,
                Cuota = u.CUOTA,
                montoCuota = u.MONTO_CUOTA,
                IdAlertaPago = u.ID_ALERTA_PROXIMO_PAGO,
                IdMetodo = u.ID_METODOS_PAGOS,
                AlertaProxpago = new alertaProxpago()
                {
                    ID_ALERTA_PROXIMO_PAGO = u.ID_ALERTA_PROXIMO_PAGO,
                    FECHA_PAGO = u.ALERTA_PROXIMO_PAGO.FECHA_PAGO
                },
                MetodoPago = new metodoPago()
                {
                    ID_METODOS_PAGOS = u.ID_METODOS_PAGOS,
                    DESCRIPCION = u.METODOS_PAGOS.DESCRIPCION
                }
            }).ToList();


        }
    }
}
