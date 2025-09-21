CREATE TABLE Cliente (
  IDCliente       int IDENTITY NOT NULL, 
  NomeCliente     varchar(255) NULL, 
  DataNascCliente date NULL, 
  NIFCliente      int NULL, 
  RuaCliente      varchar(255) NULL, 
  TipoClienteIDTC int NOT NULL, 
  CodigoPostalCP  int NOT NULL, 
  PRIMARY KEY (IDCliente));
CREATE TABLE TipoCliente (
  IDTC   int IDENTITY NOT NULL, 
  DescTC varchar(255) NULL, 
  PRIMARY KEY (IDTC));
CREATE TABLE TipoContacto (
  IDTContacto   int IDENTITY NOT NULL, 
  DescTContacto varchar(20) NULL, 
  PRIMARY KEY (IDTContacto));
CREATE TABLE ContactoClientes (
  ClienteIDCliente        int NOT NULL, 
  TipoContactoIDTContacto int NOT NULL, 
  NumeroCliente           int NULL)

CREATE TABLE ClasseVeiculo (
  IDClasseVeiculo   int IDENTITY NOT NULL, 
  DescClasseVeiculo varchar(110) NULL, 
  PRIMARY KEY (IDClasseVeiculo));
CREATE TABLE HabilitacaoCliente (
  ClienteIDCliente             int NOT NULL, 
  ClasseVeiculoIDClasseVeiculo int NOT NULL, 
  DataHabilitacao              date NULL, 
  PRIMARY KEY (ClienteIDCliente, 
  ClasseVeiculoIDClasseVeiculo));
CREATE TABLE CodigoPostal (
  CP         int IDENTITY NOT NULL, 
  Localidade varchar(200) NULL, 
  PRIMARY KEY (CP));
CREATE TABLE Veiculo (
  IDVeiculo                    int IDENTITY NOT NULL, 
  MatriculaVeiculo             varchar(10) NULL, 
  LotacaoVeiculo               int NULL, 
  TaraVeiculo                  int NULL, 
  DescCor                      varchar(255) NULL, 
  DataLegal                    date NULL, 
  DataFabricacao               date NULL, 
  DataAquisicao                date NULL, 
  DisponibilidadeVeiculo       image NULL, 
  ValorDiarioVeiculo           int NULL, 
  ModeloVeiculoIDModelo        int NOT NULL, 
  ClasseVeiculoIDClasseVeiculo int NOT NULL, 
  EstadoVeiculoIDEstadoVeiculo int NOT NULL, 
  FornecedorIDFornecedor       int NOT NULL, 
  PRIMARY KEY (IDVeiculo));
CREATE TABLE Infracoes (
  IDInfracao              int IDENTITY NOT NULL, 
  ClienteIDCliente        int NOT NULL, 
  TipoInfracaoIDTInfracao int NOT NULL, 
  AluguerIDAluguer        int NOT NULL, 
  PRIMARY KEY (IDInfracao));
CREATE TABLE ModeloVeiculo (
  IDModelo            int IDENTITY NOT NULL, 
  DescModelo          varchar(20) NULL, 
  MarcaVeiculoIDMarca int NOT NULL, 
  PRIMARY KEY (IDModelo));
CREATE TABLE MarcaVeiculo (
  IDMarca   int IDENTITY NOT NULL, 
  DescMarca varchar(20) NULL, 
  PRIMARY KEY (IDMarca));
CREATE TABLE EstadoVeiculo (
  IDEstadoVeiculo int IDENTITY NOT NULL, 
  DescEstado      varchar(100) NULL, 
  PRIMARY KEY (IDEstadoVeiculo));
CREATE TABLE Seguro (
  ApoliceSeguro          varchar(20) NOT NULL, 
  DataRenovacao          date NULL, 
  ValorInicial           int NULL, 
  DescSeguro             varchar(255) NULL, 
  VeiculoIDVeiculo       int NOT NULL, 
  SeguradoraIDSeguradora int NOT NULL, 
  PRIMARY KEY (ApoliceSeguro));
CREATE TABLE Despesa (
  VeiculoIDVeiculo      int NOT NULL, 
  TipoDespesaIDTDespesa int NOT NULL, 
  ValorDespesa          int NULL, 
  DataPagDes            date NULL);
CREATE TABLE TipoDespesa (
  IDTDespesa   int IDENTITY NOT NULL, 
  DescTDespesa varchar(255) NULL, 
  PRIMARY KEY (IDTDespesa));
CREATE TABLE Seguradora (
  IDSeguradora   int IDENTITY NOT NULL, 
  DescSeguradora varchar(100) NULL, 
  PRIMARY KEY (IDSeguradora));
CREATE TABLE Fornecedor (
  IDFornecedor   int IDENTITY NOT NULL, 
  NomeFornecedor varchar(50) NULL, 
  RuaFornecedor  varchar(255) NULL, 
  CodigoPostalCP int NOT NULL, 
  PRIMARY KEY (IDFornecedor));
