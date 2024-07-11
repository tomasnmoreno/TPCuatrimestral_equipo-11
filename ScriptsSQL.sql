use master
go
CREATE DATABASE TP_CUATRIMESTRAL
GO
USE TP_CUATRIMESTRAL
GO

create Table DiasSemana(
	Id int not null primary key,
	Nombre varchar(50)
	)
go

Insert Into DiasSemana(Id, Nombre)
values 
	(1,'Lunes'),
	(2,'Martes'),
	(3,'Miercoles'),
	(4,'Jueves'),
	(5,'Viernes')

go


Create Table Especialidades(
	Id Int Not Null Primary Key Identity(1, 1),
	Nombre Varchar(50) Not Null Unique,
	Descripcion Varchar(1000) Not Null,
	Imagen Varchar(200) Not Null,
	Estado Bit Not Null Default 1
)

Go
Insert Into Especialidades (Nombre, Descripcion, Imagen)
Values
	('Odontología','Rama de la medicina que se ocupa del diagnóstico, prevención y tratamiento de las enfermedades y condiciones del sistema oral y maxilofacial. Esto incluye los dientes, las encías, el tejido periodontal, el maxilar, la mandíbula, la articulación temporomandibular y otras áreas relacionadas','https://staticnew-prod.topdoctors.mx/article/18650/image/large/odontologia-digital-la-optimizacion-de-los-procesos-tradicionales-1698035005.jpeg'),
	('Traumatología','Especialidad médica que se centra en el diagnóstico, tratamiento y prevención de lesiones y enfermedades del sistema musculoesquelético. Esto incluye huesos, articulaciones, ligamentos, tendones y músculos. Los traumatólogos tratan afecciones que van desde fracturas y dislocaciones hasta desgarros de ligamentos y lesiones de la médula espinal.','https://centromedicoabc.com/storage/2023/01/traumatologia-ortopedia.jpg'),
	('Cardiología','Disciplina médica que se ocupa del diagnóstico, tratamiento y prevención de enfermedades del corazón y del sistema circulatorio. Los cardiólogos tratan afecciones como enfermedad coronaria, insuficiencia cardíaca, arritmias y enfermedades de las válvulas del corazón.','https://cbahoy.com.ar/wp-content/uploads/2023/04/10-cardiologia.webp'),
	('Dermatología','Rama de la medicina se ocupa del diagnóstico, tratamiento y prevención de enfermedades de la piel, cabello, uñas y membranas mucosas. Los dermatólogos tratan una amplia gama de condiciones, desde acné y psoriasis hasta cáncer de piel y enfermedades autoinmunes de la piel.','https://www.esneca.lat/wp-content/uploads/especialidades-en-dermatologia.jpg'),
	('Gastroenterología','Especialidad médica que se ocupa del estudio, diagnóstico y tratamiento de enfermedades del sistema digestivo y del hígado. Los gastroenterólogos tratan afecciones que van desde enfermedad por reflujo gastroesofágico (ERGE) y úlceras pépticas hasta enfermedad inflamatoria intestinal y cáncer de colon.','https://www.sanfernando.gob.ar/images/principales/46968422_Gatroenterologia.jpg'),
	('Obstetricia','Rama de la medicina se enfoca en el cuidado de la mujer durante el embarazo, el parto y el puerperio (el período después del parto). Los obstetras se especializan en el manejo de la salud materna y fetal durante todas las etapas del embarazo.','https://www.mgc.es/wp-content/uploads/2019/08/obstetra-eco.jpg'),
	('Pediatría','Especialidad médica que se ocupa de la salud y el bienestar de los niños, desde el nacimiento hasta la adolescencia. Los pediatras diagnostican y tratan una amplia gama de enfermedades infantiles, desde infecciones comunes y lesiones menores hasta enfermedades crónicas y graves.','https://ifses.es/wp-content/uploads/2023/04/enfermeria-pediatrica-1200x600.jpg'),
	('Neurología','Disciplina médica se ocupa del diagnóstico y tratamiento de enfermedades del sistema nervioso, que incluye el cerebro, la médula espinal y los nervios periféricos. Los neurólogos tratan afecciones como accidente cerebrovascular, enfermedad de Parkinson, esclerosis múltiple y epilepsia.','https://isabelrestreponeurologa.com/wp-content/uploads/2019/11/ART1-Q-ES-NEUROLOGIA.jpg'),
	('Ginecología','Especialidad médica que se ocupa del cuidado del sistema reproductor femenino. Los ginecólogos diagnostican y tratan enfermedades de los órganos reproductivos femeninos, incluyendo el útero, los ovarios y la vagina.','https://bluenethospitals.com/storage/assets/es/blog-posts/ObGyn_Ginecologia_BlueNetHOSPITALS_LosCabos.webp'),
	('Endocrinología','Rama de la medicina se ocupa del diagnóstico y tratamiento de enfermedades que afectan a las glándulas endocrinas, que son las que producen hormonas. Los endocrinólogos tratan afecciones como diabetes, enfermedades de la tiroides, trastornos metabólicos y problemas de crecimiento.','https://staticnew-prod.topdoctors.mx/files/Image/large/ebf822a89fa6b93e6d4dc92f9a6bfa60.jpg'),
	('Hematología','Especialidad médica que se ocupa del estudio, diagnóstico y tratamiento de enfermedades de la sangre y los órganos que la producen, como la médula ósea y el bazo. Los hematólogos tratan afecciones como anemia, coagulación sanguínea y trastornos de la médula ósea.','https://policlinicametropolitana.org/wp-content/uploads/2022/02/coronavirus-vaccine-lab-with-samples.jpg'),
	('Oftalmología','Rama de la medicina se ocupa del diagnóstico y tratamiento de enfermedades del ojo. Los oftalmólogos tratan afecciones como cataratas, glaucoma, degeneración macular y problemas de visión.','https://aio-oftalmologia.com/wp-content/uploads/De-que-se-ocupa-un-oftalmologo.jpg')

