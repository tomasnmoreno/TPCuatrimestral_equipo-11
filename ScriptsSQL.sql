CREATE DATABASE TP_CUATRIMESTRAL
GO
USE TP_CUATRIMESTRAL
GO

CREATE TABLE ESPECIALIDADES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	NOMBRE VARCHAR(50) NOT NULL UNIQUE, 
	DESCRIPCION VARCHAR(1000) NOT NULL ,
	IMAGEN VARCHAR(200) NOT NULL 
)

INSERT INTO ESPECIALIDADES (NOMBRE, DESCRIPCION, IMAGEN)
VALUES
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


--EN ETAPA DE CREACION
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