CREATE TABLE Aluguer (
  IDAluguer           int IDENTITY NOT NULL, 
  VeiculoIDVeiculo    int NOT NULL, 
  ClienteIDCliente    int NOT NULL, 
  DataLevantamento    date NULL, 
  DataEntregaPrevista date NULL, 
  DataDevolucao       date NULL, 
  PRIMARY KEY (IDAluguer));
CREATE TABLE Orcamento (
  AluguerIDAluguer int NOT NULL, 
  IDOrcamento      int IDENTITY NOT NULL, 
  ValorEntrada     int NULL, 
  ValorCaucao      int NULL, 
  ValorQuitacao    int NULL, 
  Desconto         int NULL, 
  PRIMARY KEY (IDOrcamento));
CREATE TABLE TipoInfracao (
  IDTInfracao   int IDENTITY NOT NULL, 
  DescTInfracao varchar(255) NULL, 
  ValorInfracao int NULL, 
  PRIMARY KEY (IDTInfracao));
CREATE TABLE Feedback (
  AluguerIDAluguer int NOT NULL, 
  Classificacao    int NULL, 
  DescOpiniao      varchar(255) NULL);
CREATE TABLE Manutencao (
  IDManutencao               int IDENTITY NOT NULL, 
  DataManutencao             date NULL, 
  DescManutencao             varchar(255) NULL, 
  EmpresaParceiraIDEParceira int NOT NULL, 
  VeiculoIDVeiculo           int NOT NULL, 
  PRIMARY KEY (IDManutencao));
CREATE TABLE EmpresaParceira (
  IDEParceira    int IDENTITY NOT NULL, 
  NomeEParceira  varchar(50) NULL, 
  RuaEParceira   varchar(255) NULL, 
  CodigoPostalCP int NOT NULL, 
  PRIMARY KEY (IDEParceira));
CREATE TABLE ContactoEP (
  EmpresaParceiraIDEParceira int NOT NULL, 
  TipoContactoIDTContacto    int NOT NULL, 
  NumeroEParceira            int NULL);
CREATE TABLE ContactoFornecedor (
  FornecedorIDFornecedor  int NOT NULL, 
  TipoContactoIDTContacto int NOT NULL, 
  NumeroFornecedor        int NULL);
CREATE TABLE Fatura (
  IDFatura             int IDENTITY NOT NULL, 
  AluguerIDAluguer     int NOT NULL, 
  OrcamentoIDOrcamento int NOT NULL, 
  DataFatura           date NULL, 
  PRIMARY KEY (IDFatura));
CREATE TABLE TipoPagamento (
  IDTPagamento   int IDENTITY NOT NULL, 
  DescTPagamento varchar(20) NULL, 
  PRIMARY KEY (IDTPagamento));
CREATE TABLE Recibo (
  FaturaIDFatura            int NOT NULL, 
  IDRecibo                  int IDENTITY NOT NULL, 
  DataRecibo                date NULL, 
  ValorRecibo               int NULL, 
  TipoPagamentoIDTPagamento int NOT NULL, 
  PRIMARY KEY (IDRecibo));
