--1. Quantos veiculos foram alugados no dia 12 de janeiro de 2019 mas que nunca precissaram de uma manutenção

	Select Count( Distinct VeiculoIDVeiculo)
	From Aluguer
	Where DataLevantamento = '2019-01-12' 
	AND VeiculoIDVeiculo not in (Select VeiculoIDVeiculo
		From Manutencao)

--2. Qual o Cliente que realizou mais alugueres

	Select IdCliente, NomeCliente, NAlugueres=count(IDAluguer)
	From Cliente Join Aluguer on Cliente.IDCliente=Aluguer.ClienteIDCliente
	Group by IdCliente, NomeCliente
	Having Count(IDAluguer) >= All (Select count(IDAluguer)
		From Cliente Join Aluguer on Cliente.IDCliente=Aluguer.ClienteIDCliente
		group by IDCliente)

--3. Quais os carros com mais de 2 anos foram alugados 3 ou mais vezes, deve mostra quantas vezes foi alugado

	Select Veiculo.IDVeiculo, Veiculo.MatriculaVeiculo, count (Aluguer.VeiculoIDVeiculo) as TotAlugueres
	From Veiculo Join Aluguer on Veiculo.IDVeiculo=Aluguer.VeiculoIDVeiculo
	Where DATEDIFF(YEAR, Veiculo.DataFabricacao, GETDATE()) >= 2
	Group by Veiculo.IDVeiculo, Veiculo.MatriculaVeiculo
	Having count (Aluguer.VeiculoIDVeiculo) >= 3


--4. Qual a marca cujo os veiculos sao mais alugados

	Select top 1 IDMarca, MarcaVeiculo.DescMarca, NAlugueres=Count(IDAluguer)
	From Aluguer Join Veiculo  on Aluguer.VeiculoIDVeiculo=Veiculo.IDVeiculo
		 Join ModeloVeiculo on Veiculo.ModeloVeiculoIDModelo=ModeloVeiculo.IDModelo
		 Join MarcaVeiculo on ModeloVeiculo.MarcaVeiculoIDMarca=MarcaVeiculo.IDMarca
	Group by IDMarca, MarcaVeiculo.DescMarca
	Having Count(IDAluguer) >= All (Select Count(IDAluguer)
		From Aluguer
		Group by IDAluguer)
	Order by NAlugueres Desc
	--OU
	Select IDMarca, DescMarca, Count(IDAluguer) as NAlugueres
	From Aluguer Join Veiculo  on Aluguer.VeiculoIDVeiculo=Veiculo.IDVeiculo
		 Join ModeloVeiculo on Veiculo.ModeloVeiculoIDModelo=ModeloVeiculo.IDModelo
		 Join MarcaVeiculo on ModeloVeiculo.MarcaVeiculoIDMarca=MarcaVeiculo.IDMarca
	Group by IDMarca, DescMarca
	Having Count(IDAluguer) >= All (Select Count(IDAluguer)
		From Aluguer Join Veiculo  on Aluguer.VeiculoIDVeiculo=Veiculo.IDVeiculo
		 Join ModeloVeiculo on Veiculo.ModeloVeiculoIDModelo=ModeloVeiculo.IDModelo
		 Join MarcaVeiculo on ModeloVeiculo.MarcaVeiculoIDMarca=MarcaVeiculo.IDMarca
	Group by IDMarca, DescMarca)

--4. Qual o veículo mais alugado por marca, deve apresentar o modelo

SELECT MarcaVeiculo.IDMarca, MarcaVeiculo.DescMarca, Veiculo.MatriculaVeiculo, ModeloVeiculo.DescModelo, MAX(AlugueresPorVeiculo.TotalAlugueres) AS TotalAlugueres
FROM 
    (SELECT MarcaVeiculo.IDMarca, Veiculo.IDVeiculo, COUNT(Aluguer.IDAluguer) AS TotalAlugueres
        FROM Aluguer JOIN Veiculo ON Aluguer.VeiculoIDVeiculo = Veiculo.IDVeiculo
					 JOIN ModeloVeiculo ON Veiculo.ModeloVeiculoIDModelo = ModeloVeiculo.IDModelo
				     JOIN MarcaVeiculo ON ModeloVeiculo.MarcaVeiculoIDMarca = MarcaVeiculo.IDMarca
        GROUP BY MarcaVeiculo.IDMarca, Veiculo.IDVeiculo) AS AlugueresPorVeiculo
    JOIN Veiculo ON AlugueresPorVeiculo.IDVeiculo = Veiculo.IDVeiculo
    JOIN ModeloVeiculo ON Veiculo.ModeloVeiculoIDModelo = ModeloVeiculo.IDModelo
    JOIN MarcaVeiculo ON ModeloVeiculo.MarcaVeiculoIDMarca = MarcaVeiculo.IDMarca
