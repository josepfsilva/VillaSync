CREATE TABLE [dbo].[Agente_Imobiliario] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [pnome]   NVARCHAR (50) NOT NULL,
    [unome]   NVARCHAR (50) NOT NULL,
    [nif]     NVARCHAR (9)  NOT NULL,
    [salario] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Cliente] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [pnome] NVARCHAR (50) NOT NULL,
    [unome] NVARCHAR (50) NOT NULL,
    [nif]   NVARCHAR (9)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Propriedade] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [localizacao]  NVARCHAR (100) NOT NULL,
    [m_quadrados]  INT            NOT NULL,
    [n_pisos]      INT            NOT NULL,
    [n_quartos]    INT            NOT NULL,
    [n_wc]         INT            NOT NULL,
    [cert_energ]   NVARCHAR (1)   NOT NULL,
    [garagem]      BIT   NOT NULL,
    [id_empregado] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Propriedades_Agente] FOREIGN KEY ([id_empregado]) REFERENCES [dbo].[Agente_Imobiliario] ([Id])
);

CREATE TABLE [dbo].[Apartamento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [andar]          INT NOT NULL,
    [elevador]       BIT NOT NULL,
    [id_propriedade] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Apartamento_Propriedade] FOREIGN KEY ([id_propriedade]) REFERENCES [dbo].[Propriedade] ([Id])
);

CREATE TABLE [dbo].[Moradia] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [area_exterior]  INT NOT NULL,
    [id_propriedade] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Moradia_Propriedade] FOREIGN KEY ([id_propriedade]) REFERENCES [dbo].[Propriedade] ([Id])
);

CREATE TABLE [dbo].[Visita] (
    [Id]             INT      IDENTITY (1, 1) NOT NULL,
    [data_hora]      DATETIME NOT NULL,
    [id_cliente]     INT      NOT NULL,
    [id_propriedade] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Visita_Cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[Cliente] ([Id]),
    CONSTRAINT [FK_Visita_Propriedade] FOREIGN KEY ([id_propriedade]) REFERENCES [dbo].[Propriedade] ([Id])
);

CREATE TABLE [dbo].[Contrato] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [valor]         INT NOT NULL,
    [id_cliente]    INT NOT NULL,
    [id_propridade] INT NOT NULL,
    [id_visita]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contrato_Cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[Cliente] ([Id]),
    CONSTRAINT [FK_Contrato_Propriedade] FOREIGN KEY ([id_propridade]) REFERENCES [dbo].[Propriedade] ([Id]),
    CONSTRAINT [FK_Contrato_Visita] FOREIGN KEY ([id_visita]) REFERENCES [dbo].[Visita] ([Id])
);

CREATE TABLE [dbo].[Anuncio] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]      NVARCHAR (50)  NOT NULL,
    [Descricao]   NVARCHAR (100) NOT NULL,
    [id_contrato] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Anuncio_Contrato] FOREIGN KEY ([id_contrato]) REFERENCES [dbo].[Contrato] ([Id])
);

CREATE TABLE [dbo].[Oferta] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [estado]       NVARCHAR (50) NOT NULL,
    [valor_oferta] INT           NOT NULL,
    [id_anuncio]   INT           NOT NULL,
    [id_cliente]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Oferta_Anuncio] FOREIGN KEY ([id_anuncio]) REFERENCES [dbo].[Anuncio] ([Id]),
    CONSTRAINT [FK_Oferta_Cliente] FOREIGN KEY ([id_cliente]) REFERENCES [dbo].[Cliente] ([Id])
);

CREATE TABLE [dbo].[Apresentacao_Imovel] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [id_visita] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Apresentacao_Imovel_Visita] FOREIGN KEY ([id_visita]) REFERENCES [dbo].[Visita] ([Id])
);



CREATE TABLE [dbo].[Avaliacao_Imobiliaria] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [id_visita]       INT NOT NULL,
    [valor_avaliacao] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Avaliacao_Imobiliaria_Visita] FOREIGN KEY ([id_visita]) REFERENCES [dbo].[Visita] ([Id])
);








