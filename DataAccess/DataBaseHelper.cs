using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_SqlDataAdapter_Dataset.DataAccess
{
     class DataBaseHelper
    {
        private static readonly string _connectionString =  SqlDataAccess.GetConnectionString();
        private static readonly string _cartiString = SqlDataAccess.GetCartiPath();
        public static DataSet CartiDataSet;

        public static void Initialisation()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                InserareCarti(conn);

            }
        }

        private static void InserareCarti(SqlConnection conn)
        {
            string cmdText = "INSERT INTO Books (Titlu, Autor, Gen) VALUES (@titlu, @autor, @gen)";
            string deleteText = "DELETE FROM BOOKS";
            using (SqlCommand cmd= new SqlCommand (deleteText, conn)) { 
                cmd.ExecuteNonQuery();
            }
            using (StreamReader reader = new StreamReader(_cartiString))
            {
                while(reader.Peek()>=0) { 
                    string line = reader.ReadLine();
                    var splitedLine = line.Split('*');
                    using(SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("titlu", splitedLine[0]);
                        cmd.Parameters.AddWithValue("autor", splitedLine[1]);
                        cmd.Parameters.AddWithValue("gen", splitedLine[2]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

}
