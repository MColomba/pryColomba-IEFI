--Crear la base de datos, hacerlo parado sobre 'master'
CREATE DATABASE IEFI

--Crear las tablas, hacerlo parado sobre 'IEFI', crearlas en orden
--1
CREATE TABLE Roles
(
Codigo INT PRIMARY KEY IDENTITY,
NombreRol VARCHAR(30) null
)
--2
CREATE TABLE Usuarios
(
Codigo INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(70) null,
Contraseña VARCHAR(15) null,
Rol INT null,
FOREIGN KEY (Rol) REFERENCES Roles(Codigo)
)
--3
CREATE TABLE Auditoria
(
Codigo INT PRIMARY KEY IDENTITY,
Usuario INT null,
Fecha DATE null,
TiempoUso DECIMAL(7, 2) null,
FOREIGN KEY (Usuario) REFERENCES Usuarios(Codigo)
)
--4
CREATE TABLE Personas
(
Codigo INT PRIMARY KEY IDENTITY,
Usuario INT null,
Documento VARCHAR(8) null,
NombreCompleto VARCHAR(70) null,
Direccion VARCHAR(70) null,
FechaNacimiento DATE null,
Telefono VARCHAR(16) null,
FOREIGN KEY (Usuario) REFERENCES Usuarios(Codigo)
)

--Crear los datos dentro de las tablas, hacerlo parado sobre 'IEFI', insertar en orden
--1
INSERT INTO Roles (NombreRol)
VALUES ('Administrador'), ('Empleado')
--2
INSERT INTO Usuarios (Nombre, Contraseña, Rol)
VALUES ('admin','admin', 1)
--3
INSERT INTO Auditoria (Usuario, Fecha, TiempoUso)
VALUES (1, '20250605', 6), (1, '20250609', 15), (1, '20250615', 8)
--4
INSERT INTO Personas (Usuario, Documento, NombreCompleto, Direccion, FechaNacimiento, Telefono)
VALUES (1, '11111111', 'Test de Admin', 'Direccion Test Admin 3245', '19991225', '0001112233'),
(2, '22222222', 'Test de User', 'Direccion Test User 3125', '20000101', '1112223333')