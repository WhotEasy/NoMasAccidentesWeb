using NomasAccidentes2._0.Dalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomasAccidentes2._0.Negocio
{
    public class Client
    {
        public int rut { get; set; }
        public string nombreCliente { get; set; }
        public int id_usuario { get; set; }
        Entities db = new Entities();
        public List<Client> ReadAll()
        {

            //return db.SPP_LISTAR_USUARIOS();
            return this.db.CLIENTE.Select(u => new Client()
            {
                rut = u.RUT_CLIENTE,
                nombreCliente = u.NOMBRE_CLIENTE
            }).ToList();


        }
        public Client find(int id)
        {
            return this.db.CLIENTE.Select(u => new Client()
            {
                rut = u.RUT_CLIENTE,
            }).Where(u => u.id_usuario == id).FirstOrDefault();

        }

    }
}