Go
Create Procedure SP_Nueva_Especialidad
	@nombre varchar(50),
	@descripcion varchar(1000),
	@imagen varchar(200)
	as
	Insert Into Especialidades (Nombre, Descripcion, Imagen)
	Values(@nombre, @descripcion, @imagen)

Go
Create or Alter Procedure SP_Modificar_Especialidad
	@nombre varchar(50),
	@descripcion varchar(1000),
	@imagen varchar(200),
	@id int
	as
	Update Especialidades set Nombre = @nombre, Descripcion = @descripcion, Imagen = @imagen
	Where Id = @id;



go
create table Usuarios(
	ID int not null primary key identity(1, 1),
	NombreUsuario varchar(100) not null unique,
	Pass varchar(100) not null,
	Email varchar(150) not null,
	Tipo tinyint not null,
	FechaAlta datetime not null default getdate(),
	Estado bit not null default 1
)
 
 ------ MEDICOS ------
go 
CREATE TABLE MEDICOS( --tipo 3--
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Matricula int not null,
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	Celular bigint not null,
	Domicilio varchar(100) not null,
	CodPostal int not null
)

go
create or alter procedure SP_Nuevo_Medico
	--Para Paciente
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Nacimiento datetime,
	@Dni bigint,
	@Email varchar(150),
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int,
	@Matricula int,
	--Para Usuario
	@NombreUsuario varchar(100),
	@Pass varchar(100)
 as begin
	begin try
	begin transaction

		if @Dni not in (select Dni from MEDICOS where Dni = @Dni) begin
			INSERT INTO Usuarios(NombreUsuario, Pass, Email, Tipo, Estado)
			values	(@NombreUsuario, @Pass, @Email, 4, 1)

			declare @IDusuario int 
			select @IDusuario = ID from Usuarios where NombreUsuario = @NombreUsuario
			INSERT INTO MEDICOS(IDUsuario,Matricula, Nombre, Apellido, Nacimiento, Dni, Celular, Domicilio, CodPostal)
			values (@IDusuario, @Matricula, @Nombre, @apellido, @Nacimiento, @Dni, @Celular, @Domicilio, @CodPostal)
		end 
		else begin
			raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		end
	commit transaction
	end try
	begin catch
		raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		rollback transaction
	end catch
