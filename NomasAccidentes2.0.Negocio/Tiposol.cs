using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Tiposol
    {
        public int id_tipo_soli { get; set; }
        public string Descripcion { get; set; }

        Entities db = new Entities();


        public List<Tiposol> ReadAll()
        {

            return db.TIPO_SOLICITUDES.Select(u => new Tiposol()
            {
                id_tipo_soli = u.ID_TIPO_SOLICITUDES,
                Descripcion = u.DESCRIPCION
            }).ToList();
        }
    }
}
