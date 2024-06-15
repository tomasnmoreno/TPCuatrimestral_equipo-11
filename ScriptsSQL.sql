CREATE DATABASE TP_CUATRIMESTRAL
GO
USE TP_CUATRIMESTRAL
GO

Create Table Especialidades(
	Id Int Not Null Primary Key Identity(1, 1),
	Nombre Varchar(50) Not Null Unique,
	Descripcion Varchar(1000) Not Null,
	Imagen Varchar(200) Not Null,
	Estado Bit Not Null Default 1
)

Insert Into Especialidades (Nombre, Descripcion, Imagen)
Values
	('Odontolog�a','Rama de la medicina que se ocupa del diagn�stico, prevenci�n y tratamiento de las enfermedades y condiciones del sistema oral y maxilofacial. Esto incluye los dientes, las enc�as, el tejido periodontal, el maxilar, la mand�bula, la articulaci�n temporomandibular y otras �reas relacionadas','https://staticnew-prod.topdoctors.mx/article/18650/image/large/odontologia-digital-la-optimizacion-de-los-procesos-tradicionales-1698035005.jpeg'),
	('Traumatolog�a','Especialidad m�dica que se centra en el diagn�stico, tratamiento y prevenci�n de lesiones y enfermedades del sistema musculoesquel�tico. Esto incluye huesos, articulaciones, ligamentos, tendones y m�sculos. Los traumat�logos tratan afecciones que van desde fracturas y dislocaciones hasta desgarros de ligamentos y lesiones de la m�dula espinal.','https://centromedicoabc.com/storage/2023/01/traumatologia-ortopedia.jpg'),
	('Cardiolog�a','Disciplina m�dica que se ocupa del diagn�stico, tratamiento y prevenci�n de enfermedades del coraz�n y del sistema circulatorio. Los cardi�logos tratan afecciones como enfermedad coronaria, insuficiencia card�aca, arritmias y enfermedades de las v�lvulas del coraz�n.','https://cbahoy.com.ar/wp-content/uploads/2023/04/10-cardiologia.webp'),
	('Dermatolog�a','Rama de la medicina se ocupa del diagn�stico, tratamiento y prevenci�n de enfermedades de la piel, cabello, u�as y membranas mucosas. Los dermat�logos tratan una amplia gama de condiciones, desde acn� y psoriasis hasta c�ncer de piel y enfermedades autoinmunes de la piel.','https://www.esneca.lat/wp-content/uploads/especialidades-en-dermatologia.jpg'),
	('Gastroenterolog�a','Especialidad m�dica que se ocupa del estudio, diagn�stico y tratamiento de enfermedades del sistema digestivo y del h�gado. Los gastroenter�logos tratan afecciones que van desde enfermedad por reflujo gastroesof�gico (ERGE) y �lceras p�pticas hasta enfermedad inflamatoria intestinal y c�ncer de colon.','https://www.sanfernando.gob.ar/images/principales/46968422_Gatroenterologia.jpg'),
	('Obstetricia','Rama de la medicina se enfoca en el cuidado de la mujer durante el embarazo, el parto y el puerperio (el per�odo despu�s del parto). Los obstetras se especializan en el manejo de la salud materna y fetal durante todas las etapas del embarazo.','https://www.mgc.es/wp-content/uploads/2019/08/obstetra-eco.jpg'),
	('Pediatr�a','Especialidad m�dica que se ocupa de la salud y el bienestar de los ni�os, desde el nacimiento hasta la adolescencia. Los pediatras diagnostican y tratan una amplia gama de enfermedades infantiles, desde infecciones comunes y lesiones menores hasta enfermedades cr�nicas y graves.','https://ifses.es/wp-content/uploads/2023/04/enfermeria-pediatrica-1200x600.jpg'),
	('Neurolog�a','Disciplina m�dica se ocupa del diagn�stico y tratamiento de enfermedades del sistema nervioso, que incluye el cerebro, la m�dula espinal y los nervios perif�ricos. Los neur�logos tratan afecciones como accidente cerebrovascular, enfermedad de Parkinson, esclerosis m�ltiple y epilepsia.','https://isabelrestreponeurologa.com/wp-content/uploads/2019/11/ART1-Q-ES-NEUROLOGIA.jpg'),
	('Ginecolog�a','Especialidad m�dica que se ocupa del cuidado del sistema reproductor femenino. Los ginec�logos diagnostican y tratan enfermedades de los �rganos reproductivos femeninos, incluyendo el �tero, los ovarios y la vagina.','https://bluenethospitals.com/storage/assets/es/blog-posts/ObGyn_Ginecologia_BlueNetHOSPITALS_LosCabos.webp'),
	('Endocrinolog�a','Rama de la medicina se ocupa del diagn�stico y tratamiento de enfermedades que afectan a las gl�ndulas endocrinas, que son las que producen hormonas. Los endocrin�logos tratan afecciones como diabetes, enfermedades de la tiroides, trastornos metab�licos y problemas de crecimiento.','https://staticnew-prod.topdoctors.mx/files/Image/large/ebf822a89fa6b93e6d4dc92f9a6bfa60.jpg'),
	('Hematolog�a','Especialidad m�dica que se ocupa del estudio, diagn�stico y tratamiento de enfermedades de la sangre y los �rganos que la producen, como la m�dula �sea y el bazo. Los hemat�logos tratan afecciones como anemia, coagulaci�n sangu�nea y trastornos de la m�dula �sea.','https://policlinicametropolitana.org/wp-content/uploads/2022/02/coronavirus-vaccine-lab-with-samples.jpg'),
	('Oftalmolog�a','Rama de la medicina se ocupa del diagn�stico y tratamiento de enfermedades del ojo. Los oftalm�logos tratan afecciones como cataratas, glaucoma, degeneraci�n macular y problemas de visi�n.','https://aio-oftalmologia.com/wp-content/uploads/De-que-se-ocupa-un-oftalmologo.jpg')

