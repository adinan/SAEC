--Criar um banco e rodar o seguinte comando nele:


CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cpf] [varchar](12) NOT NULL,
	[Sexo] [int] NOT NULL,
	[Telefone] [varchar](50) NOT NULL,
	[CidadeId] [int] NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[Senha] [varchar](256) NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[Cep] [varchar](100) NOT NULL,
	[DataCadastro] [date] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Rg] [varchar](100) NOT NULL,
	[Cpf] [varchar](12) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Matricula] [varchar](100) NOT NULL,
	[Idade] [int] NOT NULL,
	[Sexo] [int] NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[Telefone] [varchar](100) NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[ResponsavelId] [int] NOT NULL,
	[CidadeId] [int] NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cidade] ([Id])
GO

ALTER TABLE [dbo].[Aluno] CHECK CONSTRAINT [FK_Aluno_Cidade]
GO


CREATE TABLE [dbo].[ResponsavelAluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoResponsavel] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Rg] [varchar](100) NOT NULL,
	[Cpf] [varchar](12) NOT NULL,
	[Profissao] [varchar](100) NOT NULL,
	[Celular] [varchar](50) NOT NULL,
	[DataUltimaAlteracao] [date] NOT NULL,
	[UsuarioIdAlteracao] [int] NOT NULL,
	[DataCadastro] [date] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ResponsavelAluno]  WITH CHECK ADD  CONSTRAINT [FK_ResponsavelAluno_Aluno] FOREIGN KEY([Id])
REFERENCES [dbo].[Aluno] ([Id])
GO

ALTER TABLE [dbo].[ResponsavelAluno] CHECK CONSTRAINT [FK_ResponsavelAluno_Aluno]
GO

ALTER TABLE [dbo].[ResponsavelAluno]  WITH CHECK ADD  CONSTRAINT [FK_ResponsavelAluno_Usuario] FOREIGN KEY([UsuarioIdAlteracao])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[ResponsavelAluno] CHECK CONSTRAINT [FK_ResponsavelAluno_Usuario]
GO


