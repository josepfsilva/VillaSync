using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Property
    {
        public int ID { get; set; }
        public string Localizacao { get; set; }
        public int M_quadrados { get; set; }
        public int N_pisos { get; set; }
        public int N_quartos { get; set; }
        public int N_wc { get; set; }
        public char Cert_energ { get; set; }
        public bool Garagem { get; set; }
        public int Id_empregado { get; set; }


        public static List<Property> GetProperties(string connectionString)
        {
            List<Property> properties = new List<Property>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Localizacao,M_quadrados,N_pisos,N_quartos,N_wc,Cert_energ,Garagem,Id_empregado FROM Propriedade";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Property property = new Property
                    {
                        Localizacao = reader["localizacao"].ToString(),
                        M_quadrados = Convert.ToInt32(reader["m_quadrados"]),
                        N_pisos = Convert.ToInt32(reader["n_pisos"]),
                        N_quartos = Convert.ToInt32(reader["n_quartos"]),
                        N_wc = Convert.ToInt32(reader["n_wc"]),
                        Cert_energ = Convert.ToChar(reader["cert_energ"]),
                        Garagem = Convert.ToBoolean(reader["garagem"]),
                        Id_empregado = Convert.ToInt32(reader["id_empregado"])
                    };

                    properties.Add(property);
                }

                reader.Close();
            }

            return properties;
        }

        public static List<Property> GetPropertiesForEmpregado(string connectionString, int id_empregado)
        {
            List<Property> properties = new List<Property>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                ID, Localizacao, M_quadrados, N_pisos, N_quartos, N_wc, Cert_energ, Garagem, id_empregado
            FROM 
                Propriedade
            WHERE 
                id_empregado = @id_empregado";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_empregado", id_empregado);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Property property = new Property
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Localizacao = reader["Localizacao"].ToString(),
                        M_quadrados = Convert.ToInt32(reader["M_quadrados"]),
                        N_pisos = Convert.ToInt32(reader["N_pisos"]),
                        N_quartos = Convert.ToInt32(reader["N_quartos"]),
                        N_wc = Convert.ToInt32(reader["N_wc"]),
                        Cert_energ = Convert.ToChar(reader["Cert_energ"]),
                        Garagem = Convert.ToBoolean(reader["Garagem"]),
                        Id_empregado = Convert.ToInt32(reader["id_empregado"])
                    };

                    properties.Add(property);
                }

                reader.Close();
            }

            return properties;
        }
    }
}