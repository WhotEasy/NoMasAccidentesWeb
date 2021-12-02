using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Profes
    {
        public int rut_profesional { get; set; }
        public string nombre_profesional { get; set; }

        Entities db = new Entities();
        public List<Profesional> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.PROFESIONAL.Select(u => new Profesional()
            {
                rut_profesional = u.RUT_PROFESIONAL,
                nombre_profesional = u.NOMBRE_PROFESIONAL
            }).ToList();
        }
    }
}
