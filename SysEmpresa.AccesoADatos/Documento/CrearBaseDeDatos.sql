USE [master]
GO
CREATE DATABASE [Empresadb]
GO
USE [Empresadb]
GO
---crear la tabla de Empleado
CREATE TABLE dbo.Empleado(
  Id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
  Nombre varchar (60) NOT NULL,
  Apellido varchar (60) NOT NULL,
  Telefono varchar (10) NOT NULL,
  Edad varchar (3) NOT NULL,
  Direccion varchar (200) DEFAULT NULL,
  Estatus tinyint NOT NULL,
  Cargo tinyint NOT NULL,
  FechaInicio datetime NOT NULL,
  DocumentoID varchar (10) NOT NULL
);
GO
---crear la tabla de Empresa
CREATE TABLE dbo.Empresa(
  Id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
  IdEmpleado int NOT NULL,
  Nombre varchar (60) NOT NULL,
  CantidadEmplado int NOT NULL,
  Descripcion varchar (200) NOT NULL,
  Estatus tinyint NOT NULL,
  FechaRegistro datetime NOT NULL,
  TipoEmplesa tinyint NOT NULL,
  CorreoEmpresa varchar (200) NOT NULL,
  CONSTRAINT FK1_Empleado_Empresa FOREIGN KEY (IdEmpleado) REFERENCES Empleado (Id)
);