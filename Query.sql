create database FinalProg2
go
use FinalProg2
go 

create table Usuarios (
idusuario int not null primary key identity(1,1),
Nombre varchar(50) not null,
Correo varchar (60) not null,
Clave varchar(30) not null,
Estado varchar(20) not null,
Rol int not null,
IdCliente int,
)
alter table Usuarios add constraint ck_Admin check (Rol in (1,2))
alter table Usuarios add constraint ck_Estado check(Estado in ('Activo','Inactivo'))
alter table Usuarios add constraint UQ_Correo unique(Correo)
alter table usuarios add constraint
fk_UsuarioCliente foreign key (IdCliente) references Cliente(idCliente)


create table Cliente (
idCliente int not null primary key identity (1,1),
Nombre varchar (40) not null,
Apellido varchar (40) not null,
CedulaPasaporte varchar (40) not null,
FechaNacimiento varchar(40) not null,
Edad int not null, 
Direccion varchar(60) not null,
Telefono  bigint not null,
Celular bigint not null,
PrestamoA int,
);
Alter table cliente add constraint UQ_CedulaP unique(CedulaPasaporte)
Alter table cliente add constraint UQ_Celular unique(Celular)
Alter table cliente add constraint UQ_Tel unique(Telefono)
Alter table cliente add constraint ck_PrestamoA check(PrestamoA in (0,1))
	
create table Prestamos(
	IdPrestamo int not null primary key identity(1,1),
	Intereses decimal(13,2) not null,
	Capital decimal(13,2) not null,
	Tiempo varchar(50) not null,
	Fecha Date not null default getdate(),
	Cuotas int not null,
	Pagos decimal(13,2) not null,
	DeudaPendiente decimal(13,2) not null,
	IdCliente int not null,
);
alter table Prestamos add constraint
fk_PrestamoCliente foreign key(IdCliente) references Cliente(IdCliente)
Select * from Cliente where IdCliente = 1


insert into Cliente(Nombre,Apellido,CedulaPasaporte,FechaNacimiento,Edad,Direccion,Telefono,Celular,PrestamoA) 
values ('Raiza','Polanco','402-1484463-7','10-10-2000',18,'Puerto Plata',8095740931,8299755733,0)

insert into Cliente(Nombre,Apellido,CedulaPasaporte,FechaNacimiento,Edad,Direccion,Telefono,Celular,PrestamoA) 
values ('Fernando','Polanco','402-1484462-7','10-15-2000',18,'Puerto Plata',8095740930,8299795734,0)

insert into Usuarios(Nombre,Correo,Clave,Estado,Rol) values('Administrador','administrador@gmail.com','admin','Activo',2)
