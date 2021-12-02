using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Informe
    {
        public int Id_informe { get; set; }
        public System.DateTime fecha { get; set; }
        public string DESCRIPCION { get; set; }
        public int Rut_profesional { get; set; }
        public int Rut_cliente { get; set; }
        public int ID_PLANILLA { get; set; }
        public int ID_ESTADO_INFO { get; set; }

        public Planilla planilla { get; set; }
        public  Cliente cliente { get; set; }
        public  Profesional profesional { get; set; }
        public ESTADO_INFORME Estadoinforme { get; set; }


        Entities db = new Entities();
        public List<Informe> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.INFORME.Select(u => new Informe()
            {
                Id_informe = u.ID_INFORME,
                fecha = u.FECHA,
                DESCRIPCION=u.DESCRIPCION,
                Rut_profesional = u.RUT_PROFESIONAL,
                Rut_cliente = u.RUT_CLIENTE,
                ID_PLANILLA=(int)u.ID_PLANILLA,
                ID_ESTADO_INFO = u.ID_ESTADO_INFO,


            }).ToList();
        }
        public bool Save()
        {
            try
            {
                //Llamar SP almacenado
                db.SPP_CREAR_INFORME(this.DESCRIPCION, this.ID_ESTADO_INFO, this.Rut_profesional,this.Rut_cliente,this.ID_PLANILLA);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Informe find(int id)
        {
            return this.db.INFORME.Select(u => new Informe()
            {
                Id_informe = u.ID_INFORME,
                fecha = u.FECHA,
                DESCRIPCION = u.DESCRIPCION,
                Rut_profesional = u.RUT_PROFESIONAL,
                Rut_cliente = u.RUT_CLIENTE,
                ID_PLANILLA = (int)u.ID_PLANILLA,
                ID_ESTADO_INFO = u.ID_ESTADO_INFO,
            }).Where(u => u.Id_informe == id).FirstOrDefault();

        }
        public bool Update()
        {
            try
            {
                //Llamar SP almacenado Update, Modificar
                db.SPP_MODIFICAR_INFORME(this.Id_informe, this.DESCRIPCION, this.ID_ESTADO_INFO, this.Rut_profesional, this.Rut_cliente, this.ID_PLANILLA);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
