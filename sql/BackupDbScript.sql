USE [master]
GO

CREATE DATABASE [NerdStoreEnterprise]
GO

USE [NerdStoreEnterprise]
GO

/****** Object:  Sequence [dbo].[MinhaSequencia]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE SEQUENCE [dbo].[MinhaSequencia] 
 AS [int]
 START WITH 1000
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrinhoClientes]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrinhoClientes](
	[Id] [uniqueidentifier] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[Desconto] [decimal](18, 2) NOT NULL,
	[Percentual] [decimal](18, 2) NULL,
	[TipoDesconto] [int] NOT NULL,
	[ValorDesconto] [decimal](18, 2) NULL,
	[VoucherCodigo] [varchar](50) NOT NULL,
	[VoucherUtilizado] [bit] NOT NULL,
 CONSTRAINT [PK_CarrinhoClientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrinhoItens]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrinhoItens](
	[Id] [uniqueidentifier] NOT NULL,
	[ProdutoId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Imagem] [varchar](100) NOT NULL,
	[CarrinhoClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CarrinhoItens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Email] [varchar](254) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[Excluido] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[Id] [uniqueidentifier] NOT NULL,
	[Logradouro] [varchar](200) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Complemento] [varchar](250) NOT NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cep] [varchar](20) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagamentos]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamentos](
	[Id] [uniqueidentifier] NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
	[TipoPagamento] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Pagamentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItems]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItems](
	[Id] [uniqueidentifier] NOT NULL,
	[PedidoId] [uniqueidentifier] NOT NULL,
	[ProdutoId] [uniqueidentifier] NOT NULL,
	[ProdutoNome] [varchar](250) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[ValorUnitario] [decimal](18, 2) NOT NULL,
	[ProdutoImagem] [varchar](100) NULL,
 CONSTRAINT [PK_PedidoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [int] NOT NULL,
	[ClienteId] [uniqueidentifier] NOT NULL,
	[VoucherId] [uniqueidentifier] NULL,
	[VoucherUtilizado] [bit] NOT NULL,
	[Desconto] [decimal](18, 2) NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[PedidoStatus] [int] NOT NULL,
	[Logradouro] [varchar](100) NULL,
	[Numero] [varchar](100) NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](100) NULL,
	[Cep] [varchar](100) NULL,
	[Cidade] [varchar](100) NULL,
	[Estado] [varchar](100) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
	[Imagem] [varchar](250) NOT NULL,
	[QuantidadeEstoque] [int] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshTokens]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshTokens](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityKeys]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityKeys](
	[Id] [uniqueidentifier] NOT NULL,
	[KeyId] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Parameters] [nvarchar](max) NULL,
	[IsRevoked] [bit] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ExpiredAt] [datetime2](7) NULL,
 CONSTRAINT [PK_SecurityKeys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacoes]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacoes](
	[Id] [uniqueidentifier] NOT NULL,
	[CodigoAutorizacao] [varchar](100) NOT NULL,
	[BandeiraCartao] [varchar](100) NOT NULL,
	[DataTransacao] [datetime2](7) NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[CustoTransacao] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
	[TID] [varchar](100) NOT NULL,
	[NSU] [varchar](100) NOT NULL,
	[PagamentoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transacoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 9/16/2022 10:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Percentual] [decimal](18, 2) NULL,
	[ValorDesconto] [decimal](18, 2) NULL,
	[Quantidade] [int] NOT NULL,
	[TipoDesconto] [int] NOT NULL,
	[DataCriacao] [datetime2](7) NOT NULL,
	[DataUtilizacao] [datetime2](7) NULL,
	[DataValidade] [datetime2](7) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Utilizado] [bit] NOT NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619164623_Initial', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220714020855_Initial', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220730204032_Initial', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220820022700_Initial', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220826012809_CriacaoVoucher', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220827220349_AdicaoColunasVoucher', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220828013851_CriacaoPedidos', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220831020658_DeleteCascadeCarrinho', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220903222819_Initial', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220910014938_CriacaoSecurityKeys', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220910233611_CriacaoRefreshTokens', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON 

INSERT [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'09e0a7d1-31e2-47ed-b71a-88573778e868', N'Catalogo', N'Ler,Escrever,Editar,Remover')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'09e0a7d1-31e2-47ed-b71a-88573778e868', N'heikenem@teste.com', N'HEIKENEM@TESTE.COM', N'heikenem@teste.com', N'HEIKENEM@TESTE.COM', 1, N'AQAAAAEAACcQAAAAEL6CjHG75eQvxtskDmnOsOcz6DoudTwg/5hW6Dy1wrdzOZElDgjb8cNKn0D2/B4XGw==', N'YJ6C4QQQ7ZNFMFPHWN57OF3O3FRPUW5R', N'2f7790d3-6085-4b18-aec7-0479d1599ed1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6b2b3487-05fd-4a73-80e2-6f112e0e33d6', N'teste2@teste.com', N'TESTE2@TESTE.COM', N'teste2@teste.com', N'TESTE2@TESTE.COM', 1, N'AQAAAAEAACcQAAAAEC2LwKNw+s5B1RRmkw4hPGbnhS3MuXTPeFZ4KMFfkVQmzaUi5kY9bDi0b0Wb7ZOinA==', N'JZJCEFQOWCMFNKRCJLORAOULRLDEORXQ', N'730db11f-f6b0-4c6c-a266-5a9b592a9727', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a2c3193d-6e17-4e50-b812-281a83c70723', N'teste@teste.com', N'TESTE@TESTE.COM', N'teste@teste.com', N'TESTE@TESTE.COM', 1, N'AQAAAAEAACcQAAAAEEzwD+qPiHxIMccqgOZh51m0ixkDyEi+tVQ++blCy4/N/av/FsO0kcgPcO3edrYE3w==', N'7NSSBQ24EOUXW4SSH62ZA2NY6SV6RSMW', N'4f50fd86-2f01-45da-932f-7c81b383f452', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[CarrinhoClientes] ([Id], [ClienteId], [ValorTotal], [Desconto], [Percentual], [TipoDesconto], [ValorDesconto], [VoucherCodigo], [VoucherUtilizado]) VALUES (N'497ce747-4ddd-4b78-9aa1-68f3e95f4df1', N'09e0a7d1-31e2-47ed-b71a-88573778e868', CAST(370.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, N'', 0)
GO
INSERT [dbo].[CarrinhoItens] ([Id], [ProdutoId], [Nome], [Quantidade], [Valor], [Imagem], [CarrinhoClienteId]) VALUES (N'93c8c7f3-3f66-405c-b7bf-0298cf462c09', N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Code Life Preta', 3, CAST(90.00 AS Decimal(18, 2)), N'camiseta2.jpg', N'497ce747-4ddd-4b78-9aa1-68f3e95f4df1')
INSERT [dbo].[CarrinhoItens] ([Id], [ProdutoId], [Nome], [Quantidade], [Valor], [Imagem], [CarrinhoClienteId]) VALUES (N'aa7c24e6-32ff-49f8-960b-22fd6d0cce00', N'7d67df76-2d4e-4a47-a12c-08eb80a9060b', N'Camiseta 4 Head Branca', 1, CAST(50.00 AS Decimal(18, 2)), N'Branca 4head.webp', N'497ce747-4ddd-4b78-9aa1-68f3e95f4df1')
INSERT [dbo].[CarrinhoItens] ([Id], [ProdutoId], [Nome], [Quantidade], [Valor], [Imagem], [CarrinhoClienteId]) VALUES (N'5e7bbb90-be36-4617-9c4e-ce9af83312e4', N'7d67df76-2d4e-4a47-a14c-08eb80a9060b', N'Camiseta Tiltado Branca', 1, CAST(50.00 AS Decimal(18, 2)), N'Branco Tiltado.webp', N'497ce747-4ddd-4b78-9aa1-68f3e95f4df1')
GO
INSERT [dbo].[Clientes] ([Id], [Nome], [Email], [Cpf], [Excluido]) VALUES (N'a2c3193d-6e17-4e50-b812-281a83c70723', N'Usuário Teste', N'teste@teste.com', N'93265294013', 0)
INSERT [dbo].[Clientes] ([Id], [Nome], [Email], [Cpf], [Excluido]) VALUES (N'6b2b3487-05fd-4a73-80e2-6f112e0e33d6', N'Usuário teste 2', N'teste2@teste.com', N'32379229007', 0)
INSERT [dbo].[Clientes] ([Id], [Nome], [Email], [Cpf], [Excluido]) VALUES (N'09e0a7d1-31e2-47ed-b71a-88573778e868', N'Harã Heique', N'heikenem@teste.com', N'15192070775', 0)
GO
INSERT [dbo].[Enderecos] ([Id], [Logradouro], [Numero], [Complemento], [Bairro], [Cep], [Cidade], [Estado], [ClienteId]) VALUES (N'1762f30a-9594-421d-dea5-08da8c860923', N'Rua Copo de Leite', N'35', N'Minha TIA!', N'Feu Rosa', N'29172115', N'Serra', N'ES', N'09e0a7d1-31e2-47ed-b71a-88573778e868')
GO
INSERT [dbo].[Pagamentos] ([Id], [PedidoId], [TipoPagamento], [Valor]) VALUES (N'bad8a11e-1219-4dc6-81d4-980ab5f2959c', N'318deeec-ad1a-43a8-95f2-0f2dcb985e6c', 1, CAST(50.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PedidoItems] ([Id], [PedidoId], [ProdutoId], [ProdutoNome], [Quantidade], [ValorUnitario], [ProdutoImagem]) VALUES (N'7400b9b3-4307-424d-ab07-b7203ca6b81f', N'318deeec-ad1a-43a8-95f2-0f2dcb985e6c', N'78162be3-61c4-4959-89d7-5ebfb476447e', N'Caneca Vegeta', 2, CAST(50.00 AS Decimal(18, 2)), N'caneca1-Vegeta.jpg')
GO
INSERT [dbo].[Pedidos] ([Id], [Codigo], [ClienteId], [VoucherId], [VoucherUtilizado], [Desconto], [ValorTotal], [DataCadastro], [PedidoStatus], [Logradouro], [Numero], [Complemento], [Bairro], [Cep], [Cidade], [Estado]) VALUES (N'318deeec-ad1a-43a8-95f2-0f2dcb985e6c', 1016, N'09e0a7d1-31e2-47ed-b71a-88573778e868', N'acffa74e-52a4-4567-a878-72921534d327', 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(N'2022-09-08T01:04:20.0316064' AS DateTime2), 2, N'Rua Copo de Leite', N'35', N'Minha TIA!', N'Feu Rosa', N'29172115', N'Serra', N'ES')
GO
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a11c-08eb80a9060b', N'Camiseta 4 Head', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'4head.webp', 5)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a12c-08eb80a9060b', N'Camiseta 4 Head Branca', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Branca 4head.webp', 5)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a13c-08eb80a9060b', N'Camiseta Tiltado', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'tiltado.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a14c-08eb80a9060b', N'Camiseta Tiltado Branca', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Branco Tiltado.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a15c-08eb80a9060b', N'Camiseta Heisenberg', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Heisenberg.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a16c-08eb80a9060b', N'Camiseta Kappa', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Kappa.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a17c-08eb80a9060b', N'Camiseta MacGyver', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'MacGyver.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a18c-08eb80a9060b', N'Camiseta Maestria', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Maestria.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a19c-08eb80a9060b', N'Camiseta Code Life Preta', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(90.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta2.jpg', 73)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a29c-08eb80a9060b', N'Camiseta My Yoda', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'My Yoda.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a39c-08eb80a9060b', N'Camiseta Pato', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Pato.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a41c-08eb80a9060b', N'Camiseta Xavier School', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Xaviers School.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a42c-08eb80a9060b', N'Camiseta Yoda', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Yoda.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a49c-08eb80a9060b', N'Camiseta Quack', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Quack.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a59c-08eb80a9060b', N'Camiseta Rick And Morty 2', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Rick And Morty Captured.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a69c-08eb80a9060b', N'Camiseta Rick And Morty', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Rick And Morty.webp', 5)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a79c-08eb80a9060b', N'Camiseta Say My Name', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Say My Name.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a89c-08eb80a9060b', N'Camiseta Support', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'support.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'7d67df76-2d4e-4a47-a99c-08eb80a9060b', N'Camiseta Try Hard', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'Tryhard.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476421e', N'Caneca Joker Wanted', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-joker Wanted.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476422e', N'Caneca Joker', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Joker.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476423e', N'Caneca Nightmare', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Nightmare.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476424e', N'Caneca Ozob', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Ozob.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476425e', N'Caneca Rick and Morty', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Rick and Morty.jpg', 5)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476426e', N'Caneca Wonder Woman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Wonder Woman.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476427e', N'Caneca No Coffee No Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca4.jpg', 100)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476437e', N'Caneca Batman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1--batman.jpg', 5)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476447e', N'Caneca Vegeta', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1-Vegeta.jpg', 8)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476457e', N'Caneca Batman Preta', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Batman.jpg', 8)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476467e', N'Caneca Big Bang Theory', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-bbt.webp', 0)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476477e', N'Caneca Cogumelo', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-cogumelo.webp', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476487e', N'Caneca Geeks', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-Geeks.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'78162be3-61c4-4959-89d7-5ebfb476497e', N'Caneca Ironman', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca-ironman.jpg', 10)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27b4bb', N'Camiseta Debugar Preta', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(75.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta4.jpg', 19806)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'6ecaaa6b-ad9f-422c-b3bb-6013ec27c4bb', N'Camiseta Code Life Cinza', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(80.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta3.jpg', 0)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'52dd696b-0882-4a73-9525-6af55dd416a4', N'Caneca Star Bugs Coffee', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca1.jpg', 0)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'191ddd3e-acd4-4c3b-ae74-8e473993c5da', N'Caneca Programmer Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca2.jpg', 0)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'fc184e11-014c-4978-aa10-9eb5e1af369b', N'Camiseta Software Developer', N'Camiseta 100% algodão, resistente a lavagens e altas temperaturas.', 1, CAST(100.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'camiseta1.jpg', 0)
INSERT [dbo].[Produtos] ([Id], [Nome], [Descricao], [Ativo], [Valor], [DataCadastro], [Imagem], [QuantidadeEstoque]) VALUES (N'20e08cd4-2402-4e76-a3c9-a026185b193d', N'Caneca Turn Coffee in Code', N'Caneca de porcelana com impressão térmica de alta resistência.', 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2019-07-19T00:00:00.0000000' AS DateTime2), N'caneca3.jpg', 0)
GO
INSERT [dbo].[RefreshTokens] ([Id], [Username], [Token], [ExpirationDate]) VALUES (N'fb543c34-e8fa-4357-85c8-6bcd7849a69f', N'heikenem@teste.com', N'adde1c2b-d732-42f5-b37d-1a8eb15b5608', CAST(N'2022-09-12T06:34:25.0285846' AS DateTime2))
GO
INSERT [dbo].[SecurityKeys] ([Id], [KeyId], [Type], [Parameters], [IsRevoked], [CreationDate], [ExpiredAt]) VALUES (N'884ec928-882a-428f-b311-7bd842e25a32', N'G0O7uwPXSkIx5QQ7QS7cWw', N'RSA', N'{"AdditionalData":{},"Alg":null,"Crv":null,"D":"h37fbUlqA9fZZRV9TLkfZr_Sa1AeeYZmSlPasLEI6LgoXpuRc0yRL9vhv-7wMao1Lo6caP0_ISgYNVXO_d-UKjcmCY9klr8fpg1iqAm1aEYgngTiIINUeLxkCXKmG5l2Ae6MG-vIvzEqW1FT06uyIfpoqU4QkBVRVdbiq6A6AXHT6csRjTgGYbdsYXXSjSyYKB8Alw-mh_4RVorVNA6nXmhdNwxluJSWZnnfvZE_-ZnkV1XVn1ppQhzpt_b8zS2A53QD2MlXwgNFaWg9_xGYjiEMAEluEJekM2IHI98Mv7rixPSj1sHM50eHSMnGiC5PVXFVsUSf9quUdY0cfpRtMdLf4eoSyfTxHcjss1VXL5pAm8kGvBhkKXyB9NWrL8FaAvejRR9pYTzfkpdqLNIKBA0xkBix0n-bCAICgsdlvMJxeYmM0D2ixGn20eVVXHuR62Y0cXxycIo6PktXaxi9CM0zBGPr5oPhqFJTjdsM7XjV4kHtcziz5oFkqt2j9xaJ","DP":"eWJvWnPIP0DFqGDXMB6h98hYcttZGv3Puj7212I4TApixCZowWf66Lr_NOsyPvM973KXBCZHscMKj0e-yCOfnhzPKs-zOA5ZrM00eeDnzXwjsU_jVafIKLCwq9-jeIitwtQykxeYeJyCWtrtgEPCBGLGFU8W7-b5OX6ddKXewLeupXCPot1St0YgPDqr2H0F1rtonQZDIn4B87CAQFQci_aZI9btKwKTyEBtRvEH5Ly_69AiQiDdcgAE-YLLqFY3","DQ":"MkkCwoQ-CvZPpxMIkTJulRp_0pqf8s8z6Un8G0GuEJoQ9Yb1lC3r0w-5lDLJZVNLtW2yGnoxpyg12QbsuYZaOr8gbfprRN8ASBCQ6sx1Ojk7necgDmV0c384OrsE5hTMiCoVzuToHjwL7P215GA7uLNP_bboizdujRUZwS85AUPQlJ6gt5tL90V4zLqhPT_V8V4nFxTD67tezO4ypfozz4OX5Kq59Kvmaf1gPWOvNZ7yVbuK0AaewaALOyOULkpd","E":"AQAB","K":null,"KeyId":"G0O7uwPXSkIx5QQ7QS7cWw","KeyOps":[],"Kid":"G0O7uwPXSkIx5QQ7QS7cWw","Kty":"RSA","N":"rAhTnj4HtBG4tOraw9poU98THBLQuWQNX9uufPpxgIu-m5HR3vW3ZRcMw84MZtoxYXQOrZxkzxr07XOWhQHJHfZCwi6M-s-Y3ivdjGK9uJSrsu_IevGNiOqg2x_eG6HbS-7Pf5Fn_vAv1Pg_vpyH9VmDLXjumk9Cj_c77un6Wr0GCe8OGKqgAJ-5-eGHYTZLHEFPc6CRLEqY_nahVlgoS9v9-T5D-FB1Qg1Xl5PUsBd6YIXaHX_UVs1c0Q6JAJi_9Idtjvgo4kvfyRUuRzHChqd2y3HjC8BJNp48UIcZ7utNFQ7Mxjpta0lFK_vXdwggBESOXUQpPVb5gXQlPCcRngyLB7g36DkeByaUsw9WHUFshXctjT36rFqAoR-fvg77P8W2rrFZwl_5htd60N4PUtnM840t-MdscEB4NYQfsW6FadUPqbnRpr0DUymxofv1L82EGS9NkjV3zGlbGVJDojYc1vGc_c8cT7zwoT6P7WpmCfNWeCuuERjCK7t1Hbxh","Oth":null,"P":"wrUyoGkUw9Lka0kP8Jj_brL2xy_mxrSVZqszJki-UVVzgAKv-pdLgCPwosY7ExBArfDQkQw_oqHfHownH2Z2XvqgMB0pOIu2TzRlX8sT0i82rYVu7q6jU38cAVSNYbC6PYEgkjs1arfeT7IoDuU0ABru44RXMB07BSSnhEJ2oIGfOeWaVAehCjmHcvaogYf5qFMnrwoVJTgwFN4ohQMBvG_wOb7hSoeSJDRxAVYnMnZQaxHQYcPvDN9uMWKfwkGn","Q":"4i_PSWQyKrzAYnDvl-VKCIXm_8wJX2Rf31o7DuVZ9xOZzb9TTa_zFeJ-OVsl2TeBXZq3XgGwZRjusodAj7WRU3ulST-FarEhHwtMI4QqJUrYzY0N1keGtgXmGbW0v3ny8dBiRUZelWvQggyhixbO2sTez2GOHHaqgv-X0BXTYT-sF3XHrG-HcTalITKsHfVxj40rEaxY_Cg-1jw5SEyjXTfCBDFQNzQY-6yLfKSKDjwW_nOfWwEjZBhDGrieBoK3","QI":"kgwarPleaKv3k0_ra1S4oyu8YnSJjaJFFuxaKRiz_DEWgYBlbQJdDTgPBYYFC-6rgWTr5Mt4EE57uruyoYxYaq-D33u94cSKHCW340ZFKj7D8TzN_Si4JIW_leST-U80J78qICY2hwr09fANcBcSF_zesVjf22zSii22Ng_RrKt6ii4tGwiPPRL1GIWXMGNeIvBeajjrm81bJ97ird5oA7tSIHIaLcjh5f_RpYs0gqnOMN1mfB8ezvA_2aoBpnLL","Use":null,"X":null,"X5c":[],"X5t":null,"X5tS256":null,"X5u":null,"Y":null,"KeySize":3072,"HasPrivateKey":true,"CryptoProviderFactory":{"CryptoProviderCache":{},"CustomCryptoProvider":null,"CacheSignatureProviders":true,"SignatureProviderObjectPoolCacheSize":32}}', 0, CAST(N'2022-09-10T04:18:17.8324446' AS DateTime2), NULL)
INSERT [dbo].[SecurityKeys] ([Id], [KeyId], [Type], [Parameters], [IsRevoked], [CreationDate], [ExpiredAt]) VALUES (N'1dd7c0db-df53-42cf-ae2d-d1372258c3e3', N'9u9tF9O0106auQU6yvZ-xQ', N'RSA', N'{"AdditionalData":{},"E":"AQAB","KeyId":"9u9tF9O0106auQU6yvZ-xQ","KeyOps":[],"Kid":"9u9tF9O0106auQU6yvZ-xQ","Kty":"RSA","N":"9a8rs5ppeCbzwt35Qu9BpzUl71lwI0wBJg2tACuObPf8WfNDbOC0Yd72KbCHOujw0smDkNeKPOHkgP_Mxr5BO3tGoylwss8UHH0y2sfv09xEc8OcOWMjEPKHYjYEwSFCaE13vlc9UptnahJRcUbFZoyPue_kAmDrPTrTv1QdBEuYrPWumvYeDejt_zSDCVej9u8X1kTNPd7QDR1EDq-ybDcy0QTSbGOVGhVzur4y68qsPrqA1IhYhmQFSWp6pnw6VhSzaeDjuDag1FmULMu_9RFQtOSy6yWxoeDFERHz_gtw551Lf0eopVH0IApiePkaMmrBayRUQprf5LnC4Whqk-mWIEeqXWyT335HBIbSTcz7mrotUjoo2SLzQHpZAtuIrog1dviSD6pW1yY-Kv7kU686sXR9Ge69312Iotp8fLtDyFkHA3tMZfjLYh4BgujaU8ezbdMQUGLsSBABOrkyddJnLeSD58D_34rUOzbaxjdmMoLCpmY9iugArceuT1nx","Use":"sig","X5c":[],"KeySize":3072,"CryptoProviderFactory":{"CryptoProviderCache":{},"CacheSignatureProviders":true,"SignatureProviderObjectPoolCacheSize":32}}', 1, CAST(N'2022-02-10T03:52:07.9832057' AS DateTime2), CAST(N'2022-09-10T04:18:17.4934801' AS DateTime2))
GO
INSERT [dbo].[Transacoes] ([Id], [CodigoAutorizacao], [BandeiraCartao], [DataTransacao], [ValorTotal], [CustoTransacao], [Status], [TID], [NSU], [PagamentoId]) VALUES (N'46288174-98ef-42d9-a445-35d242e7dc67', N'RANTOIZJNQ', N'MasterCard', CAST(N'2022-09-08T01:04:41.3241234' AS DateTime2), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'1Q8V3DCJBS', N'FBFGH35QY5', N'bad8a11e-1219-4dc6-81d4-980ab5f2959c')
INSERT [dbo].[Transacoes] ([Id], [CodigoAutorizacao], [BandeiraCartao], [DataTransacao], [ValorTotal], [CustoTransacao], [Status], [TID], [NSU], [PagamentoId]) VALUES (N'90ef019a-c67a-417d-ae53-e31b12e06b2c', N'G6I4KD6LSF', N'MasterCard', CAST(N'2022-09-08T01:04:17.2895575' AS DateTime2), CAST(50.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), 1, N'1Q8V3DCJBS', N'FBFGH35QY5', N'bad8a11e-1219-4dc6-81d4-980ab5f2959c')
GO
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'acffa74e-52a4-4567-a878-72921534d325', N'150-OFF-GERAL', NULL, CAST(150.00 AS Decimal(18, 2)), 48, 1, CAST(N'2020-06-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'acffa74e-52a4-4567-a878-72921534d327', N'50-OFF-GERAL', CAST(50.00 AS Decimal(18, 2)), NULL, 39, 0, CAST(N'2020-06-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado]) VALUES (N'acffa74e-52a4-4567-a878-72921534d328', N'10-OFF-GERAL', CAST(10.00 AS Decimal(18, 2)), NULL, 42, 0, CAST(N'2020-06-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2025-01-01T00:00:00.0000000' AS DateTime2), 1, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IDX_Cliente]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Cliente] ON [dbo].[CarrinhoClientes]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CarrinhoItens_CarrinhoClienteId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_CarrinhoItens_CarrinhoClienteId] ON [dbo].[CarrinhoItens]
(
	[CarrinhoClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enderecos_ClienteId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Enderecos_ClienteId] ON [dbo].[Enderecos]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PedidoItems_PedidoId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_PedidoItems_PedidoId] ON [dbo].[PedidoItems]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedidos_VoucherId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pedidos_VoucherId] ON [dbo].[Pedidos]
(
	[VoucherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transacoes_PagamentoId]    Script Date: 9/16/2022 10:09:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transacoes_PagamentoId] ON [dbo].[Transacoes]
(
	[PagamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarrinhoClientes] ADD  DEFAULT ((0.0)) FOR [Desconto]
GO
ALTER TABLE [dbo].[CarrinhoClientes] ADD  DEFAULT ((0)) FOR [TipoDesconto]
GO
ALTER TABLE [dbo].[CarrinhoClientes] ADD  DEFAULT ('') FOR [VoucherCodigo]
GO
ALTER TABLE [dbo].[CarrinhoClientes] ADD  DEFAULT (CONVERT([bit],(0))) FOR [VoucherUtilizado]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (NEXT VALUE FOR [MinhaSequencia]) FOR [Codigo]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CarrinhoItens]  WITH CHECK ADD  CONSTRAINT [FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId] FOREIGN KEY([CarrinhoClienteId])
REFERENCES [dbo].[CarrinhoClientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarrinhoItens] CHECK CONSTRAINT [FK_CarrinhoItens_CarrinhoClientes_CarrinhoClienteId]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[PedidoItems]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItems_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
GO
ALTER TABLE [dbo].[PedidoItems] CHECK CONSTRAINT [FK_PedidoItems_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Vouchers_VoucherId] FOREIGN KEY([VoucherId])
REFERENCES [dbo].[Vouchers] ([Id])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Vouchers_VoucherId]
GO
ALTER TABLE [dbo].[Transacoes]  WITH CHECK ADD  CONSTRAINT [FK_Transacoes_Pagamentos_PagamentoId] FOREIGN KEY([PagamentoId])
REFERENCES [dbo].[Pagamentos] ([Id])
GO
ALTER TABLE [dbo].[Transacoes] CHECK CONSTRAINT [FK_Transacoes_Pagamentos_PagamentoId]
GO
USE [master]
GO
ALTER DATABASE [NerdStoreEnterprise] SET  READ_WRITE 
GO
