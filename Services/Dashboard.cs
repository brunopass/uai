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
            DataTable dataTable = database.Read("traerInmuebles",null);

            foreach(DataRow data in dataTable.Rows)
            {
                casas.Add(
                        new Casa(
                            data["id"].ToString(),
                            data["title"].ToString(),
                            data["description"].ToString(),
                            data["direccion"].ToString(),
                            float.Parse(data["precio"].ToString()),
                            "",
                            data["uri"].ToString(),
                            int.Parse(data["estrellas"].ToString()),
                            data["ubicacion"].ToString()
                            )
                    );
            }

            return casas;
        }

        public List<Casa> traerInmuebles(string place)
        {
            List<Casa> casas = new List<Casa>();
            SqlParameter[] parameters = { new SqlParameter("@ubicacion", place) };
            DataTable dataTable = database.Read("traerInmuebles", parameters);

            foreach (DataRow data in dataTable.Rows)
            {
                casas.Add(
                        new Casa(
                            data["id"].ToString(),
                            data["titulo"].ToString(),
                            data["descripcion"].ToString(),
                            data["direccion"].ToString(),
                            float.Parse(data["precio"].ToString()),
                            "",
                            data["uri"].ToString(),
                            int.Parse(data["estrellas"].ToString()),
                            data["ubicacion"].ToString()
                            )
                    );
            }

            return casas;
        }

        public List<Casa> traerInmuebles(int estrellas)
        {
            List<Casa> casas = new List<Casa>();
            SqlParameter[] parameters = { new SqlParameter("@estrellas", estrellas) };
            DataTable dataTable = database.Read("TraerInmueblesEstrellas", parameters);

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
                            int.Parse(data["estrellas"].ToString()),
                            data["ubicacion"].ToString()
                            )
                    );
            }

            return casas;
        }
    }
}
