USE [ClothingSystemdb]
GO
INSERT INTO [dbo].[Rol]
           ([Nombre])
     VALUES
           ('ADMINISTRADOR DEL SISTEMA')
GO
-- Encriptar la contraseña Admin2021 en MD5 https://www.infranetworking.com/md5
INSERT INTO [dbo].[Usuario]
           ([IdRol]
           ,[Nombre]
           ,[Apellido]
           ,[Login]
           ,[Password]
           ,[Estatus]
           ,[FechaRegistro])
     VALUES
           ((Select Top 1 Id from Rol where Nombre='ADMINISTRADOR DEL SISTEMA'),
           'Administrador',
           'Del Sistema',
           'AdonayB',
           '827ccb0eea8a706c4c34a16891f84e7b',
           1,
           SYSDATETIME())