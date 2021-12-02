using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Profesional
    {
        public int rut_profesional { get; set; }
        public string nombre_profesional { get; set; }
        public int id_usuario { get; set; }

        public Usuario usuario { get; set; }

        Entities db = new Entities();
        public List<Profesional> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.PROFESIONAL.Select(u => new Profesional()
            {
                rut_profesional = u.RUT_PROFESIONAL,
                nombre_profesional = u.NOMBRE_PROFESIONAL,
                id_usuario = u.ID_USUARIO,
                usuario = new Usuario()
                {
                    Id = (int)u.ID_USUARIO,
                    Nombre = u.USUARIO.NOMBRE_USUARIO,
                    Contrasena = u.USUARIO.CONTRASENA,
                    Id_rol = u.USUARIO.ID_ROLES_USUARIOS,
                    Id_estado = u.USUARIO.ID_ESTADO_USUARIOS
                }
            }).ToList();
        }
    }
}
