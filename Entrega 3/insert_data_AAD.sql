insert into MarcaVeiculo (DescMarca) VALUES
('Honda'), ('Toyota'), ('Tesla'), ('BMW'), ('Ford'), ('Hyundai'), 
('Volkswagen'), ('Opel'), ('Renault'), ('Nissan'), 
('Chevrolet'), ('Kia'), ('Jeep'), ('Mitsubishi');






insert into ModeloVeiculo(DescModelo, MarcaVeiculoIDMarca) VALUES
('Civic',1),('CBR500R',1),('X-ADV',1),('Hilux',2),('Yaris',2),('Y',3),('R1200 GS',4),('Serie 1',4),
('Kuga',5),('Fiesta',6),('Golf 7',7),('Polo 6',7),('Corsa',8),('Talisman',9),('NV300 COMBI',10),('Sentra',10),
('Camaro',11),('stonic',12),('Xceed',12),('avenger',13),('wrangler',13),('J1 Series',14),('Pajero',14),('L200',14);





insert into Seguradora (DescSeguradora) Values
('Allianz'),('MAPFRE'),('Zurich'),('Liberty Seguros'),('ageas'),
('Fidelidade'),('GENERALI'),('TRANQUILIDADE'),('Santander Seguros'),('CA');





insert into EstadoVeiculo(DescEstado) Values
('Excelente'),('Muito Bom'),('Bom'),('Utilizavel'),('Obsoleto');





insert into TipoDespesa(DescTDespesa) Values
('Manuten��o'),('Seguro'),('IUC'),('Inspe��o'),('Revis�o');






EXEC sp_help 'CodigoPostal';
ALTER TABLE CodigoPostal ALTER COLUMN Localidade NVARCHAR(255);
SET IDENTITY_INSERT CodigoPostal ON;
INSERT INTO CodigoPostal (CP, Localidade) 
VALUES
(4780030, 'S�o Martinho, Guimar�es'),
(4710090, 'Amares, Amares'),
(4750700, 'Barcelos, Barcelos'),
(4770020, 'Vieira do Minho, Vieira do Minho'),
(4860040, 'Fafe, Fafe'),
(4840300, 'Aboim, Terras de Bouro'),
(4730050, 'Vila Verde, Vila Verde'),
(4700800, 'Braga, Braga'),
(4750200, 'Barcelinhos, Barcelos'),
(4770100, 'Aldeia de Joanes, Braga'),
(4850200, 'S. Jo�o da Madeira, S. Jo�o da Madeira'),
(4760040, 'Santiago, Barcelos'),
(4870010, 'Mondim de Basto, Mondim de Basto'),
(4790030, 'Cinf�es, Cinf�es'),
(4720050, 'Vila Boa, Amares'),
(4850030, 'Esposende, Esposende'),
(4740000, 'Aver-o-Mar, P�voa de Varzim'),
(4740050, 'Barroselas, Viana do Castelo'),
(4780040, 'Brito, Guimar�es'),
(4850800, 'S. Salvador, Fafe'),
(4860100, 'Felgueiras, Felgueiras'),
(4780020, 'Folgosa, Amares'),
(4720300, 'Caires, Amares'),
(4700300, 'S�o Vitor, Braga'),
(4840080, 'Covide, Terras de Bouro'),
(4750810, 'Vila Fresca�nha S. Martinho, Barcelos'),
(4806909, 'Caldas das Taipas, Guimar�es');
SET IDENTITY_INSERT CodigoPostal OFF;





insert into ClasseVeiculo(DescClasseVeiculo) Values
('AM'),('A1'),('A2'),('A'),('B1'),('B'),('C1'),('C'),('D1'),('D'),('BE'),('C1E'),('CE'),('D1E'),('DE'),('T');




----------------------------------
INSERT INTO TipoInfracao (DescTInfracao, ValorInfracao) VALUES
('Excesso de Velocidade', 150), 
('Estacionamento Proibido', 100), 
('Uso de Celular ao Volante', 200), 
('Condu��o Perigosa', 300), 
('Sem Cinto de Seguran�a', 120), 
('Avan�o de Sinal Vermelho', 250), 
('Dirigir Sob Efeito de �lcool', 500), 
('Ultrapassagem Indevida', 180), 
('Documenta��o Irregular', 220), 
('Ve�culo Mal Conservado', 140), 
('Excesso de Carga', 350), 
('Dirigir Sem Habilita��o', 400), 
('Bloqueio de Cruzamento', 130), 
('Condu��o com Farol Apagado', 80), 
('Outras Infra��es', 100);






