using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace Services
{
    public class Dashboard
    {

        private Data.Database database = new Data.Database();

        public List<Casa> traerInmuebles()
        {
            List<Casa> casas = new List<Casa>();
            DataTable dataTable = database.Read("traerInmueble", null);

            foreach(DataRow data in dataTable.Rows)
            {
                casas.Add(
                        new Casa(
                            data["id"].ToString(),
                            data["titulo"].ToString(),
                            data["descripcion"].ToString(),
                            data["direccion"].ToString(),
                            float.Parse(data["precio"].ToString()),
                            data["ambientes"].ToString(),
                            data["uri"].ToString(),
                            int.Parse(data["estrellas"].ToString())
                            )
                    );
            }

            return casas;
        }

        public List<Casa> traerInmuebles(string place)
        {
            List<Casa> casas = new List<Casa>();
            SqlParameter[] parameters = { new SqlParameter("@ubicacion", place) };
            DataTable dataTable = database.Read("traerInmueble", parameters);

            foreach (DataRow data in dataTable.Rows)
            {
                casas.Add(
                        new Casa(
                            data["id"].ToString(),
                            data["titulo"].ToString(),
                            data["descripcion"].ToString(),
                            data["direccion"].ToString(),
                            float.Parse(data["precio"].ToString()),
                            data["ambientes"].ToString(),
                            data["uri"].ToString(),
                            int.Parse(data["estrellas"].ToString())
                            )
                    );
            }

            return casas;
        }

        public List<Casa> traerInmuebles(int estrellas)
        {
            List<Casa> casas = new List<Casa>();
            SqlParameter[] parameters = { new SqlParameter("@estrellas", estrellas) };
            DataTable dataTable = database.Read("traerInmueble", parameters);

            foreach (DataRow data in dataTable.Rows)
            {
                casas.Add(
                        new Casa(
                            data["id"].ToString(),
                            data["titulo"].ToString(),
                            data["descripcion"].ToString(),
                            data["direccion"].ToString(),
                            float.Parse(data["precio"].ToString()),
                            data["ambientes"].ToString(),
                            data["uri"].ToString(),
                            int.Parse(data["estrellas"].ToString())
                            )
                    );
            }

            return casas;
        }
    }
}
