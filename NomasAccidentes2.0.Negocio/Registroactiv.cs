using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Registroactiv
    {
        public int id_registro_Act { get; set; }
        public int id_solicitud { get; set; }
        public Nullable<int> rut_profesional { get; set; }
        public int rut_cliente { get; set; }

        public Cliente cliente { get; set; }
        public Profesional profesional { get; set; }
        public Solicitudes solicitudes { get; set; }
        Entities db = new Entities();
        public List<Registroactiv> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.REGISTRO_ACTIVIDADES.Select(u => new Registroactiv()
            {
                id_registro_Act = u.ID_REGISTRO_ACTIVIDADES,
                id_solicitud =  u.ID_SOLICITUD,
                rut_profesional = (int)u.RUT_PROFESIONAL,
                rut_cliente = u.RUT_CLIENTE,
                cliente = new Cliente()
                {
                    rut = (int)u.RUT_CLIENTE,
                    nombreCliente = u.CLIENTE.NOMBRE_CLIENTE,
                    RazonSocial = u.CLIENTE.RAZON_SOCIAL,
                    CorreoElectronico = u.CLIENTE.CORREO_ELECTRONICO,
                    id_usuario = u.CLIENTE.ID_USUARIO
                },
                profesional= new Profesional() {
                rut_profesional = (int)u.RUT_PROFESIONAL,
                nombre_profesional=u.PROFESIONAL.NOMBRE_PROFESIONAL,
                id_usuario = u.PROFESIONAL.ID_USUARIO
                },
                solicitudes = new Solicitudes() {
                ID_SOLICITUD =u.ID_SOLICITUD,
                DESCRIPCION=u.SOLICITUDES.DESCRIPCION,
                FECHA_SOLICITUD= u.SOLICITUDES.FECHA_SOLICITUD,
                RESOLUCION= u.SOLICITUDES.RESOLUCION,
                FECHA_CIERRE= u.SOLICITUDES.FECHA_CIERRE,
                ID_TIPO_SOLICITUDES= u.SOLICITUDES.ID_TIPO_SOLICITUDES,
                RUT_CLIENTE= u.SOLICITUDES.RUT_CLIENTE,
                ID_ESTADO_SOLICITUDES= u.SOLICITUDES.ID_ESTADO_SOLICITUDES
                }
            }).ToList();
        }
        public Registroactiv find(int id)
        {
            return this.db.REGISTRO_ACTIVIDADES.Select(u => new Registroactiv()
            {
                id_registro_Act = u.ID_REGISTRO_ACTIVIDADES,
                id_solicitud = u.ID_SOLICITUD,
                rut_profesional = u.RUT_PROFESIONAL,
                rut_cliente = u.RUT_CLIENTE,
                cliente = new Cliente()
                {
                    rut = (int)u.RUT_CLIENTE,
                    nombreCliente = u.CLIENTE.NOMBRE_CLIENTE,
                    RazonSocial = u.CLIENTE.RAZON_SOCIAL,
                    CorreoElectronico = u.CLIENTE.CORREO_ELECTRONICO,
                    id_usuario = u.CLIENTE.ID_USUARIO
                },
                profesional = new Profesional()
                {
                    rut_profesional = (int)u.RUT_PROFESIONAL,
                    nombre_profesional = u.PROFESIONAL.NOMBRE_PROFESIONAL,
                    id_usuario = u.PROFESIONAL.ID_USUARIO
                },
                solicitudes = new Solicitudes()
                {
                    ID_SOLICITUD = u.ID_SOLICITUD,
                    DESCRIPCION = u.SOLICITUDES.DESCRIPCION,
                    FECHA_SOLICITUD = u.SOLICITUDES.FECHA_SOLICITUD,
                    RESOLUCION = u.SOLICITUDES.RESOLUCION,
                    FECHA_CIERRE = u.SOLICITUDES.FECHA_CIERRE,
                    ID_TIPO_SOLICITUDES = u.SOLICITUDES.ID_TIPO_SOLICITUDES,
                    RUT_CLIENTE = u.SOLICITUDES.RUT_CLIENTE,
                    ID_ESTADO_SOLICITUDES = u.SOLICITUDES.ID_ESTADO_SOLICITUDES
                }
            }).Where(u => u.id_registro_Act == id).FirstOrDefault();
        }
        public Registroactiv findsoli(int id)
        {
            return this.db.REGISTRO_ACTIVIDADES.Select(u => new Registroactiv()
            {
                id_registro_Act = u.ID_REGISTRO_ACTIVIDADES,
                id_solicitud = u.ID_SOLICITUD,
                rut_profesional = u.RUT_PROFESIONAL,
                rut_cliente = u.RUT_CLIENTE,

            }).Where(u => u.id_solicitud == id).FirstOrDefault();

        }
        public bool Update()
        {
            try
            {
                //Llamar SP almacenado Update, Modificar
                db.SPP_MODIFICARREGISTROR(this.id_solicitud, this.rut_profesional);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
               // db.SPP_ELIMINARREGISTRO(id);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
