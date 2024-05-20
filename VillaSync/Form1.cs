using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VillaSync
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection CN;
        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["VillaSync.Properties.Settings.VillaSyncConnectionString"].ConnectionString;
            



            // Initialize DetalhesAnuncio as empty
            DetalhesAnuncio.Visible = false;
            buttonCloseDetails.Visible = false;

            // Attach the CellClick event handler
            dataGridView2.CellClick += dataGridView2_CellClick;
            buttonCloseDetails.Click += buttonCloseDetails_Click;
        }

        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("Data Source = " + AppData.DB_STRING + " ;" + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + ";" + "password = " + AppData.password);
            try
            {
                CN = new SqlConnection(connectionString);
                CN.Open();
                return CN;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
                return null;
            }
        }


        private bool verifySGBDConnection()
        {
            if (CN == null)
                CN = getSGBDConnection();

            if (CN.State != ConnectionState.Open)
                CN.Open();

            return CN.State == ConnectionState.Open;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tab2.Hide();
            Tab1.Show();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            if (!verifySGBDConnection())
                return;

            try
            {
                List<Property> properties = Property.GetProperties(connectionString);
                dataGridView1.DataSource = properties;
                dataGridView1.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading properties: " + ex.Message);
            }



            SqlCommand cmd = new SqlCommand("SELECT Id FROM Agente_Imobiliario", CN);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox4.Items.Add(reader["Id"].ToString());
                comboBox5.Items.Add(reader["Id"].ToString());
            }
            reader.Close();

            CN.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tab1.Hide();
            Tab2.Show();
            comboBox6.Items.Clear();
            if (!verifySGBDConnection())
                return;
            try
            {
                List<Anuncio> anuncios = Anuncio.GetAnuncios(connectionString);
                dataGridView2.DataSource = anuncios;
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["Id_contrato"].Visible = false;
                dataGridView2.Columns["Localizacao"].DisplayIndex = 3;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Anuncios: " + ex.Message);
            }

            SqlCommand cmd = new SqlCommand("SELECT Id FROM Contrato", CN);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox6.Items.Add(reader["Id"].ToString());
            }
            reader.Close();

            CN.Close();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                List<Property> properties = Property.GetProperties(connectionString);
                dataGridView1.DataSource = properties;
                dataGridView1.Columns["Id"].Visible = false;
            }
            else
            {
                checkBox2.Checked = false;
                //alterar datagridview só com moradias
                List<Moradia> moradias = Moradia.GetMoradias(connectionString);
                dataGridView1.DataSource = moradias;
                dataGridView1.Columns["Id"].Visible = false;



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = ((sender as System.Windows.Forms.ComboBox).SelectedItem).ToString();
            updateContent_AddProperty(text);
        }

        private void updateContent_AddProperty(String tipo)
        {

            if (tipo != null && tipo == "Moradia")
            {
                label12.Visible = true;
                textBox11.Visible = true;
                textBox9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                comboBox3.Visible = false;

            }
            else if (tipo != null && tipo == "Apartamento")
            {
                textBox9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                comboBox3.Visible = true;
                label12.Visible = false;
                textBox11.Visible = false;
            }

        }

        private void AddPropertyButton_Click(object sender, EventArgs e)
        {


            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to establish a connection to the database.");
                return;
            }

            if (ChooseAddPropertyType.SelectedIndex == 1)
            {
                try
                {
                    string localizacao = textBox1.Text;
                    int n_emp = int.Parse(comboBox4.SelectedItem.ToString());
                    int m2 = int.Parse(textBox3.Text);
                    int n_pisos = int.Parse(textBox4.Text);
                    int n_quartos = int.Parse(textBox5.Text);
                    int n_wc = int.Parse(textBox6.Text);
                    string cert_energ = comboBox2.SelectedItem.ToString();
                    string garagem = comboBox1.SelectedItem.ToString();
                    int garagem_int = (garagem == "Sim") ? 1 : 0;
                    int andar = int.Parse(textBox9.Text);
                    string elevador = (string)comboBox1.SelectedValue;
                    int elevador_int = (elevador == "Sim") ? 1 : 0;
                    int id_empregado = int.Parse(comboBox4.SelectedItem.ToString());

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("sp_AddApartmento", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@andar", andar);
                        command.Parameters.AddWithValue("@elevador", elevador_int);
                        command.Parameters.AddWithValue("@localizacao", localizacao);
                        command.Parameters.AddWithValue("@m_quadrados", m2);
                        command.Parameters.AddWithValue("@n_pisos", n_pisos);
                        command.Parameters.AddWithValue("@n_quartos", n_quartos);
                        command.Parameters.AddWithValue("@n_wc", n_wc);
                        command.Parameters.AddWithValue("@cert_energ", cert_energ);
                        command.Parameters.AddWithValue("@garagem", garagem_int);
                        command.Parameters.AddWithValue("@id_empregado", id_empregado);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Apartamento adicionado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro a adicionar apartamento: " + ex.Message);
                }
            }
            else if (ChooseAddPropertyType.SelectedIndex == 0)
            {
                try
                {
                    string localizacao = textBox1.Text;
                    int n_emp = int.Parse(comboBox4.SelectedItem.ToString());
                    int m2 = int.Parse(textBox3.Text);
                    int n_pisos = int.Parse(textBox4.Text);
                    int n_quartos = int.Parse(textBox5.Text);
                    int n_wc = int.Parse(textBox6.Text);
                    string cert_energ = comboBox2.SelectedItem.ToString();
                    string garagem = comboBox1.SelectedItem.ToString();
                    int garagem_int = (garagem == "Sim") ? 1 : 0;
                    int id_empregado = int.Parse(comboBox4.SelectedItem.ToString());
                    int area_exterior = int.Parse(textBox11.Text);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("sp_AddMoradia", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@area_exterior", area_exterior);
                        command.Parameters.AddWithValue("@localizacao", localizacao);
                        command.Parameters.AddWithValue("@m_quadrados", m2);
                        command.Parameters.AddWithValue("@n_pisos", n_pisos);
                        command.Parameters.AddWithValue("@n_quartos", n_quartos);
                        command.Parameters.AddWithValue("@n_wc", n_wc);
                        command.Parameters.AddWithValue("@cert_energ", cert_energ);
                        command.Parameters.AddWithValue("@garagem", garagem_int);
                        command.Parameters.AddWithValue("@id_empregado", id_empregado);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Moradia adicionada com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro a adicionar Moradia: " + ex.Message);
                }
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                {
                    // Show all properties
                    List<Property> properties = Property.GetProperties(connectionString);
                    dataGridView1.DataSource = properties;
                    dataGridView1.Columns["Id"].Visible = false; // Assuming you don't want to show the ID column
                }
            }
            else
            {
                checkBox1.Checked = false;
                //alterar datagridview só com Apartamentos
                List<Apartamento> apartamentos = Apartamento.GetApartmentos(connectionString);
                dataGridView1.DataSource = apartamentos;
                dataGridView1.Columns["Id"].Visible = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected employee ID from comboBox5
                int id_empregado = int.Parse(comboBox5.SelectedItem.ToString());

                if(checkBox1.Checked)
                {
                    List<Moradia> moradias = Moradia.GetMoradiasForEmpregado(connectionString, id_empregado);
                    dataGridView1.DataSource = moradias;
                } 
                else if(checkBox2.Checked)
                {
                    List<Apartamento> apartamentos = Apartamento.GetApartmentosForEmpregado(connectionString, id_empregado);
                    dataGridView1.DataSource = apartamentos;
                }
                else {
                    // Retrieve properties associated with the selected employee ID
                    List<Property> properties = Property.GetPropertiesForEmpregado(connectionString, id_empregado);
                    // Bind the properties to the DataGridView
                    dataGridView1.DataSource = properties;
                }

              

                // Optionally hide the ID column if needed
                dataGridView1.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching properties: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Retrieve the ID from the clicked cell
            int anuncioId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["ID"].Value);

            // Pass the ID to the GetAnuncioDetails method
            Anuncio DetailedAnuncio = Anuncio.GetAnuncioDetails(connectionString, anuncioId);

            if (DetailedAnuncio != null)
            {
                DetalhesAnuncio.Text =
                    "Titulo: " + DetailedAnuncio.Titulo + "\n"
                    + "Descrição: " + DetailedAnuncio.Descricao + "\n"
                    + "Valor: " + DetailedAnuncio.Valor + "\n"
                    + "Proprietário: " + DetailedAnuncio.Pnome + "\n"
                    + "Localização: " + DetailedAnuncio.Localizacao + "\n";
            }
            else
            {
                DetalhesAnuncio.Text = "Anúncio não encontrado.";
            }
            buttonCloseDetails.Visible = true;
            DetalhesAnuncio.Visible = true;
            
        }
        
        


        private void buttonCloseDetails_Click(object sender, EventArgs e)
        {
            DetalhesAnuncio.Visible = false;
            buttonCloseDetails.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                String titulo = textBox2.Text.ToString();
                int id_contrato = int.Parse(comboBox6.SelectedItem.ToString());
                String descricao = richTextBox1.Text.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("sp_addAnuncio", connection);    //criar sp
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Titulo", titulo);
                    command.Parameters.AddWithValue("@Descricao", descricao);
                    command.Parameters.AddWithValue("@id_contrato", id_contrato);
                    

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Anúncio adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a adicionar anúncio: " + ex.Message);
            }


        }

        

   
    }
}