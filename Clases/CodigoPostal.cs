﻿using System.Data;
using System.Linq;
using WEBhecsa.Models;

namespace WEBhecsa.Clases
{
    public class CodigoPostal
    {
        public static DataSet FiltroCP(string CP)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("ColoniaID", typeof(string));
            dt.Columns.Add("Colonia", typeof(string));
            dt.Columns.Add("Municipio", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            using (DatosHECSAEntities db_sepomex = new DatosHECSAEntities())
            {
                var tbl_sepomex = (from c in db_sepomex.MexCP
                                   where c.d_codigo == CP
                                   select c).ToList();

                foreach (var item in tbl_sepomex)
                {
                    DataRow row = dt.NewRow();

                    row["ColoniaID"] = item.id_asenta_cpcons;
                    row["Colonia"] = item.d_asenta;
                    row["Municipio"] = item.D_mnpio;
                    row["Estado"] = item.d_estado;

                    dt.Rows.Add(row);
                }
            }
            ds.Tables.Add(dt);
            return ds;
        }
    }
}