end

go
create or alter procedure SP_Modificar_Medico
	--Para Medico
	@ID int,
	@Dni int,
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Matricula int,
	@Email varchar(150),
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int

as begin
	begin try
	begin transaction
		update Usuarios set Email = @Email where ID = @ID
		update MEDICOS set @Matricula = Matricula, Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido, Celular = @Celular, Domicilio = @Domicilio, CodPostal = @CodPostal where IDUsuario = @ID
	commit transaction
	end try
	begin catch
		raiserror('Hubo un problema en la modificacion, verifique si los datos estan correctos',16,2)
		rollback transaction
	end catch
end	

go
CREATE TABLE EspecialidadesXMedicos(
	IDEspecialidad int foreign key references ESPECIALIDADES(ID), 
	IDMedico int not null foreign key references Medicos(IDUsuario)
	Primary Key(IDEspecialidad, IDMedico)
)

go 
 CREATE OR Alter Procedure SP_Nueva_EspecialidadesXMedicos
	
	@IDEspecialidad int,
	@IDMedico int
	
	AS
	begin
	
	INSERT INTO EspecialidadesXMedicos(IDEspecialidad, IDMedico)
	
	VALUES (@IDEspecialidad,@IDMedico)

	end;

Go
CREATE TABLE HorariosTrabajo (
	IDHorario int not null primary key identity(1,1),
	HoraInicio time not null,
	HoraFin time not null,
	IdDia int not null,
)

GO

CREATE OR ALTER PROCEDURE SP_Nuevo_Horarios
    @HoraInicio TIME,
    @HoraFin TIME,
	@IdDia int
AS
BEGIN
    INSERT INTO HorariosTrabajo (HoraInicio, HoraFin, IdDia)
    VALUES (@HoraInicio, @HoraFin, @IdDia)
END

Go
CREATE TABLE HorarioxMedico(
	IDHorario int foreign key references HorariosTrabajo(IDHorario),
	IDMedico int foreign key references Medicos(IDusuario),
	primary key (IDHorario, IDMedico)
)

go
CREATE OR Alter Procedure SP_Nueva_HorarioxMedico
	
	@IDHorario int,
	@IDMedico int
	
	AS
	begin
	
	INSERT INTO HorarioxMedico(IDHorario, IDMedico)
	
	VALUES (@IDHorario,@IDMedico)

	end;


------ PACIENTES ------
go
CREATE TABLE PACIENTES( --tipo 4--
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	EMail varchar(150), -- YA ESTA EN USUARIOS -> SACAR Y REVISAR SI GENERA CONFLICTOS
	Celular bigint not null,
	Domicilio varchar(100) not null,
	CodPostal int not null
)

Go
create or alter procedure SP_Nuevo_Paciente
	--Para Paciente
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Nacimiento datetime,
	@Dni bigint,
	@Email varchar(150),
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int,
	--Para Usuario
	@NombreUsuario varchar(100),
	@Pass varchar(100)
 as begin
	begin try
	begin transaction

		if @Dni not in (select Dni from PACIENTES where Dni = @Dni) begin
			INSERT INTO Usuarios(NombreUsuario, Pass, Email, Tipo, Estado)
			values	(@NombreUsuario, @Pass, @Email, 4, 1)

			declare @iDusuario int 
			select @iDusuario = ID from Usuarios where NombreUsuario = @NombreUsuario
			INSERT INTO PACIENTES (IDUsuario, Nombre, Apellido, Nacimiento, Dni, EMail, Celular, Domicilio, CodPostal)
			values (@iDusuario, @Nombre, @apellido, @Nacimiento, @Dni, @Email, @Celular, @Domicilio, @CodPostal)
		end 
		else begin
			raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		end
	commit transaction
	end try
	begin catch
		raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		rollback transaction
	end catch
