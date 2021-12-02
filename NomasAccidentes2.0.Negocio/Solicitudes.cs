using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Solicitudes
    {
        public int ID_SOLICITUD { get; set; }
        public string DESCRIPCION { get; set; }
        public System.DateTime FECHA_SOLICITUD { get; set; }
        public string RESOLUCION { get; set; }
        public Nullable<System.DateTime> FECHA_CIERRE { get; set; }

        public int ID_TIPO_SOLICITUDES { get; set; }
        public int RUT_CLIENTE { get; set; }
        public int ID_ESTADO_SOLICITUDES { get; set; }

        public Cliente  cliente { get; set; }
        public EstadoSol estadoSolic { get; set; }
        public Tiposol tiposol { get; set; }

        Entities db = new Entities();

        public List<Solicitudes> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.SOLICITUDES.Select(u => new Solicitudes()
            {
                ID_SOLICITUD = u.ID_SOLICITUD,
                DESCRIPCION = u.DESCRIPCION,
                FECHA_SOLICITUD = u.FECHA_SOLICITUD,
                RESOLUCION = u.RESOLUCION,
                FECHA_CIERRE = u.FECHA_CIERRE,
                ID_TIPO_SOLICITUDES = u.ID_TIPO_SOLICITUDES,
                RUT_CLIENTE = u.RUT_CLIENTE,
                ID_ESTADO_SOLICITUDES = u.ID_ESTADO_SOLICITUDES,
                cliente = new Cliente()
                {
                    rut = (int)u.RUT_CLIENTE,
                    nombreCliente = u.CLIENTE.NOMBRE_CLIENTE,
                    RazonSocial = u.CLIENTE.RAZON_SOCIAL,
                    CorreoElectronico = u.CLIENTE.CORREO_ELECTRONICO,
                    id_usuario = u.CLIENTE.ID_USUARIO
                },
                estadoSolic = new EstadoSol()
                {
                    idEstadoSol = u.ID_ESTADO_SOLICITUDES,
                    Descripcion = u.ESTADO_SOLICITUDES.DESCRIPCION
                },
                tiposol = new Tiposol() {
                    id_tipo_soli = u.ID_TIPO_SOLICITUDES,
                    Descripcion = u.TIPO_SOLICITUDES.DESCRIPCION
                }
            }).ToList();

        }
        public Solicitudes findsolis(int id)
        {
            return this.db.SOLICITUDES.Select(u => new Solicitudes()
            {
                ID_SOLICITUD = u.ID_SOLICITUD,
                DESCRIPCION = u.DESCRIPCION,
                FECHA_SOLICITUD = u.FECHA_SOLICITUD,
                RESOLUCION = u.RESOLUCION,
                FECHA_CIERRE = u.FECHA_CIERRE,
                ID_TIPO_SOLICITUDES = u.ID_TIPO_SOLICITUDES,
                RUT_CLIENTE = u.RUT_CLIENTE,
                ID_ESTADO_SOLICITUDES = u.ID_ESTADO_SOLICITUDES,

            }).Where(u => u.ID_SOLICITUD == id).FirstOrDefault();

        }
        public bool Save()
        {
            try
            {
                
                //Llamar SP almacenado
                db.SPP_INSERTARSOLI(this.RUT_CLIENTE, this.ID_TIPO_SOLICITUDES, this.FECHA_SOLICITUD);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Updates()
        {
            try
            {
                //Llamar SP almacenado Update, Modificar
                db.SPP_MODIFICARSOLIRE(this.ID_SOLICITUD, this.FECHA_CIERRE, this.RESOLUCION, this.ID_ESTADO_SOLICITUDES);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