ALTER TABLE Cliente ADD CONSTRAINT FKCliente171693 FOREIGN KEY (TipoClienteIDTC) REFERENCES TipoCliente (IDTC);
ALTER TABLE ContactoClientes ADD CONSTRAINT FKContactoCl989419 FOREIGN KEY (ClienteIDCliente) REFERENCES Cliente (IDCliente);
ALTER TABLE ContactoClientes ADD CONSTRAINT FKContactoCl748452 FOREIGN KEY (TipoContactoIDTContacto) REFERENCES TipoContacto (IDTContacto);
ALTER TABLE HabilitacaoCliente ADD CONSTRAINT FKHabilitaca740063 FOREIGN KEY (ClienteIDCliente) REFERENCES Cliente (IDCliente);
ALTER TABLE HabilitacaoCliente ADD CONSTRAINT FKHabilitaca889015 FOREIGN KEY (ClasseVeiculoIDClasseVeiculo) REFERENCES ClasseVeiculo (IDClasseVeiculo);
ALTER TABLE Cliente ADD CONSTRAINT FKCliente381375 FOREIGN KEY (CodigoPostalCP) REFERENCES CodigoPostal (CP);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo606370 FOREIGN KEY (ClasseVeiculoIDClasseVeiculo) REFERENCES ClasseVeiculo (IDClasseVeiculo);
ALTER TABLE Infracoes ADD CONSTRAINT FKInfracoes339337 FOREIGN KEY (ClienteIDCliente) REFERENCES Cliente (IDCliente);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo296432 FOREIGN KEY (ModeloVeiculoIDModelo) REFERENCES ModeloVeiculo (IDModelo);
ALTER TABLE ModeloVeiculo ADD CONSTRAINT FKModeloVeic760930 FOREIGN KEY (MarcaVeiculoIDMarca) REFERENCES MarcaVeiculo (IDMarca);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo314013 FOREIGN KEY (EstadoVeiculoIDEstadoVeiculo) REFERENCES EstadoVeiculo (IDEstadoVeiculo);
ALTER TABLE Seguro ADD CONSTRAINT FKSeguro688000 FOREIGN KEY (VeiculoIDVeiculo) REFERENCES Veiculo (IDVeiculo);
ALTER TABLE Despesa ADD CONSTRAINT FKDespesa903685 FOREIGN KEY (VeiculoIDVeiculo) REFERENCES Veiculo (IDVeiculo);
ALTER TABLE Despesa ADD CONSTRAINT FKDespesa591382 FOREIGN KEY (TipoDespesaIDTDespesa) REFERENCES TipoDespesa (IDTDespesa);
ALTER TABLE Seguro ADD CONSTRAINT FKSeguro155812 FOREIGN KEY (SeguradoraIDSeguradora) REFERENCES Seguradora (IDSeguradora);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo966403 FOREIGN KEY (FornecedorIDFornecedor) REFERENCES Fornecedor (IDFornecedor);
ALTER TABLE Aluguer ADD CONSTRAINT FKAluguer611878 FOREIGN KEY (VeiculoIDVeiculo) REFERENCES Veiculo (IDVeiculo);
ALTER TABLE Aluguer ADD CONSTRAINT FKAluguer126813 FOREIGN KEY (ClienteIDCliente) REFERENCES Cliente (IDCliente);
ALTER TABLE Orcamento ADD CONSTRAINT FKOrcamento992256 FOREIGN KEY (AluguerIDAluguer) REFERENCES Aluguer (IDAluguer);
ALTER TABLE Infracoes ADD CONSTRAINT FKInfracoes818361 FOREIGN KEY (TipoInfracaoIDTInfracao) REFERENCES TipoInfracao (IDTInfracao);
ALTER TABLE Infracoes ADD CONSTRAINT FKInfracoes593877 FOREIGN KEY (AluguerIDAluguer) REFERENCES Aluguer (IDAluguer);
ALTER TABLE Feedback ADD CONSTRAINT FKFeedback112009 FOREIGN KEY (AluguerIDAluguer) REFERENCES Aluguer (IDAluguer);
ALTER TABLE Manutencao ADD CONSTRAINT FKManutencao260626 FOREIGN KEY (EmpresaParceiraIDEParceira) REFERENCES EmpresaParceira (IDEParceira);
ALTER TABLE ContactoEP ADD CONSTRAINT FKContactoEP248836 FOREIGN KEY (EmpresaParceiraIDEParceira) REFERENCES EmpresaParceira (IDEParceira);
ALTER TABLE ContactoEP ADD CONSTRAINT FKContactoEP607916 FOREIGN KEY (TipoContactoIDTContacto) REFERENCES TipoContacto (IDTContacto);
ALTER TABLE EmpresaParceira ADD CONSTRAINT FKEmpresaPar573460 FOREIGN KEY (CodigoPostalCP) REFERENCES CodigoPostal (CP);
ALTER TABLE Fornecedor ADD CONSTRAINT FKFornecedor236469 FOREIGN KEY (CodigoPostalCP) REFERENCES CodigoPostal (CP);
ALTER TABLE ContactoFornecedor ADD CONSTRAINT FKContactoFo809567 FOREIGN KEY (FornecedorIDFornecedor) REFERENCES Fornecedor (IDFornecedor);
ALTER TABLE ContactoFornecedor ADD CONSTRAINT FKContactoFo579487 FOREIGN KEY (TipoContactoIDTContacto) REFERENCES TipoContacto (IDTContacto);
ALTER TABLE Manutencao ADD CONSTRAINT FKManutencao98310 FOREIGN KEY (VeiculoIDVeiculo) REFERENCES Veiculo (IDVeiculo);
ALTER TABLE Fatura ADD CONSTRAINT FKFatura941452 FOREIGN KEY (AluguerIDAluguer) REFERENCES Aluguer (IDAluguer);
ALTER TABLE Fatura ADD CONSTRAINT FKFatura959995 FOREIGN KEY (OrcamentoIDOrcamento) REFERENCES Orcamento (IDOrcamento);
ALTER TABLE Recibo ADD CONSTRAINT FKRecibo223264 FOREIGN KEY (FaturaIDFatura) REFERENCES Fatura (IDFatura);
ALTER TABLE Recibo ADD CONSTRAINT FKRecibo356624 FOREIGN KEY (TipoPagamentoIDTPagamento) REFERENCES TipoPagamento (IDTPagamento);


