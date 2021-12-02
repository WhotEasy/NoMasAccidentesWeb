using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Planilla
    {
        public int Id_planilla { get; set; }
        [Required, MinLength(7, ErrorMessage = "La descripcion debe tener minimo 7 caracteres"), MaxLength(30, ErrorMessage = "La descripcion debe tener maximo 30 caracteres")]
        public string Descripcion { get; set; }
        public int rut_cliente { get; set; }

        Entities db = new Entities();
        public List<Planilla> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.PLANILLA.Select(u => new Planilla()
            {
                Id_planilla = u.ID_PLANILLA,
                Descripcion = u.DESCRIPCION,
                rut_cliente = u.RUT_CLIENTE
            }).ToList();


        }
        public bool Save()
        {
            try
            {
                //Llamar SP almacenado
                db.SPP_CREAR_PLANILLA(this.Descripcion, this.rut_cliente);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Planilla find(int id)
        {
            return this.db.PLANILLA.Select(u => new Planilla()
            {
                Id_planilla = u.ID_PLANILLA,
                Descripcion = u.DESCRIPCION,
                rut_cliente = u.RUT_CLIENTE
        }).Where(u => u.Id_planilla == id).FirstOrDefault();

        }
        public bool Update()
        {
            try
            {
                //Llamar SP almacenado Update, Modificar
                db.SPP_MODIFICAR_PLANILLA(this.Id_planilla, this.Descripcion);
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
                db.SPP_ELIMINAR_PLANILLA(id);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
