using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Anuncio
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Id_contrato { get; set; }
        public int Valor { get; set; }
        public string Pnome { get; set; }
        public string Unome { get; set; }
        public string Localizacao { get; set; }

        public static List<Anuncio> GetAnuncios(string connectionString)
        {
            List<Anuncio> anuncios = new List<Anuncio>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        a.ID,a.titulo, a.descricao, a.Id_contrato, p.localizacao,
                        c.valor, cl.pnome, cl.unome
                    FROM 
                        Anuncio a
                    INNER JOIN 
                        Contrato c ON a.Id_contrato = c.ID
                    INNER JOIN 
                        Cliente cl ON c.id_cliente = cl.ID
                    INNER JOIN 
                        Propriedade p ON c.id_propridade = p.ID";


                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Anuncio anuncio = new Anuncio
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Titulo = reader["titulo"].ToString(),
                        Descricao = reader["descricao"].ToString(),
                        Id_contrato = Convert.ToInt32(reader["Id_contrato"]),
                        Valor = Convert.ToInt32(reader["valor"]),
                        Pnome = reader["pnome"].ToString(),
                        Unome = reader["unome"].ToString(),
                        Localizacao = reader["localizacao"].ToString()
                    };

                    anuncios.Add(anuncio);
                }

                reader.Close();
            }

            return anuncios;
        }


    }
}