end

go
exec SP_Nuevo_Paciente 'Tomas', 'Moreno', '1999-04-24', 41893710, 'tomasmoreno@gmail.com', 1111111111, 'Agustin de Elia 1155', 1704, 'tmoreno', '1234';

go
create or alter procedure SP_Modificar_Paciente
	--Para Paciente
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Nacimiento datetime,
	--@Dni bigint,
	@Email varchar(150),
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int,
	--Para Usuario
	@ID int,
	@NombreUsuario varchar(100),
	@Pass varchar(100)
as begin
	begin try
	begin transaction
		update Usuarios set NombreUsuario = @NombreUsuario, Pass = @Pass, Email = @Email where ID = @ID
		update Pacientes set Nombre = @Nombre, Apellido = @Apellido, Nacimiento = @Nacimiento, Celular = @Celular, Domicilio = @Domicilio, CodPostal = @CodPostal where IDUsuario = @ID
	commit transaction
	end try
	begin catch
		raiserror('Hubo un problema en la modificacion, verifique si los datos estan correctos',16,2)
		rollback transaction
	end catch
end
--exec SP_Modificar_Paciente 'Tomas', 'Moreno', '1995-04-24', 'tomasmoreno@gmail.com', 1111111112, 'Agustin de Elia 1155', 1704, 1, 'tmoreno', '1234'

------ RECEPCIONISTAS ------
Go
CREATE TABLE RECEPCIONISTAS( --tipo 2--
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	Celular bigint not null,
	Domicilio varchar(100) not null,
	CodPostal int not null
)

Go
create or alter procedure SP_Nuevo_Recepcionista
	--Para Recepcionista
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Nacimiento date,
	@Dni bigint,
	@Email varchar(150),
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int,
	--Para Usuario
	@NombreUsuario varchar(100),
	@Pass varchar(100)
 as begin
	begin try
	begin transaction

		if @Dni not in (select Dni from RECEPCIONISTAS where Dni = @Dni) begin
			INSERT INTO Usuarios(NombreUsuario, Pass, Email, Tipo, Estado)
			values	(@NombreUsuario, @Pass, @Email, 2, 1)

			declare @iDusuario int 
			select @iDusuario = ID from Usuarios where NombreUsuario = @NombreUsuario
			INSERT INTO RECEPCIONISTAS (IDUsuario, Nombre, Apellido, Nacimiento, Dni, Celular, Domicilio, CodPostal)
			values (@iDusuario, @Nombre, @Apellido, @Nacimiento, @Dni, @Celular, @Domicilio, @CodPostal)
		end 
		else begin
			raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		end
	commit transaction
	end try
	begin catch
		raiserror('El DNI ya existe o hubo un error en la registracion', 16, 1)
		rollback transaction
	end catch
end

go
exec SP_Nuevo_Recepcionista 'Jesus', 'Ludena', '1999-02-24', 427779999, 'jludena@gmail.com', 1522334455, 'Florencio Varela 2054', 1704, 'jludena', '1234';


go
create or alter procedure SP_Modificar_Recepcionista
	--Para Paciente
	@Nombre varchar(100),
	@Apellido varchar(100),
	@Nacimiento datetime,
	--@Dni bigint,
	@Celular bigint,
	@Domicilio varchar(100),
	@CodPostal int,
	--Para Usuario
	@ID int,
	@NombreUsuario varchar(100),
	@Pass varchar(100),
	@Email varchar(150)
