using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Cliente
    {
        public int rut { get; set; }
        public string nombreCliente { get; set; }
        public string RazonSocial { get; set; }
        public string CorreoElectronico { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Usuario usuario { get; set; }

        Entities db = new Entities();
        public List<Cliente> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.CLIENTE.Select(u => new Cliente()
            {
                rut = u.RUT_CLIENTE,
                nombreCliente = u.NOMBRE_CLIENTE,
                RazonSocial = u.RAZON_SOCIAL,
                CorreoElectronico = u.CORREO_ELECTRONICO,
                id_usuario = u.ID_USUARIO,
                usuario = new Usuario()
                {
                    Id = (int)u.ID_USUARIO,
                    Nombre = u.USUARIO.NOMBRE_USUARIO,
                    Contrasena = u.USUARIO.CONTRASENA,
                    Id_rol=u.USUARIO.ID_ROLES_USUARIOS,
                    Id_estado=u.USUARIO.ID_ESTADO_USUARIOS
                }
            }).ToList();


        }
    }
}