Create or Alter Procedure SP_Nueva_Especialidad
	@nombre varchar(50),
	@descripcion varchar(1000),
	@imagen varchar(200)
	as
	Insert Into Especialidades (Nombre, Descripcion, Imagen)
	Values(@nombre, @descripcion, @imagen)

Create or Alter Procedure SP_Modificar_Especialidad
	@nombre varchar(50),
	@descripcion varchar(1000),
	@imagen varchar(200),
	@id int
	as
	Update Especialidades set Nombre = @nombre, Descripcion = @descripcion, Imagen = @imagen
	Where Id = @id;


--EN ETAPA DE CREACION

--Go
--Create Table Estados_Turnos(
--	ID int not null primary key identity(1, 1),
--	Tipo tinyint not null check(Tipo > 0), -- ("1, 2, 3, 4, 5, 6"),
--	Descripcion varchar(100) not null -- ("Nuevo, Reprogramado, Cancelado, No Asisti�, Cerrado, etc.")
--)

--Go
--CREATE TABLE TURNOS_TRABAJO( --es una especie de codigo generalizado para turnos
--	ID int not null primary key identity(1,1),
--	IDMedico int not null foreign key references Medicos(ID),
--	Tipo tinyint not null check(Tipo>0), --1=ma�ana 2=tarde
--	Entrada time not null,
--	Salida time not null,
--	Estado bit not null
--)

--go
--CREATE TABLE TURNOS_ATENCION(
--	ID int primary key identity(1,1),

--)

go
create table Usuarios(
	ID int not null primary key identity(1, 1),
	NombreUsuario varchar(100) not null unique,
	Pass varchar(100) not null,
	Email varchar(150) not null,
	Tipo tinyint not null,
	Estado bit not null default 1
)

--insert into Usuarios(NombreUsuario, Pass, Email, Tipo, Estado)
--	values('tmoreno', '1234', 'tomasmoreno@gmail.com.ar', 1, 1)

go
CREATE TABLE MEDICOS(
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Matricula int not null,
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	Celular tinyint not null,
	Domicilio varchar(100) not null,
	CodPostal tinyint not null,
	TurnoTrabajo tinyint not null check(TurnoTrabajo>0)
)

go
CREATE TABLE ESPECIALIDADESXMEDICOS(
	IDEspecialidad int foreign key references ESPECIALIDADES(ID), 
	IDMedico int not null foreign key references Medicos(IDUsuario)
	Primary Key(IDEspecialidad, IDMedico)
)

go
CREATE TABLE PACIENTES(
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	Mail varchar(150),
	Celular tinyint not null,
	Domicilio varchar(100) not null,
	CodPostal tinyint not null
)

Go
CREATE TABLE RECEPCIONISTAS(
	IDUsuario int not null primary key foreign key references Usuarios(ID),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	Nacimiento date not null,
	Dni bigint not null unique,
	Celular tinyint not null,
	Domicilio varchar(100) not null,
	CodPostal tinyint�not�null
)