INSERT INTO TipoPagamento (DescTPagamento) VALUES
('Cart�o de Cr�dito'), ('Cart�o de D�bito'), ('Transf. Banc�ria'),
('Dinheiro'), ('Cheque'), 
('App de Pagamento'), ('Pagamento Recorrente'), ('Outros');






INSERT INTO Fornecedor ( 
    NomeFornecedor, 
    RuaFornecedor, 
    CodigoPostalCP
) 
VALUES
('Auto Supplies Ltda', 'Rua das Flores, 123', 4720300),
('Carros e Pe�as', 'Avenida Central, 456', 4700300),
('Motor Parts SA', 'Travessa dos Motores, 789', 4840080),
( 'Ve�culos e Servi�os', 'Estrada Velha, 321', 4750810),
( 'Distribuidora de Autos', 'Rua Nova, 654', 4806909),
( 'Pe�as & Cia', 'Avenida Autom�vel, 987', 4720300),
( 'Global Motors', 'Rua Internacional, 111', 4700300),
( 'Auto Equipamentos', 'Pra�a Mec�nica, 222', 4750810),
( 'Fornecedores Gerais', 'Rua Principal, 333', 4750810),
( 'Autocenter Completo', 'Alameda das M�quinas, 444', 4750810);





INSERT INTO Veiculo (MatriculaVeiculo, LotacaoVeiculo,TaraVeiculo, DescCor, DataLegal, DataFabricacao, DataAquisicao, DisponibilidadeVeiculo, 
ValorDiarioVeiculo, ModeloVeiculoIDModelo, ClasseVeiculoIDClasseVeiculo, EstadoVeiculoIDEstadoVeiculo, FornecedorIDFornecedor) 
VALUES
-- Tesla Model Y (Excelente)
('AA-16-PP', 5, 1600, 'Azul', '2023-06-01', '2023-03-15', '2023-05-01', NULL, 120, 6, 6, 1, 2),
-- Honda Civic (Excelente)
('AA-01-AA', 5, 1200, 'Preto', '2022-05-01', '2022-02-01', '2022-04-15', NULL, 50, 1, 6, 1, 1),
-- Toyota Hilux (Muito Bom)
('BB-02-BB', 2, 2500, 'Branco', '2021-06-15', '2021-03-01', '2021-06-01', NULL, 80, 4, 9, 2, 2),
-- BMW Serie 1 (Bom)
('CC-03-CC', 5, 1500, 'Azul', '2023-03-20', '2023-01-15', '2023-03-01', NULL, 90, 8, 7, 3, 3),
-- Ford Kuga (Utiliz�vel)
('DD-04-DD', 4, 1800, 'Vermelho', '2020-12-10', '2020-10-01', '2020-11-15', NULL, 60, 9, 7, 4, 4),
-- Renault Talisman (Muito Bom)
('EE-05-EE', 5, 1400, 'Prata', '2019-07-07', '2019-05-01', '2019-06-01', NULL, 70, 14, 6, 2, 5),
-- Tesla Y (Excelente)
('FF-06-FF', 5, 1600, 'Branco', '2023-05-01', '2023-03-01', '2023-04-01', NULL, 120, 6, 6, 1, 1),
-- Volkswagen Golf 7 (Muito Bom)
('GG-07-GG', 5, 1400, 'Cinza', '2021-04-01', '2020-11-01', '2021-03-15', NULL, 75, 11, 6, 2, 3),
-- Nissan Sentra (Bom)
('HH-08-HH', 5, 1250, 'Preto', '2020-10-10', '2020-07-01', '2020-09-01', NULL, 65, 16, 6, 3, 2),
-- Jeep Wrangler (Utiliz�vel)
('II-09-II', 5, 2000, 'Verde', '2018-05-15', '2018-02-01', '2018-04-01', NULL, 80, 20, 7, 4, 4),
-- Kia Xceed (Muito Bom)
('JJ-10-JJ', 5, 1350, 'Azul Escuro', '2021-11-01', '2021-07-01', '2021-10-01', NULL, 85, 19, 6, 2, 5),
-- Mitsubishi Pajero (Obsoleto)
('KK-11-KK', 7, 2500, 'Prata', '2015-09-01', '2015-06-01', '2015-08-01', NULL, 50, 23, 7, 5, 6),
-- Opel Corsa (Excelente)
('LL-12-LL', 5, 1250, 'Amarelo', '2022-03-01', '2021-12-01', '2022-02-01', NULL, 60, 13, 6, 1, 1),
-- Chevrolet Camaro (Muito Bom)
('MM-13-MM', 4, 1600, 'Vermelho', '2022-10-01', '2022-08-01', '2022-09-01', NULL, 110, 17, 7, 2, 4),
-- Hyundai i20 (Bom)
('NN-14-NN', 5, 1400, 'Cinza', '2020-07-01', '2020-04-01', '2020-06-01', NULL, 70, 10, 6, 3, 3),
-- Ford Fiesta (Utiliz�vel)
('OO-15-OO', 5, 1300, 'Branco', '2019-06-15', '2019-03-01', '2019-05-15', NULL, 55, 10, 6, 4, 2),
-- Tesla Model Y (Excelente)
('PP-16-PP', 5, 1600, 'Azul', '2023-06-01', '2023-03-15', '2023-05-01', NULL, 120, 6, 6, 1, 1);