as begin
	begin try
	begin transaction
		update Usuarios set NombreUsuario = @NombreUsuario, Pass = @Pass, Email = @Email where ID = @ID
		update RECEPCIONISTAS set Nombre = @Nombre, Apellido = @Apellido, Nacimiento = @Nacimiento, Celular = @Celular, Domicilio = @Domicilio, CodPostal = @CodPostal where IDUsuario = @ID
	commit transaction
	end try
	begin catch
		raiserror('Hubo un problema en la modificacion, verifique si los datos estan correctos',16,2)
		rollback transaction
	end catch
end

--select r.IDUsuario, u.Pass, u.NombreUsuario, r.Nombre, r.Apellido, r.Nacimiento, r.Dni, u.EMail, r.Celular, r.Domicilio, r.CodPostal from RECEPCIONISTAS r inner join Usuarios u on u.ID = r.IDUsuario where u.Estado=1
Go
create or alter procedure SP_Baja_Recepcionista
	@IDUsuario int
as begin
	begin try
	begin transaction
		delete from RECEPCIONISTAS where IDUsuario = @IDUsuario
		delete from Usuarios where ID = @IDUsuario
	commit transaction
	end try
	begin catch
		rollback transaction
		raiserror('Ocurrio un error al borrar los registros de las tablas Usuarios y Recepcionistas', 16, 2)
	end catch
end



------ TURNOS ------	
Go
Create Table Estados_Turnos(
	--ID int not null primary key identity(1, 1),
	Tipo tinyint not null primary key check(Tipo > 0), -- ("1, 2, 3, 4, 5, 6"),
	Descripcion varchar(100) not null -- ("Nuevo, Reprogramado, Cancelado, No Asistió, Cerrado, etc.")
)
Go
insert into Estados_Turnos(Tipo, Descripcion)
values
(1, 'Nuevo'),
(2, 'Reprogramado'),
(3, 'Cancelado'),
(4, 'No asistio'),
(5, 'Cerrado')

Go
Create Table Turnos(
	IDTurno bigint not null primary key identity(1, 1),
	IDPaciente int foreign key references PACIENTES(IDUsuario),
	IDMedico int not null foreign key references MEDICOS(IDUsuario),
	Fecha date not null,
	Observacion varchar(200) default '-',
	Hora time not null, 
	Estado tinyint not null foreign key references Estados_Turnos(Tipo) default 1,
	Asignado bit not null default 0
)
Go
create procedure SP_InsertarTurno
	@IDMedico int,
	@Fecha date,
	@Hora time,
	@Estado tinyint = 1,
	@Asignado bit = 0

	as begin
		begin try
		begin transaction
			insert into Turnos (IDMedico, Fecha, Hora, Estado, Asignado) values
			(@IDMedico, @Fecha, @Hora, @Estado, @Asignado)
		commit transaction
		end try
		begin catch
			raiserror('Hubo un error en la creacion del turno', 16, 10)
		end catch
	end

	select IDTurno, IDMedico, IDPaciente, Fecha, Hora from Turnos

--EN ETAPA DE CREACION
--Go
--Create Table Estados_Turnos(
--	ID int not null primary key identity(1, 1),
--	Tipo tinyint not null check(Tipo > 0), -- ("1, 2, 3, 4, 5, 6"),
--	Descripcion varchar(100) not null -- ("Nuevo, Reprogramado, Cancelado, No Asistió, Cerrado, etc.")
--)

--Go
--CREATE TABLE TURNOS_TRABAJO( --es una especie de codigo generalizado para turnos
--	ID int not null primary key identity(1,1),
--	IDMedico int not null foreign key references Medicos(ID),
--	Tipo tinyint not null check(Tipo>0), --1=mañana 2=tarde
--	Entrada time not null,
--	Salida time not null,
--	Estado bit not null
--)

--go
--CREATE TABLE TURNOS_ATENCION(
--	ID int primary key identity(1,1),

--)



