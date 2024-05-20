using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Cliente
    {
        public int Id { get; set; }
        public String Pnome { get; set; }
        public String Unome { get; set; }
        public int Nif { get; set; }
        

        public static List<Cliente> GetClientes(string connectionString)
        {
            List<Cliente> clientes = new List<Cliente>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Select c.Id,c.pnome, c.unome,c.nif
                                 From Cliente c;";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Pnome = reader["pnome"].ToString(),
                        Unome = reader["unome"].ToString(),
                        Nif = Convert.ToInt32(reader["nif"]),
                    };

                    clientes.Add(cliente);
                }
                reader.Close();
            }
            return clientes;
        }


        public static List<Cliente> GetClientesForNif(string connectionString,int nif)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Select c.Id,c.pnome, c.unome,c.nif
                                 From Cliente c
                                 where c.nif = @nif";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nif", nif);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Pnome = reader["pnome"].ToString(),
                        Unome = reader["unome"].ToString(),
                        Nif = Convert.ToInt32(reader["nif"]),
                    };

                    clientes.Add(cliente);
                }
                reader.Close();
            }
            return clientes;
        }



    }
}
