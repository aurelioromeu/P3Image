USE [master]
GO

CREATE DATABASE [testeP3Image] ON  PRIMARY 
( 
    NAME = N'testeP3Image', 
    FILENAME = N'D:\DB\testeP3Image.mdf' ,			--local data path
    SIZE = 8000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB 
)
GO

USE [testeP3Image]
CREATE TABLE Categorias
(
	CategoriaId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Descricao VARCHAR(150) NOT NULL
)

CREATE TABLE SubCategorias
(
	SubCategoriaId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Descricao VARCHAR(150) NOT NULL,
	CategoriaId INT NOT NULL
)

CREATE TABLE Campos
(
	CampoId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Descricao VARCHAR(150) NOT NULL,
	SubCategoriaId INT NOT NULL,
	Tipo VARCHAR(150) NOT NULL,
	Lista VARCHAR(150) NULL,
	Ordem INT NOT NULL
)

