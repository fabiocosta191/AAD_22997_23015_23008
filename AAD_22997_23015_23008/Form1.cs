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
        }


        /*-------------------------------------------------------------------*/
        /*---------------------------------1---------------------------------*/

        // Evento do botão para atualizar o painel
        private void button1_Click(object sender, EventArgs e)
        {
            // Esconde todos os painéis e exibe o painel1
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = true;

            // Carrega os dados necessários para os controles
            CarregarDados1();
            CarregarTiposDeCliente();
            CarregarCodigosPostais();
            CarregarTiposDeContacto();

            // Limpa o formulário
            ClearClientForm1();
        }

        // Evento para carregar os tipos de cliente
        private void CarregarTiposDeCliente()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar os tipos de cliente
            string query = "SELECT IDTC, DescTC FROM TipoCliente";

            try
            {
                // Conectando ao banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Limpa os itens existentes na ComboBox
                    cmbTipoCliente.Items.Clear();

                    // Preenche a ComboBox com os tipos de cliente
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Value = row["IDTC"],
                            Text = row["DescTC"].ToString()
                        };
                        cmbTipoCliente.Items.Add(item);
                    }

                    // Define o primeiro item como selecionado
                    if (cmbTipoCliente.Items.Count > 0)
                    {
                        cmbTipoCliente.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os tipos de cliente: " + ex.Message);
            }
        }

        // Evento para carregar os códigos postais na ComboBox
        private void CarregarCodigosPostais()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar os códigos postais
            string query = "SELECT CP, Localidade FROM CodigoPostal";

            try
            {
                // Conectando ao banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Limpa os itens existentes na ComboBox
                    cmbCodigoPostal.Items.Clear();

                    // Preenche a ComboBox com os códigos postais
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Value = row["CP"],
                            Text = row["Localidade"].ToString()
                        };
                        cmbCodigoPostal.Items.Add(item);
                    }

                    // Define o primeiro item como selecionado
                    if (cmbCodigoPostal.Items.Count > 0)
                    {
                        cmbCodigoPostal.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os códigos postais: " + ex.Message);
            }
        }

        // Evento para carregar os tipos de contacto
        private void CarregarTiposDeContacto()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar os tipos de contacto
            string query = "SELECT IDTContacto, DescTContacto FROM TipoContacto";

            try
            {
                // Conectando ao banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Limpa os itens existentes na ComboBox
                    cmbTipoContato.Items.Clear();

                    // Preenche a ComboBox com os tipos de contacto
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Value = row["IDTContacto"],
                            Text = row["DescTContacto"].ToString()
                        };
                        cmbTipoContato.Items.Add(item);
                    }

                    // Define o primeiro item como selecionado
                    if (cmbTipoContato.Items.Count > 0)
                    {
                        cmbTipoContato.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os tipos de contato: " + ex.Message);
            }
        }

        // Evento para carregar os dados do cliente
        private void CarregarDados1()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar os dados dos clientes
            string query = "SELECT * FROM Cliente";

            try
            {
                // Conectando ao banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Preenche o DataGrid com os dados dos clientes
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        // Classe auxiliar para representar o item do ComboBox (ID e descrição)
        public class ComboBoxItem
        {
            public object Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        // Botão para salvar o cliente e os contatos
        private void btnSaveClientAndContacts_Click(object sender, EventArgs e)
        {
            // Verificar se o nome do cliente foi preenchido
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("O nome do cliente é obrigatório!");
                return;
            }

            // Verificar se o NIF do cliente foi preenchido
            if (string.IsNullOrWhiteSpace(txtClientNIF.Text))
            {
                MessageBox.Show("O NIF do cliente é obrigatório!");
                return;
            }

            // Verificar se o campo "Localidade" foi selecionado
            if (cmbCodigoPostal.SelectedItem == null)
            {
                MessageBox.Show("A localidade (código postal) é obrigatória!");
                return;
            }

            // Verificar se o tipo de cliente foi selecionado
            if (cmbTipoCliente.SelectedItem == null)
            {
                MessageBox.Show("O tipo de cliente é obrigatório!");
                return;
            }

            // Verificar se a data de nascimento foi selecionada
            if (txtDate.Value == null || txtDate.Value == DateTime.MinValue)
            {
                MessageBox.Show("A data de nascimento é obrigatória!");
                return;
            }

            try
            {
                // Coleta os dados preenchidos pelo usuário
                string clientName = txtClientName.Text;
                string clientNIF = txtClientNIF.Text;
                string clientAddress = txtClientAddress.Text;
                ComboBoxItem selectedPostalItem = (ComboBoxItem)cmbCodigoPostal.SelectedItem;
                string clientcp = selectedPostalItem.Value.ToString();
                ComboBoxItem selectedItem = (ComboBoxItem)cmbTipoCliente.SelectedItem;
                int tipoClienteId = (int)selectedItem.Value;

                // Obtém a data de nascimento selecionada no DateTimePicker
                DateTime birthDate = txtDate.Value;

                // Insere o cliente e obtém o ID gerado
                int clientId = InsertClient(clientName, clientNIF, clientAddress, clientcp, tipoClienteId, birthDate);

                // Insere os contatos associados ao cliente
                foreach (var contact in lstContacts.Items)
                {
                    string[] contactData = contact.ToString().Split('-');
                    string contactType = contactData[0].Trim();
                    string contactNumber = contactData[1].Trim();
                    int contactTypeId = GetContactTypeId(contactType); // Obtém o ID correto do tipo de contato
                    InsertContact(clientId, contactTypeId, contactNumber); // Insere o contato
                }

                // Exibe uma mensagem de sucesso
                MessageBox.Show("Cliente e contatos inseridos com sucesso!");

                // Limpa o formulário e recarrega os dados
                ClearClientForm1();
                CarregarDados1();
                CarregarTiposDeCliente();
                CarregarCodigosPostais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir dados: " + ex.Message);
            }
        }

        // Função para inserir um cliente no banco de dados
        private int InsertClient(string name, string nif, string address, string cp, int tipoClienteId, DateTime birthDate)
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Comando SQL para inserir um cliente
            string query = "INSERT INTO Cliente (NomeCliente, NIFCliente, RuaCliente, CodigoPostalCP, TipoClienteIDTC, DataNascCliente) OUTPUT INSERTED.IDCliente VALUES (@Name, @NIF, @Address, @Cp, @TipoClienteId, @BirthDate);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@NIF", nif);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Cp", cp);
                command.Parameters.AddWithValue("@TipoClienteId", tipoClienteId);
                command.Parameters.AddWithValue("@BirthDate", birthDate); // Passa a data de nascimento

                connection.Open();
                int clientId = (int)command.ExecuteScalar(); // Retorna o ID do cliente inserido
                return clientId;
            }
        }

        // Função para obter o ID do tipo de contato a partir da descrição
        private int GetContactTypeId(string contactDescription)
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar o ID do tipo de contato
            string query = "SELECT IDTContacto FROM TipoContacto WHERE DescTContacto = @Description";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Description", contactDescription);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result); // Retorna o ID do tipo de contato
                }
                else
                {
                    throw new Exception($"Tipo de contato não encontrado para descrição: {contactDescription}");
                }
            }
        }

        // Função para inserir um contato associado ao cliente
        private void InsertContact(int clientId, int contactTypeId, string contactNumber)
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Comando SQL para inserir um contato
            string query = "INSERT INTO ContactoClientes (ClienteIDCliente, TipoContactoIDTContacto, NumeroCliente) VALUES (@ClientId, @ContactTypeId, @ContactNumber);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.Parameters.AddWithValue("@ContactTypeId", contactTypeId);
                command.Parameters.AddWithValue("@ContactNumber", contactNumber);

                connection.Open();
                command.ExecuteNonQuery(); // Executa a inserção
            }
        }

        // Função para limpar o formulário de cliente
        private void ClearClientForm1()
        {
            txtClientName.Clear();
            txtDate.Value = DateTime.Now;
            txtClientNIF.Clear();
            txtClientAddress.Clear();
            lstContacts.Items.Clear();
            cmbTipoCliente.SelectedIndex = -1;
            cmbCodigoPostal.SelectedIndex = -1;
            cmbTipoContato.SelectedIndex = -1;
        }

        // Botão para adicionar um contato ao cliente
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Verifica se um tipo de contato foi selecionado
            if (cmbTipoContato.SelectedItem == null)
            {
                MessageBox.Show("Selecione um tipo de contato!");
                return;
            }

            // Verifica se o número de contato foi preenchido
            if (string.IsNullOrWhiteSpace(txtNumeroContato.Text))
            {
                MessageBox.Show("Insira um número de contato!");
                return;
            }

            // Obtém o tipo de contato e o número inserido
            ComboBoxItem selectedContactType = (ComboBoxItem)cmbTipoContato.SelectedItem;
            string contactType = selectedContactType.Text;
            string contactNumber = txtNumeroContato.Text.Trim();

            // Verifica se o número de contato é válido
            if (!long.TryParse(contactNumber, out _))
            {
                MessageBox.Show("O número de contato deve conter apenas dígitos!");
                return;
            }

            // Adiciona o contato à lista
            string contactEntry = $"{contactType} - {contactNumber}";
            lstContacts.Items.Add(contactEntry);

            // Limpa o campo de número de contato
            cmbTipoContato.SelectedIndex = -1;
            txtNumeroContato.Clear();

            // Exibe uma mensagem de sucesso
            MessageBox.Show("Contato adicionado com sucesso!");
        }
        private void ApagarLista_Click(object sender, EventArgs e)
        {
            lstContacts.Items.Clear();
        }
        /*---------------------------------1---------------------------------*/
        /*-------------------------------------------------------------------*/





        /*-------------------------------------------------------------------*/
        /*---------------------------------2---------------------------------*/


        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Visible = true;
        }

        /*---------------------------------2---------------------------------*/
        /*-------------------------------------------------------------------*/






        /*-------------------------------------------------------------------*/
        /*---------------------------------3---------------------------------*/

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
            CarregarDados3();
        }

        private void CarregarDados3()
        {
            // Conexão com o SQL Server
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            string query = "SELECT * FROM Veiculo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void btnApagaVeiculo_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            // Verificar se o ID é um número inteiro
            if (!int.TryParse(textBox3.Text, out int veiculoID))
            {
                MessageBox.Show("Por favor, insira um ID de veículo válido.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar se o ID do veículo existe na tabela Veiculo
                    string checkVeiculoExistsQuery = "SELECT COUNT(1) FROM Veiculo WHERE IDVeiculo = @VeiculoID";
                    using (SqlCommand cmd = new SqlCommand(checkVeiculoExistsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        int count = (int)cmd.ExecuteScalar(); // Executa a consulta e obtém a contagem

                        if (count == 0)
                        {
                            MessageBox.Show("Nenhum veículo encontrado com o ID fornecido.");
                            return;
                        }
                    }

                    // Excluir registros nas tabelas que dependem do Veiculo
                    string deleteDespesaQuery = "DELETE FROM Despesa WHERE VeiculoIDVeiculo = @VeiculoID";
                    string deleteSeguroQuery = "DELETE FROM Seguro WHERE VeiculoIDVeiculo = @VeiculoID";
                    string deleteAluguerQuery = "DELETE FROM Aluguer WHERE VeiculoIDVeiculo = @VeiculoID";
                    string deleteManutencaoQuery = "DELETE FROM Manutencao WHERE VeiculoIDVeiculo = @VeiculoID";

                    // Apagar as dependências usando os nomes corretos das colunas
                    using (SqlCommand cmd = new SqlCommand(deleteDespesaQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteSeguroQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteAluguerQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteManutencaoQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        cmd.ExecuteNonQuery();
                    }

                    // Excluir as infrações relacionadas a este veículo através do Aluguer
                    string deleteInfracoesQuery = @"
        DELETE FROM Infracoes 
        WHERE AluguerIDAluguer IN (
            SELECT IDAluguer FROM Aluguer WHERE VeiculoIDVeiculo = @VeiculoID
        )";

                    using (SqlCommand cmd = new SqlCommand(deleteInfracoesQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        cmd.ExecuteNonQuery();
                    }

                    // Excluir o veículo da tabela Veiculo
                    string deleteVehicleQuery = "DELETE FROM Veiculo WHERE IDVeiculo = @VeiculoID";
                    using (SqlCommand cmd = new SqlCommand(deleteVehicleQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veículo e registros relacionados apagados com sucesso.");
                            CarregarDados3(); // Atualizar o DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Erro ao tentar apagar o veículo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao apagar o veículo: " + ex.Message);
            }
        }

        /*---------------------------------3---------------------------------*/
        /*-------------------------------------------------------------------*/


        /*-------------------------------------------------------------------*/
        /*---------------------------------4---------------------------------*/

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = true;
            CarregarDados4();
        }
        private void CarregarDados4()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            // Consulta para buscar os dados dos clientes
            string query = "SELECT * FROM Cliente";
           
            try
            {
                // Conectando ao banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Preenche o DataGrid com os dados dos clientes
                    dataGridView4.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }
        /*---------------------------------4---------------------------------*/
        /*-------------------------------------------------------------------*/



        /*-------------------------------------------------------------------*/
        /*---------------------------------5---------------------------------*/

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }

        /*---------------------------------5---------------------------------*/
        /*-------------------------------------------------------------------*/






        private void button6_Click(object sender, EventArgs e)
        {
            // Fecha o formulário principal
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
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
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtNumeroContato_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
