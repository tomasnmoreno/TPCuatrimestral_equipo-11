CREATE DATABASE TP_CUATRIMESTRAL
GO
USE TP_CUATRIMESTRAL
GO

CREATE TABLE ESPECIALIDADES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	DESCRIPCION VARCHAR(50) NOT NULL UNIQUE
)

INSERT INTO ESPECIALIDADES (DESCRIPCION)
VALUES
	('Odontología'),
	('Traumatología'),
	('Cardiología'),
	('Dermatología'),
	('Gastroenterología'),
	('Obstetricia'),
	('Pediatría'),
	('Neurología'),
	('Ginecología'),
	('Endocrinología'),
	('Hematología'),
	('Oftalmología')
	('Kinesiología')
