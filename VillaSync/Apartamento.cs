using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Apartamento : Property
    {
        public int Andar { get; set; }
        public bool Elevador { get; set; }


        public static List<Apartamento> GetApartmentos(string connectionString)
        {
            List<Apartamento> apartmentos = new List<Apartamento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.ID, p.Localizacao, p.M_quadrados, p.N_pisos, p.N_quartos, p.N_wc, p.Cert_energ, p.Garagem, p.id_empregado,
                        a.andar, a.elevador
                    FROM 
                        Propriedade p
                    LEFT JOIN 
                        Apartamento a ON p.Id = a.id_propriedade
                    WHERE
                        a.andar IS NOT NULL AND a.elevador IS NOT NULL;";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Apartamento apartamento = new Apartamento
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Localizacao = reader["localizacao"].ToString(),
                        M_quadrados = Convert.ToInt32(reader["m_quadrados"]),
                        N_pisos = Convert.ToInt32(reader["n_pisos"]),
                        N_quartos = Convert.ToInt32(reader["n_quartos"]),
                        N_wc = Convert.ToInt32(reader["n_wc"]),
                        Cert_energ = Convert.ToChar(reader["cert_energ"]),
                        Garagem = Convert.ToBoolean(reader["garagem"]),
                        Id_empregado = Convert.ToInt32(reader["id_empregado"]),
                        Andar = Convert.ToInt32(reader["andar"]),
                        Elevador = Convert.ToBoolean(reader["elevador"])
                    };

                    apartmentos.Add(apartamento);
                }

                reader.Close();
            }

            return apartmentos;
        }


        public static List<Apartamento> GetApartmentosForEmpregado(string connectionString, int id_empregado)
        {
            List<Apartamento> apartmentos = new List<Apartamento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.ID, p.Localizacao, p.M_quadrados, p.N_pisos, p.N_quartos, p.N_wc, p.Cert_energ, p.Garagem, p.id_empregado,
                        a.andar, a.elevador
                    FROM 
                        Propriedade p
                    LEFT JOIN 
                        Apartamento a ON p.Id = a.id_propriedade
                    WHERE
                        a.andar IS NOT NULL AND a.elevador IS NOT NULL AND p.id_empregado = @id_empregado;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_empregado", id_empregado);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Apartamento apartamento = new Apartamento
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Localizacao = reader["localizacao"].ToString(),
                        M_quadrados = Convert.ToInt32(reader["m_quadrados"]),
                        N_pisos = Convert.ToInt32(reader["n_pisos"]),
                        N_quartos = Convert.ToInt32(reader["n_quartos"]),
                        N_wc = Convert.ToInt32(reader["n_wc"]),
                        Cert_energ = Convert.ToChar(reader["cert_energ"]),
                        Garagem = Convert.ToBoolean(reader["garagem"]),
                        Id_empregado = Convert.ToInt32(reader["id_empregado"]),
                        Andar = Convert.ToInt32(reader["andar"]),
                        Elevador = Convert.ToBoolean(reader["elevador"])
                    };

                    apartmentos.Add(apartamento);
                }

                reader.Close();
            }

            return apartmentos;
        }
    }
}
