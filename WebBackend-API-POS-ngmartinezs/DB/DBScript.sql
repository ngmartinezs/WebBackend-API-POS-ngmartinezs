
USE [master]
GO

/****** Object:  Database [DBPOS]    Script Date: 13/09/2021 10:11:05 p. m. ******/
DROP DATABASE [DBPOS]
GO


USE [DBPOS]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 13/09/2021 10:11:32 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoId] [varchar](3) NOT NULL,
	[NumeroId] [varchar](30) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [IX_Clientes] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [DBPOS]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 13/09/2021 10:12:23 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[ValorUnitario] [numeric](20, 2) NOT NULL,
 CONSTRAINT [IX_Productos] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [DBPOS]
GO

/****** Object:  Table [dbo].[FacturaVenta]    Script Date: 13/09/2021 10:12:58 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FacturaVenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[ValorTotal] [numeric](20, 2) NULL,
 CONSTRAINT [IX_FacturaVenta] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacturaVenta]  WITH CHECK ADD  CONSTRAINT [FK_FacturaVenta_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO

ALTER TABLE [dbo].[FacturaVenta] CHECK CONSTRAINT [FK_FacturaVenta_Clientes]
GO

USE [DBPOS]
GO

/****** Object:  Table [dbo].[DetalleFacturaVenta]    Script Date: 13/09/2021 10:13:37 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetalleFacturaVenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaVentaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ValorDetalle] [numeric](20, 2) NOT NULL,
 CONSTRAINT [IX_DetalleFacturaVentas] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DetalleFacturaVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFacturaVentas_Productos] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO

ALTER TABLE [dbo].[DetalleFacturaVenta] CHECK CONSTRAINT [FK_DetalleFacturaVentas_Productos]
GO



