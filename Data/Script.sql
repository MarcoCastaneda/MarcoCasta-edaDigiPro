GO
CREATE DATABASE MCastanedaDigiPro
GO

USE [MCastanedaDigiPro]
GO
/****** Object:  StoredProcedure [dbo].[AlumnoAdd]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoAdd]
 (@Nombre VARCHAR(50), @ApellidoPaterno VARCHAR(50), @ApellidoMaterno VARCHAR(50), @Email VARCHAR(50), @Password VARCHAR(50))
	AS
		INSERT INTO Alumno
			(Nombre,
			ApellidoPaterno, 
			ApellidoMaterno,
			Email,
			Password)
		VALUES
			(@Nombre,
			@ApellidoPaterno,
			@ApellidoMaterno,
			@Email,
			@Password)

GO
/****** Object:  StoredProcedure [dbo].[AlumnoDelete]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoDelete] @IdAlumno INT
	AS
		DELETE FROM Alumno WHERE IdAlumno = @IdAlumno

GO
/****** Object:  StoredProcedure [dbo].[AlumnoGetAll]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoGetAll]
	AS
		SELECT
			IdAlumno,
			Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			Email,
			Password
		FROM Alumno

GO
/****** Object:  StoredProcedure [dbo].[AlumnoGetById]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoGetById] @IdAlumno INT
	AS
		SELECT 
			IdAlumno,
			Nombre,
			ApellidoPaterno,
			ApellidoMaterno,
			Email,
			Password
		FROM Alumno
		 WHERE IdAlumno=@IdAlumno
GO
/****** Object:  StoredProcedure [dbo].[AlumnoMateriaAdd]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoMateriaAdd] @IdAlumno iNT, @IdMateria INT
AS INSERT INTO AlumnoMateria (IdAlumno, IdMateria)
VALUES (@IdAlumno, @IdMateria)

GO
/****** Object:  StoredProcedure [dbo].[AlumnoMateriaDelete]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoMateriaDelete] @IdAlumnoMateria INT
AS DELETE FROM AlumnoMateria
	WHERE IdAlumnoMateria = @IdAlumnoMateria 

GO
/****** Object:  StoredProcedure [dbo].[AlumnoMateriaGetAll]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoMateriaGetAll]
	AS
	SELECT 
	IdAlumnoMateria,
	AlumnoMateria.IdAlumno,
	Alumno.Nombre,
	AlumnoMateria.IdMateria,
	Materia.Nombre
	
FROM AlumnoMateria

INNER JOIN Alumno
ON AlumnoMateria.IdAlumno = Alumno.IdAlumno

INNER JOIN Materia
ON AlumnoMateria.IdMateria = Materia.IdMateria

GO
/****** Object:  StoredProcedure [dbo].[AlumnoUpdate]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AlumnoUpdate] 
	@IdAlumno INT, 
	@Nombre VARCHAR(50), 
	@ApellidoPaterno VARCHAR(50), 
	@ApellidoMaterno VARCHAR(50),
	@Email VARCHAR(50),
	@Password VARCHAR(50)
	AS
		UPDATE Alumno
			SET
				Nombre=@Nombre,
				ApellidoPaterno=@ApellidoPaterno,
				ApellidoMaterno=@ApellidoMaterno,
				Email=@Email,
				Password=@Password

			WHERE @IdAlumno = IdAlumno

GO
/****** Object:  StoredProcedure [dbo].[GetByEmail]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetByEmail] 
@Email VARCHAR (50)
as
SELECT
IdAlumno,
Email,
Password
FROM Alumno

WHERE Email = @Email

GO
/****** Object:  StoredProcedure [dbo].[MateriaAdd]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaAdd]
	(@Nombre VARCHAR(50),
	@Costo DECIMAL(18,2))
AS
	INSERT INTO Materia
		(Nombre,
		Costo)
	VALUES
		(@Nombre,
		@Costo)

GO
/****** Object:  StoredProcedure [dbo].[MateriaDelete]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaDelete]
	@IdMateria INT
AS
DELETE FROM Materia WHERE IdMateria = @IdMateria

GO
/****** Object:  StoredProcedure [dbo].[MateriaGetAll]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaGetAll]
	AS
		SELECT 
			IdMateria,
			Nombre,
			Costo
		FROM Materia

GO
/****** Object:  StoredProcedure [dbo].[MateriaGetById]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaGetById]
	@IdMateria INT
AS
	SELECT 
		IdMateria,
			Nombre,
			Costo
		FROM Materia
	WHERE IdMateria = @IdMateria

GO
/****** Object:  StoredProcedure [dbo].[MateriasAsignadas]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriasAsignadas]
 @IdAlumno iNT
	AS
		SELECT
			AlumnoMateria.IdAlumnoMateria,
			AlumnoMateria.IdAlumno,
			Alumno.Nombre as AlumnoNombre,
			Alumno.ApellidoPaterno,
			Alumno.ApellidoMaterno,
			AlumnoMateria.IdMateria,
			Materia.Nombre as MateriaNombre
		FROM AlumnoMateria
			INNER JOIN Alumno
				ON AlumnoMateria.IdAlumno = Alumno.IdAlumno
			INNER JOIN Materia
				ON AlumnoMateria.IdMateria = Materia.IdMateria
			WHERE AlumnoMateria.IdAlumno = @IdAlumno

GO
/****** Object:  StoredProcedure [dbo].[MateriasNoAsignadas]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriasNoAsignadas] @IdAlumno INT
	AS
	SELECT
		Materia.IdMateria, 
		Materia.Nombre as MateriaNombre,
		Materia.Costo
	FROM Materia WHERE IdMateria NOT IN(
	SELECT 
		Materia.IdMateria FROM AlumnoMateria
			LEFT JOIN Materia
				ON Materia.IdMateria = AlumnoMateria.IdMateria
			LEFT JOIN Alumno
				ON Alumno.IdAlumno = AlumnoMateria.IdAlumno
		WHERE Alumno.IdAlumno = @IdAlumno)

GO
/****** Object:  StoredProcedure [dbo].[MateriaUpdate]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaUpdate]
	(@IdMateria INT,
	@Nombre VARCHAR(50),
	@Costo DECIMAL(18,2))
AS
	UPDATE Materia SET
		Nombre = @Nombre,
		Costo = @Costo
	WHERE IdMateria = @IdMateria

GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlumnoMateria]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnoMateria](
	[IdAlumnoMateria] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NULL,
	[IdMateria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlumnoMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materia]    Script Date: 27/07/2022 10:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Costo] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Email], [Password]) VALUES (1, N'Marco', N'Castañeda', N'Bautista', N'marcoceb1998@gmail.com', N'123')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Email], [Password]) VALUES (2, N'Cristian', N'Flores', N'Martinez', N'Flor@gmail.com', N'123')
INSERT [dbo].[Alumno] ([IdAlumno], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [Email], [Password]) VALUES (3, N'Leonardo', N'Es', N'Bravo', N'Leo@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[Alumno] OFF
SET IDENTITY_INSERT [dbo].[AlumnoMateria] ON 

INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (5, 2, 1)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (6, 2, 3)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (7, 2, 2)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (8, 3, 1)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (9, 3, 2)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (10, 3, 3)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (11, 3, 4)
INSERT [dbo].[AlumnoMateria] ([IdAlumnoMateria], [IdAlumno], [IdMateria]) VALUES (21, 1, 1)
SET IDENTITY_INSERT [dbo].[AlumnoMateria] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (1, N'Español', CAST(15001.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (2, N'Materia', CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (3, N'Matematicas', CAST(5000.00 AS Decimal(18, 2)))
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Costo]) VALUES (4, N'Filosofia', CAST(20001.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Materia] OFF
ALTER TABLE [dbo].[AlumnoMateria]  WITH CHECK ADD FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([IdAlumno])
GO
ALTER TABLE [dbo].[AlumnoMateria]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMateria])
GO
