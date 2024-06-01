CREATE DATABASE TP_CUATRIMESTRAL
GO
USE TP_CUATRIMESTRAL
GO

CREATE or alter TABLE ESPECIALIDADES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	DESCRIPCION VARCHAR(50) NOT NULL UNIQUE
)

INSERT INTO ESPECIALIDADES (DESCRIPCION)
VALUES
	('Odontolog�a'),
	('Traumatolog�a'),
	('Cardiolog�a'),
	('Dermatolog�a'),
	('Gastroenterolog�a'),
	('Obstetricia'),
	('Pediatr�a'),
	('Neurolog�a'),
	('Ginecolog�a'),
	('Endocrinolog�a'),
	('Hematolog�a'),
	('Oftalmolog�a'),
	('Kinesiolog�a')


--EN ETAPA DE CREACIOM
--CREATE TABLE EspecialidadesxMedicos(
--	IDESPECIALIDAD INT NOT NULL PRIMARY KEY IDENTITY(1,1),
--	--IDMEDICO
--)

--CREATE TABLE MEDICOS(
--	ID int not null primary key identity(1,1),
--	Nombre varchar(100) not null,
--	Apellido varchar(100) not null,
--	Nacimiento date not null,
--	Celular tinyint not null,
--	Domicilio varchar(100) not null,
--	CodPostal tinyint not null,
--	TurnoTrabajo,
--)

create table Usuarios(
	ID int not null primary key identity(1,1),
	NombreUsuario varchar(100) not null unique,
	Pass varchar(100) not null,
	Email varchar(150) not null,
	Tipo tinyint not null,
	Estado bit not null
)

insert into Usuarios(NombreUsuario, Pass, Email, Tipo, Estado)
	values('tmoreno', '1234', 'tomasmoreno@gmail.com.ar', 1, 1)
