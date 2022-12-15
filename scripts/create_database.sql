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

CREATE TABLE [Cliente] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Cnpj] varchar(14) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contrato] (
    [Id] uniqueidentifier NOT NULL,
    [ConsultaId] uniqueidentifier NOT NULL,
    [Data_Vigencia] datetime2 NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Contrato] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Fornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_Fornecedor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Operacao] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Data_Operacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Operacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PlanoTarifacao] (
    [Id] uniqueidentifier NOT NULL,
    [Data_Vigencia] datetime2 NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_PlanoTarifacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Telefone] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Numero] varchar(13) NOT NULL,
    [TipoTelefone] varchar(50) NOT NULL,
    CONSTRAINT [PK_Telefone] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Telefone_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [Login] varchar(50) NOT NULL,
    [Senha] varchar(8) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuario_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id])
);
GO

CREATE TABLE [Consulta] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [PlanoTarifacaoId] uniqueidentifier NOT NULL,
    [Contrato] uniqueidentifier NULL,
    [Login] varchar(50) NOT NULL,
    [Senha] varchar(8) NOT NULL,
    CONSTRAINT [PK_Consulta] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Consulta_Contrato_Contrato] FOREIGN KEY ([Contrato]) REFERENCES [Contrato] ([Id]),
    CONSTRAINT [FK_Consulta_Fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedor] ([Id]),
    CONSTRAINT [FK_Consulta_PlanoTarifacao_PlanoTarifacaoId] FOREIGN KEY ([PlanoTarifacaoId]) REFERENCES [PlanoTarifacao] ([Id])
);
GO

CREATE TABLE [OperacaoUsuario] (
    [OperacoesId] uniqueidentifier NOT NULL,
    [UsuariosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_OperacaoUsuario] PRIMARY KEY ([OperacoesId], [UsuariosId]),
    CONSTRAINT [FK_OperacaoUsuario_Operacao_OperacoesId] FOREIGN KEY ([OperacoesId]) REFERENCES [Operacao] ([Id]),
    CONSTRAINT [FK_OperacaoUsuario_Usuario_UsuariosId] FOREIGN KEY ([UsuariosId]) REFERENCES [Usuario] ([Id])
);
GO

CREATE TABLE [ClienteConsulta] (
    [ClientesId] uniqueidentifier NOT NULL,
    [ConsultasId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ClienteConsulta] PRIMARY KEY ([ClientesId], [ConsultasId]),
    CONSTRAINT [FK_ClienteConsulta_Cliente_ClientesId] FOREIGN KEY ([ClientesId]) REFERENCES [Cliente] ([Id]),
    CONSTRAINT [FK_ClienteConsulta_Consulta_ConsultasId] FOREIGN KEY ([ConsultasId]) REFERENCES [Consulta] ([Id])
);
GO

CREATE INDEX [IX_ClienteConsulta_ConsultasId] ON [ClienteConsulta] ([ConsultasId]);
GO

CREATE UNIQUE INDEX [IX_Consulta_Contrato] ON [Consulta] ([Contrato]) WHERE [Contrato] IS NOT NULL;
GO

CREATE INDEX [IX_Consulta_FornecedorId] ON [Consulta] ([FornecedorId]);
GO

CREATE INDEX [IX_Consulta_PlanoTarifacaoId] ON [Consulta] ([PlanoTarifacaoId]);
GO

CREATE INDEX [IX_OperacaoUsuario_UsuariosId] ON [OperacaoUsuario] ([UsuariosId]);
GO

CREATE INDEX [IX_Telefone_ClienteId] ON [Telefone] ([ClienteId]);
GO

CREATE INDEX [IX_Usuario_ClienteId] ON [Usuario] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221215190626_InitialMigration', N'7.0.1');
GO

COMMIT;
GO

