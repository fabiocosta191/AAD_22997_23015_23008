using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        /* Método associado ao clique do botão 2, que faz alterações na visibilidade dos painéis
           e carrega os dados necessários nos controles associados. */
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;  // Oculta o painel 1
            panel3.Visible = false;  // Oculta o painel 3
            panel4.Visible = false;  // Oculta o painel 4
            panel2.Visible = true;   // Mostra o painel 2
            CarregarDados2();        // Carrega os dados para o DataGridView
            CarregarTipoCliente2();  // Carrega os dados para o ComboBox de TipoCliente
            CarregarCodigoPostal2(); // Carrega os dados para o ComboBox de Código Postal
            txtBIDCli.Enabled = false; // Desabilita o campo IDCliente para edição
        }

        /* Método responsável por carregar os dados da tabela TipoCliente para um ComboBox. */
        private void CarregarTipoCliente2()
        {
            // Query SQL para obter os dados da tabela TipoCliente
            string query = "SELECT IDTC, DescTC FROM TipoCliente";
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Adaptador para preencher a tabela
                DataTable tipoClienteTable = new DataTable();
                adapter.Fill(tipoClienteTable);

                // Verifica se a tabela retornou dados
                if (tipoClienteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados na tabela TipoCliente."); // Exibe mensagem caso esteja vazia
                    return;
                }

                // Configura o ComboBox para exibir os dados obtidos
                cmbTipoCliente2.DisplayMember = "DescTC";   // Define a descrição como texto exibido
                cmbTipoCliente2.ValueMember = "IDTC";       // Define o ID como valor interno
                cmbTipoCliente2.DataSource = tipoClienteTable; // Define a fonte de dados do ComboBox
            }
        }

        /* Método responsável por carregar os dados da tabela CodigoPostal para um ComboBox. */
        private void CarregarCodigoPostal2()
        {
            // Query SQL para obter os dados da tabela CodigoPostal
            string query = "SELECT CP, Localidade FROM CodigoPostal";
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Adaptador para preencher a tabela
                DataTable codigoPostalTable = new DataTable();
                adapter.Fill(codigoPostalTable);

                // Verifica se a tabela retornou dados
                if (codigoPostalTable.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados na tabela CodigoPostal."); // Exibe mensagem caso esteja vazia
                    return;
                }

                // Configura o ComboBox para exibir os dados obtidos
                cmbCodigoPostal2.DisplayMember = "Localidade";  // Define a localidade como texto exibido
                cmbCodigoPostal2.ValueMember = "CP";            // Define o código postal como valor interno
                cmbCodigoPostal2.DataSource = codigoPostalTable; // Define a fonte de dados do ComboBox
            }
        }

        /* Método responsável por carregar todos os dados da tabela Cliente para o DataGridView. */
        private void CarregarDados2()
        {
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            string query = "SELECT * FROM Cliente"; // Query SQL para obter todos os clientes

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Adaptador para preencher a tabela
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable; // Define a fonte de dados do DataGridView
                }
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro caso ocorra alguma exceção
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        /* Evento disparado quando a seleção de uma linha no DataGridView muda. */
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0]; // Obtém a linha selecionada

                // Atualiza os campos do formulário com os dados da linha selecionada
                txtBIDCli.Text = selectedRow.Cells["IDCliente"].Value?.ToString() ?? string.Empty;
                txtBNomeCli.Text = selectedRow.Cells["NomeCliente"].Value?.ToString() ?? string.Empty;
                txtBNifCli.Text = selectedRow.Cells["NIFCliente"].Value?.ToString() ?? string.Empty;
                txtBRuaCli.Text = selectedRow.Cells["RuaCliente"].Value?.ToString() ?? string.Empty;

                // Configura o valor no DateTimePicker se o valor for válido
                if (DateTime.TryParse(selectedRow.Cells["DataNascCliente"].Value?.ToString(), out DateTime dataNasc))
                {
                    dtpDataNascCli.Value = dataNasc;
                }

                // Configura os valores selecionados nos ComboBoxes se os dados forem válidos
                if (selectedRow.Cells["TipoClienteIDTC"].Value != DBNull.Value)
                {
                    cmbTipoCliente2.SelectedValue = (int)selectedRow.Cells["TipoClienteIDTC"].Value;
                }

                if (selectedRow.Cells["CodigoPostalCP"].Value != DBNull.Value)
                {
                    cmbCodigoPostal2.SelectedValue = (int)selectedRow.Cells["CodigoPostalCP"].Value;
                }
            }
        }

        /* Método responsável por atualizar os dados de um cliente selecionado no banco de dados. */
        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            // Validações iniciais dos campos obrigatórios
            if (!int.TryParse(txtBIDCli.Text, out int idCliente))
            {
                MessageBox.Show("Por favor, insira um ID de cliente válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? tipoClienteId = cmbTipoCliente2.SelectedValue as int?;
            int? codigoPostal = cmbCodigoPostal2.SelectedValue as int?;

            if (tipoClienteId == null || codigoPostal == null)
            {
                MessageBox.Show("Por favor, selecione um tipo de cliente e um código postal válidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBNomeCli.Text) || string.IsNullOrWhiteSpace(txtBNifCli.Text) || string.IsNullOrWhiteSpace(txtBRuaCli.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query SQL para atualizar os dados do cliente
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";
            string query = @"UPDATE Cliente
                     SET NomeCliente = @NomeCliente,
                         DataNascCliente = @DataNascCliente,
                         NIFCliente = @NIFCliente,
                         RuaCliente = @RuaCliente,
                         TipoClienteIDTC = @TipoClienteIDTC,
                         CodigoPostalCP = @CodigoPostalCP
                     WHERE IDCliente = @IDCliente";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Abre a conexão com o banco de dados

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros para a query
                        command.Parameters.AddWithValue("@IDCliente", idCliente);
                        command.Parameters.AddWithValue("@NomeCliente", txtBNomeCli.Text);
                        command.Parameters.AddWithValue("@DataNascCliente", dtpDataNascCli.Value);
                        command.Parameters.AddWithValue("@NIFCliente", txtBNifCli.Text);
                        command.Parameters.AddWithValue("@RuaCliente", txtBRuaCli.Text);
                        command.Parameters.AddWithValue("@TipoClienteIDTC", tipoClienteId.Value);
                        command.Parameters.AddWithValue("@CodigoPostalCP", codigoPostal.Value);

                        int rowsAffected = command.ExecuteNonQuery(); // Executa a query

                        // Verifica se algum registro foi atualizado
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados do cliente atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CarregarDados2(); // Recarrega os dados após a atualização
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro caso ocorra alguma exceção
                MessageBox.Show("Erro ao atualizar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Método atualizado para apagar veículo utilizando stored procedure
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

                    // Chama o procedimento armazenado para deletar o veículo
                    using (SqlCommand cmd = new SqlCommand("usp_DeleteVeiculo", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veículo e registros relacionados apagados com sucesso.");
                    CarregarDados3(); // Atualizar o DataGridView
                    textBox3.Clear(); // Limpar o campo de ID do veículo
                }
            }
            catch (SqlException sqlEx)
            {
                // Verifica se a mensagem de erro foi gerada pelo RAISERROR do stored procedure
                MessageBox.Show($"Erro ao apagar o veículo: {sqlEx.Message}", "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao apagar o veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*---------------------------------3---------------------------------*/
        /*-------------------------------------------------------------------*/


        /*-------------------------------------------------------------------*/
        /*---------------------------------4---------------------------------*/

        // Evento do botão para exibir o painel 4 e carregar dados relacionados
        private void button4_Click(object sender, EventArgs e)
        {
            // Torna o painel 4 visível e oculta os outros
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;

            // Carrega os dados do DataGridView relacionado ao painel 4
            CarregarDados4();

            // Carrega as opções de seguradoras para a ComboBox
            CarregarSeguros();

            // Reseta a seleção da ComboBox
            cbbSeguro.SelectedIndex = -1;
        }

        // Método para carregar dados no DataGridView do painel 4
        private void CarregarDados4()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            // Consulta SQL para buscar informações de seguradoras, seguros e veículos
            string query =
                @"SELECT DescSeguradora, ApoliceSeguro, DataRenovacao, IDVeiculo, MatriculaVeiculo, DescMarca, DescModelo 
                  FROM Seguradora
                  JOIN Seguro ON Seguradora.IDSeguradora = Seguro.SeguradoraIDSeguradora
                  JOIN Veiculo ON Veiculo.IDVeiculo = Seguro.VeiculoIDVeiculo
                  JOIN ModeloVeiculo ON ModeloVeiculo.IDModelo = Veiculo.ModeloVeiculoIDModelo
                  JOIN MarcaVeiculo ON MarcaVeiculo.IDMarca = ModeloVeiculo.MarcaVeiculoIDMarca";

            try
            {
                // Cria uma conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Usa um adaptador para preencher um DataTable com os resultados da consulta
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Define o DataTable como fonte de dados do DataGridView
                    dataGridView4.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra alguma exceção
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        // Método para carregar seguradoras na ComboBox
        private void CarregarSeguros()
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            // Consulta SQL para buscar as seguradoras
            string query = "SELECT IDSeguradora, DescSeguradora FROM Seguradora";

            try
            {
                // Cria uma conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Usa um adaptador para preencher um DataTable com os resultados da consulta
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Limpa os itens existentes na ComboBox
                    cbbSeguro.Items.Clear();

                    // Adiciona os itens ao ComboBox a partir do DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ComboBoxItem item = new ComboBoxItem
                        {
                            Value = row["IDSeguradora"],
                            Text = row["DescSeguradora"].ToString()
                        };
                        cbbSeguro.Items.Add(item);
                    }

                    // Define o primeiro item como selecionado (opcional)
                    if (cbbSeguro.Items.Count > 0)
                    {
                        cbbSeguro.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra alguma exceção
                MessageBox.Show("Erro ao carregar as seguradoras: " + ex.Message);
            }
        }

        // Evento do botão para realizar uma pesquisa com base na seleção da ComboBox
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            // Carrega os dados filtrados com base na pesquisa
            CarregarPesquisa();

            // Reseta a seleção da ComboBox
            cbbSeguro.SelectedIndex = -1;
        }

        // Método para carregar dados filtrados com base na seguradora selecionada
        private void CarregarPesquisa()
        {
            // Obtém o item selecionado na ComboBox
            ComboBoxItem selectedSeguradora = cbbSeguro.SelectedItem as ComboBoxItem;

            // Verifica se nenhuma seguradora foi selecionada
            if (selectedSeguradora == null)
            {
                // Exibe uma mensagem de aviso e interrompe o processo
                MessageBox.Show("Por favor, selecione uma seguradora.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // String de conexão com o banco de dados
            string connectionString = "Data Source=ASUS-FC;Initial Catalog=AAD-22997-23008-23015;Integrated Security=True;";

            // Consulta SQL com filtro para buscar dados relacionados à seguradora selecionada
            string query =
                @"SELECT DescSeguradora, ApoliceSeguro, DataRenovacao, IDVeiculo, MatriculaVeiculo, DescMarca, DescModelo 
                  FROM Seguradora
                  JOIN Seguro ON Seguradora.IDSeguradora = Seguro.SeguradoraIDSeguradora
                  JOIN Veiculo ON Veiculo.IDVeiculo = Seguro.VeiculoIDVeiculo
                  JOIN ModeloVeiculo ON ModeloVeiculo.IDModelo = Veiculo.ModeloVeiculoIDModelo
                  JOIN MarcaVeiculo ON MarcaVeiculo.IDMarca = ModeloVeiculo.MarcaVeiculoIDMarca
                  WHERE Seguradora.IDSeguradora = @IDSeguradora";

            try
            {
                // Cria uma conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Abre a conexão explicitamente

                    // Cria um comando SQL e adiciona o parâmetro necessário
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDSeguradora", selectedSeguradora.Value);

                        // Usa um adaptador para preencher um DataTable com os resultados da consulta
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Define o DataTable como fonte de dados do DataGridView
                            dataGridView4.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra alguma exceção
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            CarregarDados4();
        }

        /*---------------------------------4---------------------------------*/
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