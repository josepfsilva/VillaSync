-- Insert into Agente_Imobiliario
INSERT INTO [dbo].[Agente_Imobiliario] (pnome, unome, nif, salario) VALUES ('John', 'Doe', '123456789', 5000);
INSERT INTO [dbo].[Agente_Imobiliario] (pnome, unome, nif, salario) VALUES ('Jane', 'Smith', '987654321', 6000);

-- Insert into Cliente
INSERT INTO [dbo].[Cliente] (pnome, unome, nif) VALUES ('Alice', 'Johnson', '123123123');
INSERT INTO [dbo].[Cliente] (pnome, unome, nif) VALUES ('Bob', 'Williams', '321321321');

-- Insert into Propriedade
INSERT INTO [dbo].[Propriedade] (localizacao, m_quadrados, n_pisos, n_quartos, n_wc, cert_energ, garagem, id_empregado) VALUES ('Location 1', 100, 2, 3, 2, 'A', 1, 1);
INSERT INTO [dbo].[Propriedade] (localizacao, m_quadrados, n_pisos, n_quartos, n_wc, cert_energ, garagem, id_empregado) VALUES ('Location 2', 200, 3, 4, 3, 'B', 0, 2);

-- Insert into Apartamento
INSERT INTO [dbo].[Apartamento] (andar, elevador, id_propriedade) VALUES (5, 1, 1);
INSERT INTO [dbo].[Apartamento] (andar, elevador, id_propriedade) VALUES (10, 1, 2);

-- Insert into Moradia
INSERT INTO [dbo].[Moradia] (area_exterior, id_propriedade) VALUES (50, 1);
INSERT INTO [dbo].[Moradia] (area_exterior, id_propriedade) VALUES (100, 2);

-- Insert into Visita
INSERT INTO [dbo].[Visita] (data_hora, id_cliente, id_propriedade) VALUES ('2022-01-01 10:00:00', 1, 1);
INSERT INTO [dbo].[Visita] (data_hora, id_cliente, id_propriedade) VALUES ('2022-01-02 11:00:00', 2, 2);

-- Insert into Contrato
INSERT INTO [dbo].[Contrato] (valor, id_cliente, id_propridade, id_visita) VALUES (100000, 1, 1, 1);
INSERT INTO [dbo].[Contrato] (valor, id_cliente, id_propridade, id_visita) VALUES (200000, 2, 2, 2);

-- Insert into Anuncio
INSERT INTO [dbo].[Anuncio] (Titulo, Descricao, id_contrato) VALUES ('Ad 1', 'Description 1', 1);
INSERT INTO [dbo].[Anuncio] (Titulo, Descricao, id_contrato) VALUES ('Ad 2', 'Description 2', 2);

-- Insert into Oferta
INSERT INTO [dbo].[Oferta] (estado, valor_oferta, id_anuncio, id_cliente) VALUES ('Open', 90000, 1, 1);
INSERT INTO [dbo].[Oferta] (estado, valor_oferta, id_anuncio, id_cliente) VALUES ('Open', 190000, 2, 2);

-- Insert into Apresentacao_Imovel
INSERT INTO [dbo].[Apresentacao_Imovel] (id_visita) VALUES (1);
INSERT INTO [dbo].[Apresentacao_Imovel] (id_visita) VALUES (2);

-- Insert into Avaliacao_Imobiliaria
INSERT INTO [dbo].[Avaliacao_Imobiliaria] (id_visita, valor_avaliacao) VALUES (1, 95000);
INSERT INTO [dbo].[Avaliacao_Imobiliaria] (id_visita, valor_avaliacao) VALUES (2, 195000);