USE [testeP3Image]
GO
SET IDENTITY_INSERT [dbo].[Campos] ON 

GO
INSERT [dbo].[Campos] ([CampoId], [Descricao], [SubCategoriaId], [Tipo], [Lista], [Ordem]) VALUES (5, N'Nome', 13, N'1', NULL, 1)
GO
INSERT [dbo].[Campos] ([CampoId], [Descricao], [SubCategoriaId], [Tipo], [Lista], [Ordem]) VALUES (6, N'Fabricante', 13, N'4', N'Fiat;Ford;GM;Volkswagen', 2)
GO
INSERT [dbo].[Campos] ([CampoId], [Descricao], [SubCategoriaId], [Tipo], [Lista], [Ordem]) VALUES (7, N'Combustível', 13, N'3', N'Álcool;Gasolina;Flex', 3)
GO
INSERT [dbo].[Campos] ([CampoId], [Descricao], [SubCategoriaId], [Tipo], [Lista], [Ordem]) VALUES (8, N'Observações', 13, N'2', NULL, 4)
GO
SET IDENTITY_INSERT [dbo].[Campos] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

GO
INSERT [dbo].[Categorias] ([CategoriaId], [Descricao]) VALUES (1, N'Veículos')
GO
INSERT [dbo].[Categorias] ([CategoriaId], [Descricao]) VALUES (4, N'Alimentos')
GO
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategorias] ON 

GO
INSERT [dbo].[SubCategorias] ([SubCategoriaId], [Descricao], [CategoriaId]) VALUES (13, N'Carros', 1)
GO
INSERT [dbo].[SubCategorias] ([SubCategoriaId], [Descricao], [CategoriaId]) VALUES (14, N'Motos', 1)
GO
SET IDENTITY_INSERT [dbo].[SubCategorias] OFF
GO
