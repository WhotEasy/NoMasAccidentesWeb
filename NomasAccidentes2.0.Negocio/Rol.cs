using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NomasAccidentes2._0.Dalc;

namespace NomasAccidentes2._0.Negocio
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        Entities db = new Entities();
        public List<Uestado> ReadAll()
        {

            return db.ROLES_USUARIOS.Select(e => new Uestado()
            {
                Id = e.ID_ROLES_USUARIOS,
                Descripcion = e.DESCRIPCION
            }).ToList();
        }
    }
}
