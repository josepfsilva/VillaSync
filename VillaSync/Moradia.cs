using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Moradia : Property
    {
        public int Area_exterior { get; set; }

        public static List<Moradia> GetMoradias(string connectionString)
        {
            List<Moradia> moradias = new List<Moradia>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.ID, p.Localizacao, p.M_quadrados, p.N_pisos, p.N_quartos, p.N_wc, p.Cert_energ, p.Garagem, p.id_empregado,
                        m.area_exterior
                    FROM 
                        Propriedade p
                    LEFT JOIN 
                        Moradia m ON p.Id = m.id_propriedade
                    WHERE
                        m.area_exterior IS NOT NULL;";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Moradia moradia = new Moradia
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
                        Area_exterior = Convert.ToInt32(reader["area_exterior"])
                    };
                    moradias.Add(moradia);
                }
                reader.Close();
            }
            return moradias;
        }

        public static List<Moradia> GetMoradiasForEmpregado(string connectionString, int id_empregado)
        {
            List<Moradia> moradias = new List<Moradia>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        p.ID, p.Localizacao, p.M_quadrados, p.N_pisos, p.N_quartos, p.N_wc, p.Cert_energ, p.Garagem, p.id_empregado,
                        m.area_exterior
                    FROM 
                        Propriedade p
                    LEFT JOIN 
                        Moradia m ON p.Id = m.id_propriedade
                    WHERE
                        m.area_exterior IS NOT NULL AND p.id_empregado = @id_empregado";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_empregado", id_empregado);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Moradia moradia = new Moradia
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
                        Area_exterior = Convert.ToInt32(reader["area_exterior"])
                    };
                    moradias.Add(moradia);
                }
                reader.Close();
            }
            return moradias;
        }
    }
}