INSERT INTO Seguro (
    ApoliceSeguro, 
    DataRenovacao, 
    ValorInicial, 
    DescSeguro, 
    VeiculoIDVeiculo, 
    SeguradoraIDSeguradora
)
VALUES
('APL123456789', '2024-01-15', 500, 'Cobertura total', 11, 1),
('APL987654321', '2024-03-10', 450, 'Cobertura contra terceiros', 2, 2),
('APL456789123', '2024-06-20', 600, 'Cobertura de danos pr�prios', 3, 3),
('APL654321987', '2024-09-05', 550, 'Cobertura contra furto e roubo', 4, 4),
('APL321654987', '2024-12-15', 700, 'Seguro completo', 5, 5),
('APL852963741', '2025-02-25', 400, 'Cobertura b�sica', 6, 6),
('APL741852963', '2025-05-10', 650, 'Cobertura de acidentes', 7, 7),
('APL963852741', '2025-07-01', 300, 'Seguro de responsabilidade civil', 8, 8),
('APL147258369', '2025-10-15', 500, 'Cobertura contra fogo', 9, 9),
('APL369258147', '2026-01-01', 800, 'Cobertura total premium', 10, 10);





INSERT INTO Despesa (
    VeiculoIDVeiculo, 
    TipoDespesaIDTDespesa, 
    ValorDespesa, 
    DataPagDes
)
VALUES
(3, 3, 500, '2022-03-20'), -- Exemplo: impostos para ve�culo com ID 3
(3, 1, 120, '2022-04-05'), -- Exemplo: combust�vel para ve�culo com ID 4
(5, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(4, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(6, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(7, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(8, 2, 300, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(2, 2, 100, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(9, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(10, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(11, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(12, 2, 200, '2022-05-30'), -- Exemplo: manuten��o para ve�culo com ID 5
(2, 1, 150, '2024-01-10'), -- Exemplo: combust�vel para ve�culo com ID 2
(2, 2, 300, '2024-02-15'), -- Exemplo: manuten��o para ve�culo com ID 2
(3, 3, 500, '2024-03-20'), -- Exemplo: impostos para ve�culo com ID 3
(4, 1, 120, '2024-04-05'), -- Exemplo: combust�vel para ve�culo com ID 4
(5, 2, 200, '2024-05-30'); -- Exemplo: manuten��o para ve�culo com ID 5





INSERT INTO TipoCliente (DescTC) VALUES 
('Particular'), ('Empresa'), ('Institui��o P�blica'), ('ONG'), 
('Cooperativa'), ('Estudante'), ('Professor'), ('Cliente Premium'), 
('Idoso'), ('Empresa Multinacional'), ('Startup'), ('Fornecedor'), 
('Parceiro'), ('Cliente Tempor�rio'), ('VIP');




INSERT INTO Cliente (
    NomeCliente, 
    DataNascCliente, 
    NIFCliente, 
    RuaCliente, 
    TipoClienteIDTC, 
    CodigoPostalCP
)
VALUES
-- Clientes variados
('Paulo Almeida', '1992-04-10', 112223334, 'Rua das Palmeiras, 200', 5, 4720300), -- Cooperativa
('Helena Ferreira', '1998-11-23', 223344556, 'Av. do Litoral, 45', 6, 4700300), -- Estudante
('Miguel Duarte', '1983-08-16', 334455667, 'Travessa das Oliveiras, 15', 7, 4840080), -- Professor
('Carla Martins', '1970-09-30', 445566778, 'Pra�a do Com�rcio, 89', 8, 4750810), -- Cliente Premium
('Rita Fonseca', '1948-02-14', 556677889, 'Largo da Paz, 50', 9, 4806909), -- Idoso
-- Clientes corporativos
('Empresa ABC', NULL, 667788990, 'Parque Industrial, 1', 10, 4720300), -- Empresa Multinacional
('Startup XYZ', NULL, 778899001, 'Rua Inova��o, 300', 11, 4700300), -- Startup
('Distribuidora Central', NULL, 889900112, 'Rua dos Fornecedores, 55', 12, 4840080), -- Fornecedor
('Jo�o & Associados', NULL, 990011223, 'Avenida Principal, 78', 13, 4750810), -- Parceiro
-- Outros clientes especiais
('Francisco Lopes', '1995-06-01', 101112131, 'Estrada Nacional, 12', 14, 4806909), -- Cliente Tempor�rio
('Sofia Andrade', '1980-03-18', 121314151, 'Rua VIP, 5', 15, 4720300); -- VIP




Insert into HabilitacaoCliente( ClienteIDCliente, ClasseVeiculoIDClasseVeiculo, DataHabilitacao) Values
(1,6,'2010-03-18'),(1,7,'2021-03-18')
,(2,7,'2018-03-18'),(3,5,'2003-03-18')
,(3,7,'2007-03-18'),(4,3,'1990-03-18')
,(4,7,'1995-03-18'),(5,2,'1980-03-18')
,(5,10,'1980-03-18'),(5,7,'1980-03-18')
,(10,5,'2015-03-18'),(11,5,'2000-03-18');




INSERT INTO Aluguer (VeiculoIDVeiculo, ClienteIDCliente, DataLevantamento, DataEntregaPrevista, DataDevolucao) 
VALUES
-- Cliente 1 aluga o ve�culo 2 (conclu�do)
(2, 1, '2024-01-05', '2024-01-12', '2024-01-12'),
-- Cliente 2 aluga o ve�culo 4 (conclu�do)
(4, 2, '2024-02-15', '2024-02-20', '2024-02-20'),
-- Cliente 3 aluga o ve�culo 6 (em andamento)
(6, 3, '2024-03-10', '2024-03-17', NULL),
-- Cliente 4 aluga o ve�culo 9 (conclu�do)
(9, 4, '2024-04-01', '2024-04-08', '2024-04-07'),
-- Cliente 5 aluga o ve�culo 11 (conclu�do)
(11, 5, '2024-05-20', '2024-05-25', '2024-05-25'),
-- Cliente 6 aluga o ve�culo 14 (em andamento)
(14, 6, '2024-06-01', '2024-06-07', NULL),
-- Cliente 7 aluga o ve�culo 3 (conclu�do)
(3, 7, '2024-07-15', '2024-07-20', '2024-07-19'),
-- Cliente 8 aluga o ve�culo 8 (conclu�do)
(8, 8, '2024-08-01', '2024-08-10', '2024-08-10'),
-- Cliente 9 aluga o ve�culo 10 (em andamento)
(10, 9, '2024-09-05', '2024-09-12', NULL),
-- Cliente 10 aluga o ve�culo 5 (conclu�do)
(5, 10, '2024-10-10', '2024-10-17', '2024-10-16'),
-- Cliente 11 aluga o ve�culo 12 (em andamento)
(12, 11, '2024-11-01', '2024-11-08', NULL),
-- Cliente 12 aluga o ve�culo 7 (conclu�do)
(7, 7, '2024-11-15', '2024-11-20', '2024-11-20'),
-- Cliente 13 aluga o ve�culo 13 (em andamento)
(13, 8, '2024-12-01', '2024-12-10', NULL),
-- Cliente 14 aluga o ve�culo 15 (conclu�do)
(15, 9, '2024-12-03', '2024-12-06', '2024-12-06'),
-- Cliente 15 aluga o ve�culo 16 (conclu�do)
(16, 10, '2024-12-07', '2024-12-14', '2024-12-13'),
-- Cliente 16 aluga o ve�culo 1 (em andamento)
(2, 11, '2024-12-10', '2024-12-17', NULL),
(2, 1, '2019-01-12', '2024-01-12', '2019-01-24'),
(17, 1, '2019-01-12', '2024-01-12', '2019-01-24');






INSERT INTO Feedback (AluguerIDAluguer, Classificacao, DescOpiniao) 
VALUES
(25, 9, '�tima experi�ncia, recomendo a empresa.'),
(26, 10, 'Tudo perfeito, ve�culo em �timo estado!'),
(27, 8, 'Servi�o bom, mas o ve�culo atrasou na entrega.'),
(34, 6, 'Servi�o dentro do esperado, mas pode melhorar.'),
(35, 7, 'Boa experi�ncia, mas o atendimento foi lento.'),
(36, 3, 'Ve�culo em condi��es abaixo do esperado.'),
(37, 4, 'Houve atraso na devolu��o e no suporte t�cnico.'),
(38, 10, 'Impec�vel, utilizarei novamente!'),
(39, 5, 'Pre�o elevado, mas razo�vel pelo servi�o.'),
(40, 2, 'Problemas com documenta��o e atendimento.'),
(31, 1, 'Experi�ncia p�ssima, n�o recomendo.'),
(32, 9, 'Tudo excelente, mas o processo de pagamento foi demorado.'),
(33, 8, 'Gostei muito, mas o ve�culo tinha alguns arranh�es.'),
(28, 10, 'Servi�o fant�stico, parab�ns � equipe!'),
(29, 7, 'Satisfeito, mas o suporte poderia ser mais r�pido.'),
(30, 6, 'Boa experi�ncia, mas h� espa�o para melhorias.');




INSERT INTO EmpresaParceira (NomeEParceira, RuaEParceira, CodigoPostalCP) VALUES
('Alpha Transportes', 'Rua Principal 10', 4720300),
('Beta Log�stica', 'Av. das Flores 45', 4700300),
('Gamma Manuten��es', 'Travessa Nova 23', 4840080),
('Delta Rent-a-Car', 'Rua Central 89', 4750810),
('Epsilon Servi�os', 'Alameda Verde 12', 4720300),
('Zeta Mec�nica', 'Estrada Velha 56', 4700300),
('Eta Transportadora', 'Pra�a Azul 78', 4840080),
('Theta Autom�veis', 'Rua das Palmeiras 34', 4750810),
('Iota Distribui��o', 'Beco do Sol 67', 4806909),
('Kappa Frotas', 'Viela das Rosas 21', 4720300),
('Lambda Reboques', 'Largo do Norte 98', 4700300),
('Mu Assist�ncia', 'Avenida Leste 88', 4840080),
('Nu Parcerias', 'Rua da Lua 59', 4750810),
('Xi Log�stica', 'Rua Estreita 12', 4806909),
('Omicron Transportes', 'Estrada Nova 77', 4720300);





INSERT INTO Manutencao (DataManutencao, DescManutencao, EmpresaParceiraIDEParceira, VeiculoIDVeiculo) VALUES
('2023-05-20', 'Troca de filtro de ar', 11, 11), 
('2023-05-25', 'Conserto de retrovisores', 12, 12), 
('2023-05-30', 'Revis�o el�trica', 13, 13), 
('2023-06-01', 'Troca de �leo', 14, 14), 
('2023-06-05', 'Manuten��o preventiva', 15, 15),
('2024-04-01', 'Troca de �leo', 1, 16), 
('2024-04-05', 'Substitui��o de pneus', 2, 2), 
('2024-04-10', 'Alinhamento e balanceamento', 3, 3), 
('2024-04-15', 'Revis�o geral', 4, 4), 
('2024-04-20', 'Conserto de lanternas', 5, 5), 
('2024-04-25', 'Substitui��o de bateria', 6, 6), 
('2024-04-30', 'Reparo no motor', 7, 7), 
('2024-05-05', 'Troca de correias', 8, 8), 
('2024-05-10', 'Revis�o de freios', 9, 9), 
('2024-05-15', 'Lavagem completa', 10, 10), 
('2024-05-20', 'Troca de filtro de ar', 11, 11), 
('2024-05-25', 'Conserto de retrovisores', 12, 12), 
('2024-05-30', 'Revis�o el�trica', 13, 13), 
('2024-06-01', 'Troca de �leo', 14, 14), 
('2024-06-05', 'Manuten��o preventiva', 15, 15);






INSERT INTO Infracoes (ClienteIDCliente, TipoInfracaoIDTInfracao, AluguerIDAluguer) VALUES
 (1, 3, 25), (2, 4, 26), 
(3, 5, 27), (4, 6, 28);