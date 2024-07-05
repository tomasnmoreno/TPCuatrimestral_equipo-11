select t.IDTurno as 'Nro de turno', m.Nombre + ', ' + m.Apellido as Medico, e.Nombre Especialidad, p.Nombre + ', ' + p.Apellido as Paciente, t.Fecha, t.Hora from Turnos t
inner join MEDICOS m on m.IDUsuario = t.IDMedico
left join PACIENTES p on p.IDUsuario = t.IDPaciente
inner join EspecialidadesXMedicos exm on exm.IDMedico = t.IDMedico
inner join Especialidades e on e.Id = exm.IDEspecialidad

para 
select t.IDTurno, m.Nombre + ', ' + m.Apellido as Medico,
e.Nombre as Especialidad,
p.Nombre + ', ' + p.Apellido as Paciente,
t.Fecha,
t.Hora 
from Turnos t inner join MEDICOS m on m.IDUsuario = t.IDMedico left join PACIENTES p on p.IDUsuario = t.IDPaciente inner join EspecialidadesXMedicos exm on exm.IDMedico = t.IDMedico inner join Especialidades e on e.Id = exm.IDEspecialidad where e.Id = 8