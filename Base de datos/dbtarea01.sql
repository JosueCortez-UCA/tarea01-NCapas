-- Creación de la base de datos
CREATE DATABASE tarea01;

-- Selección de la base de datos creada para que ser usada con las siguientes instrucciones.
USE tarea01;

-- Tabla Rol
CREATE TABLE rol (
	idrol integer primary key identity,
	nombre varchar(30) not null,
	descripcion varchar(100),
	estado bit default(1)
);
GO

-- Tabla Persona
CREATE TABLE persona (
	idpersona integer primary key identity,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	edad integer not null,
	telefono varchar(20),
	idrol integer,
	FOREIGN KEY (idrol) REFERENCES rol(idrol)
);
GO


-- Inserción de roles predefinidos
INSERT INTO rol (nombre, descripcion)
VALUES
	('Rol 01', 'Es el primer rol'),
	('Rol 02', 'Es el segundo rol'),
	('Rol 03', 'Es el tercer rol'),
	('Rol 04', 'Es el cuarto rol'),
	('Rol 05', 'Es el quinto rol');
GO

SELECT * FROM rol;
GO


-- Creación de los procedimientos almacenados
-- Procedimiento Listar
CREATE PROC listar_personas
AS
	SELECT idpersona AS ID, nombre AS Nombre, apellido AS Apellido, edad AS Edad, telefono AS Telefono, idrol AS IdRol
	FROM persona
	ORDER BY idpersona DESC
GO

-- Procedimiento Insertar
CREATE PROC insertar_personas_sinrol
	@nombre varchar(50),
	@apellido varchar(50),
	@edad integer,
	@telefono varchar(20)
AS
	INSERT INTO persona(nombre, apellido, edad, telefono) values (@nombre, @apellido, @edad, @telefono)
GO
