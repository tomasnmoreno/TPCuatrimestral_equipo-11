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
	('Oftalmolog�a')
	('Kinesiolog�a')
