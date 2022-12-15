IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome_PrimeiroNome] varchar(100) NOT NULL,
    [Nome_SobreNome] varchar(100) NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Cnpj] varchar(14) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contratos] (
    [Id] uniqueidentifier NOT NULL,
    [Data_Vigencia] datetime2 NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Contratos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Fornecedores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Operacoes] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Data_Operacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Operacoes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Planos_Tarifacao] (
    [Id] uniqueidentifier NOT NULL,
    [Data_Vigencia] datetime2 NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Planos_Tarifacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Telefones] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Numero] varchar(13) NOT NULL,
    [TipoTelefone] varchar(50) NOT NULL,
    CONSTRAINT [PK_Telefones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Telefones_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Login] varchar(50) NOT NULL,
    [Senha] varchar(8) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id])
);
GO

CREATE TABLE [Consultas] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [PlanoTarifacaoId] uniqueidentifier NOT NULL,
    [Login] varchar(50) NOT NULL,
    [Senha] varchar(8) NOT NULL,
    CONSTRAINT [PK_Consultas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Consultas_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id]),
    CONSTRAINT [FK_Consultas_Planos_Tarifacao_PlanoTarifacaoId] FOREIGN KEY ([PlanoTarifacaoId]) REFERENCES [Planos_Tarifacao] ([Id])
);
GO

CREATE TABLE [OperacaoUsuario] (
    [OperacoesId] uniqueidentifier NOT NULL,
    [UsuariosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_OperacaoUsuario] PRIMARY KEY ([OperacoesId], [UsuariosId]),
    CONSTRAINT [FK_OperacaoUsuario_Operacoes_OperacoesId] FOREIGN KEY ([OperacoesId]) REFERENCES [Operacoes] ([Id]),
    CONSTRAINT [FK_OperacaoUsuario_Usuarios_UsuariosId] FOREIGN KEY ([UsuariosId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [ClienteConsulta] (
    [ClientesId] uniqueidentifier NOT NULL,
    [ConsultasId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ClienteConsulta] PRIMARY KEY ([ClientesId], [ConsultasId]),
    CONSTRAINT [FK_ClienteConsulta_Clientes_ClientesId] FOREIGN KEY ([ClientesId]) REFERENCES [Clientes] ([Id]),
    CONSTRAINT [FK_ClienteConsulta_Consultas_ConsultasId] FOREIGN KEY ([ConsultasId]) REFERENCES [Consultas] ([Id])
);
GO

CREATE TABLE [Contratados] (
    [Id] uniqueidentifier NOT NULL,
    [ContratoId] uniqueidentifier NOT NULL,
    [ConsultaId] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Contratados] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contratados_Consultas_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consultas] ([Id]),
    CONSTRAINT [FK_Contratados_Contratos_ContratoId] FOREIGN KEY ([ContratoId]) REFERENCES [Contratos] ([Id]),
    CONSTRAINT [FK_Contratados_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id])
);
GO

CREATE INDEX [IX_ClienteConsulta_ConsultasId] ON [ClienteConsulta] ([ConsultasId]);
GO

CREATE INDEX [IX_Consultas_FornecedorId] ON [Consultas] ([FornecedorId]);
GO

CREATE INDEX [IX_Consultas_PlanoTarifacaoId] ON [Consultas] ([PlanoTarifacaoId]);
GO

CREATE UNIQUE INDEX [IX_Contratados_ConsultaId] ON [Contratados] ([ConsultaId]);
GO

CREATE INDEX [IX_Contratados_ContratoId] ON [Contratados] ([ContratoId]);
GO

CREATE UNIQUE INDEX [IX_Contratados_FornecedorId] ON [Contratados] ([FornecedorId]);
GO

CREATE INDEX [IX_OperacaoUsuario_UsuariosId] ON [OperacaoUsuario] ([UsuariosId]);
GO

CREATE INDEX [IX_Telefones_ClienteId] ON [Telefones] ([ClienteId]);
GO

CREATE INDEX [IX_Usuarios_ClienteId] ON [Usuarios] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221214191046_InicialSetup', N'7.0.1');
GO

COMMIT;
GO