WHERE AlugueresPorVeiculo.IDVeiculo = (
        SELECT TOP 1 SubVeiculo.IDVeiculo
        FROM 
            (SELECT Veiculo.IDVeiculo, COUNT(Aluguer.IDAluguer) AS TotalAlugueres
             FROM Aluguer
                JOIN Veiculo ON Aluguer.VeiculoIDVeiculo = Veiculo.IDVeiculo
                JOIN ModeloVeiculo ON Veiculo.ModeloVeiculoIDModelo = ModeloVeiculo.IDModelo
                JOIN MarcaVeiculo ON ModeloVeiculo.MarcaVeiculoIDMarca = MarcaVeiculo.IDMarca
             WHERE MarcaVeiculo.IDMarca = AlugueresPorVeiculo.IDMarca
             GROUP BY Veiculo.IDVeiculo) AS SubVeiculo
        ORDER BY SubVeiculo.TotalAlugueres DESC)
GROUP BY MarcaVeiculo.IDMarca, MarcaVeiculo.DescMarca, Veiculo.MatriculaVeiculo, ModeloVeiculo.DescModelo
ORDER BY MarcaVeiculo.DescMarca;






--5.	Quais os 5 clientes com menos infrações

	Select TOP(5) Cliente.IDCliente, NomeCliente, COUNT(IDInfracao) AS TotalInfracoes
	From Cliente
		Left JOIN Infracoes ON Infracoes.ClienteIDCliente = Cliente.IDCliente
	GROUP BY Cliente.IDCliente, NomeCliente
	ORDER BY COUNT(IDInfracao) ASC;

--6. Quais os carros que realizaram manutenção no segundo trimestre de 2023

	Select Veiculo.IDveiculo, Veiculo.MatriculaVeiculo
	From Veiculo Join Manutencao on Veiculo.IDVeiculo=Manutencao.VeiculoIDVeiculo
	Where DataManutencao > '2023-04-01' AND DataManutencao < '2023-06-30'

--7. Quais os veículos, e as datas de aluguer se existirem, da seguradora “Fidelidade” 

	Select Distinct IDVeiculo, Aluguer.DataLevantamento as Levantamento, Aluguer.DataDevolucao as Devolocao
	From Veiculo Left Join Aluguer on Aluguer.VeiculoIDVeiculo=Veiculo.IDVeiculo
		 Join Seguro on Veiculo.IDVeiculo=Seguro.VeiculoIDVeiculo
		 Join Seguradora on Seguro.SeguradoraIDSeguradora=Seguradora.IDSeguradora
	Where Seguradora.DescSeguradora = 'Fidelidade'

--8. Qual a despesa anual dos 10 veículos com a despesa mais elevada no ano de 2022

	Select Top(10) Veiculo.IDVeiculo, Veiculo.MatriculaVeiculo, SUM(ValorDespesa) as DespesaTotal
	From Veiculo Join Despesa on Veiculo.IDVeiculo=Despesa.VeiculoIDVeiculo
	Where Year (DataPagDes) = '2022'
	Group by Veiculo.IDVeiculo, Veiculo.MatriculaVeiculo
	ORDER BY DespesaTotal DESC;

--9. Quais os modelos que foram fornecidos pela 1 e 2


	Select ModeloVeiculo.IDModelo, DescModelo
	From ModeloVeiculo Join Veiculo on ModeloVeiculo.IDModelo = Veiculo.ModeloVeiculoIDModelo
		Join Fornecedor on Veiculo.FornecedorIDFornecedor = Fornecedor.IDFornecedor
	Where NomeFornecedor = 'Auto Supplies Ltda' 
	Intersect
	Select ModeloVeiculo.IDModelo, DescModelo
	From ModeloVeiculo Join Veiculo on ModeloVeiculo.IDModelo = Veiculo.ModeloVeiculoIDModelo
		Join Fornecedor on Veiculo.FornecedorIDFornecedor = Fornecedor.IDFornecedor
	Where NomeFornecedor = 'Carros e Peças'


--10. Qual a média de classificação de cada marca (deve calcular primeiro a média por veiculo, e só depois por marca)

SELECT DescMarca, AVG(MediaA) AS MediaPorMarca
FROM (
    SELECT 
        Veiculo.IDVeiculo,
        MarcaVeiculo.DescMarca,
        AVG(Feedback.Classificacao) AS MediaA
    FROM Veiculo
    JOIN ModeloVeiculo 
        ON Veiculo.ModeloVeiculoIDModelo = ModeloVeiculo.IDModelo
    JOIN MarcaVeiculo 
        ON ModeloVeiculo.MarcaVeiculoIDMarca = MarcaVeiculo.IDMarca
    JOIN Aluguer 
        ON Veiculo.IDVeiculo = Aluguer.VeiculoIDVeiculo
    JOIN Feedback 
        ON Feedback.AluguerIDAluguer = Aluguer.IDAluguer
    GROUP BY Veiculo.IDVeiculo, MarcaVeiculo.DescMarca
) Media
GROUP BY Media.DescMarca;




	
