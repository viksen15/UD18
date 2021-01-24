using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Ej_8
{
    class Metodos
    {
        public SqlConnection Connection;
        public void Conexion(string server, string bd)
        {
            try
            {
                Connection = new SqlConnection("Server= " + server + "; Database= " + bd + "; Persist Security Info= True; User ID= sa; Password= viiksen_15");
                Connection.Open();
                Console.WriteLine("Se abrió la conexión con '" + server + "' y la base de datos: " + bd);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void Ejecutar(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, Connection);
                comando.ExecuteNonQuery();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void Lectura(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, Connection);
                SqlDataReader lector = comando.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);

                foreach (DataRow dr in dt.Rows)
                {
                    int i = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Console.Write("{0}: {1} ", dc.ColumnName, dr[i], "");
                        i++;
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void Desconexion()
        {
            try
            {
                Connection.Close();
                Console.WriteLine("Se cerro la conexion");
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

    }
}
