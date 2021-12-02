using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NomasAccidentes2._0.Dalc;

namespace NomasAccidentes2._0.Negocio
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MinLength(3, ErrorMessage ="El nombre debe tener minimo 3 caracteres"), MaxLength(20,ErrorMessage = "El nombre debe tener maximo 20 caracteres")]
        public string Nombre { get; set; }
        [Required, MinLength(3 ,ErrorMessage = "La contraseña debe tener minimo 5 caracteres"), MaxLength(20, ErrorMessage = "La contraseña debe tener maximo 20 caracteres")]
        public string Contrasena { get; set; }
        public int Id_rol { get; set; }
        public int Id_estado { get; set; }

        public  Rol rol { get; set; }
        public Uestado estadousr { get; set; }

        Entities db = new Entities();
        public List<Usuario> ReadAll() {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.USUARIO.Select(u => new Usuario()
            {
                Id = u.ID_USUARIO,
                Nombre = u.NOMBRE_USUARIO,
                Contrasena = u.CONTRASENA,
                Id_rol = u.ID_ROLES_USUARIOS,
                Id_estado = u.ID_ESTADO_USUARIOS,
                rol = new Rol() {
                Id = u.ID_ROLES_USUARIOS,
                Descripcion=  u.ROLES_USUARIOS.DESCRIPCION
                },
                estadousr = new Uestado() { 
                Id=u.ID_ESTADO_USUARIOS,
                Descripcion = u.ESTADO_USUARIOS.DESCRIPCION
                }
            }).ToList();
            

        }
        public bool Save()
        {
            try
            {
                //Llamar SP almacenado
                db.SPP_INSERTARUSUARIO(this.Nombre, this.Contrasena,(int)this.Id_rol);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Saveclien()
        {
            try
            {
                //Llamar SP almacenado
                db.SPP_INSERTARUSUARIO(this.Nombre, this.Contrasena, (int)this.Id_rol);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Saveprof()
        {
            try
            {
                //Llamar SP almacenado
                db.SPP_INSERTARUSUARIO(this.Nombre, this.Contrasena, (int)this.Id_rol);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Usuario find(int id) {
            return this.db.USUARIO.Select(u => new Usuario()
            {
                Id = u.ID_USUARIO,
                Nombre = u.NOMBRE_USUARIO,
                Contrasena = u.CONTRASENA,
                Id_rol = u.ID_ROLES_USUARIOS,
                Id_estado = u.ID_ESTADO_USUARIOS,
                rol = new Rol()
                {
                    Id = u.ID_ROLES_USUARIOS,
                    Descripcion = u.ROLES_USUARIOS.DESCRIPCION
                },
                estadousr = new Uestado()
                {
                    Id = u.ID_ESTADO_USUARIOS,
                    Descripcion = u.ESTADO_USUARIOS.DESCRIPCION
                }
            }).Where(u => u.Id == id).FirstOrDefault();

        }
        public Usuario found(string name)
        {
            return this.db.USUARIO.Select(u => new Usuario()
            {
                Id = u.ID_USUARIO,
                Nombre = u.NOMBRE_USUARIO,
                Contrasena = u.CONTRASENA,
                Id_rol = u.ID_ROLES_USUARIOS,
                Id_estado = u.ID_ESTADO_USUARIOS
            }).Where(u => u.Nombre == name).FirstOrDefault();

        }
        public bool Update() {
            try
            {
                //Llamar SP almacenado Update, Modificar
                db.SPP_MODIFICARUSR(this.Id,this.Nombre, this.Contrasena, this.Id_rol, this.Id_estado);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id) {
            try
            {
                db.SPP_ELIMINARUSUARIO(id);

                    return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Autenticar()
        {
            try
            {
                return db.USUARIO.Where(u => u.NOMBRE_USUARIO == this.Nombre && u.CONTRASENA == this.Contrasena).FirstOrDefault() != null;
            }
            catch (Exception)
            {

                return false ;
            }

        }
    }
}
