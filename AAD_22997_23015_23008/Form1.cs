using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AAD_22997_23015_23008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carregar os dados ao carregar o formulário (opcional)
            CarregarDados();
        }

        // Eventos dos botões para atualizar o painel
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = true;
        }

        private void CarregarDados()
        {
            // Conexão com o SQL Server
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            string query = "SELECT * FROM Cliente";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnSaveClientAndContacts_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=teste;Integrated Security=True;";

            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("O nome do cliente é obrigatório!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClientNIF.Text))
            {
                MessageBox.Show("O NIF do cliente é obrigatório!");
                return;
            }

            try
            {
                string clientName = txtClientName.Text;
                string clientNIF = txtClientNIF.Text;
                string clientAddress = txtClientAddress.Text;

                // Inserir Cliente e recuperar o ID gerado
                int clientId = InsertClient(clientName, clientNIF, clientAddress);

                // Inserir Contactos
                foreach (var contact in lstContacts.Items)
                {
                    string[] contactData = contact.ToString().Split('-');
                    string contactType = contactData[0].Trim();
                    string contactNumber = contactData[1].Trim();
                    InsertContact(clientId, contactType, contactNumber);
                }

                MessageBox.Show("Cliente e contactos inseridos com sucesso!");
                ClearClientForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir dados: " + ex.Message);
            }
        }

        private int InsertClient(string name, string nif, string address)
        {
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=teste;Integrated Security=True;";

            string query = "INSERT INTO Cliente (Name, NIF, Address) OUTPUT INSERTED.ClientId VALUES (@Name, @NIF, @Address);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@NIF", nif);
                command.Parameters.AddWithValue("@Address", address);

                connection.Open();
                int clientId = (int)command.ExecuteScalar(); // Retorna o ID gerado do cliente
                return clientId;
            }
        }

        private void InsertContact(int clientId, string contactType, string contactNumber)
        {
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=teste;Integrated Security=True;";

            string query = "INSERT INTO Contact (ClientId, ContactType, ContactNumber) VALUES (@ClientId, @ContactType, @ContactNumber);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.Parameters.AddWithValue("@ContactType", contactType);
                command.Parameters.AddWithValue("@ContactNumber", contactNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Aqui você pode pegar os valores de um TextBox ou outro input
            string tipoContato = txtTipoContato.Text; // Suponha que você tenha um TextBox para o tipo de contato
            string numeroContato = txtNumeroContato.Text; // E um TextBox para o número do contato

            // Validações simples
            if (!string.IsNullOrEmpty(tipoContato) && !string.IsNullOrEmpty(numeroContato))
            {
                // Adicionar o contato formatado no ListBox
                lstContacts.Items.Add($"{tipoContato} - {numeroContato}");

                // Limpar os campos após adicionar
                txtTipoContato.Clear();
                txtNumeroContato.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de adicionar um contato.");
            }
        }

        private void ClearClientForm()
        {
            txtClientName.Clear();
            txtClientNIF.Clear();
            txtClientAddress.Clear();
            txtTipoContato.Clear();
            txtNumeroContato.Clear();
            lstContacts.Items.Clear();
        }

        //-----------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Fecha o formulário principal
            this.Close();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
