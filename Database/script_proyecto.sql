USE master
GO

--********** CREACIÓN DE BASE DE DATOS **********
IF EXISTS (
  SELECT name
   FROM sys.databases
   WHERE name = 'SistemaContable'
)
DROP DATABASE SistemaContable
GO

CREATE DATABASE SistemaContable
GO

USE SistemaContable
GO

--********** CREACIÓN DE TABLAS **********

-- Creación de tabla 'USUARIOS'
CREATE TABLE Usuarios
(
    id_usuario INT IDENTITY(1,1) NOT NULL,
    correo NVARCHAR(MAX),
    contraseña NVARCHAR(MAX),   
);

-- Creación de tabla 'NOMENCLATURA'
CREATE TABLE Nomenclatura
(
    id_cuenta INT IDENTITY(1,1) NOT NULL,
    num_cuenta NVARCHAR(MAX),
    nombre_cuenta NVARCHAR(MAX),    
    descripcion NVARCHAR(MAX),
    tipo_cuenta NVARCHAR(MAX),
    nivel INT
); 

-- Creación de tabla 'INVENTARIO'
CREATE TABLE Inventario
(
    id_cuenta INT IDENTITY(1,1) NOT NULL,
    detalle NVARCHAR(MAX),
    cantidad FLOAT,    
);

-- Creación de tabla 'PARTIDA_DIARIO'
CREATE TABLE Partida_Diario
(
    id_partida INT IDENTITY(1,1) NOT NULL,
    correlativo NVARCHAR(MAX),
	num_documento NVARCHAR(MAX),
	fecha DATE,
	descripcion NVARCHAR(MAX)
);

-- Creación de tabla 'DETALLE_PARTIDA_DIARIO'
CREATE TABLE Detalle_Partida_Diario
(
    id_cuenta INT NOT NULL,
    id_partida INT NOT NULL,
    debe FLOAT, 
	haber FLOAT
);


--********** LLAVES PRIMARIAS **********
ALTER TABLE Usuarios
    ADD CONSTRAINT PK_USUARIO PRIMARY KEY (id_usuario);

ALTER TABLE Nomenclatura
    ADD CONSTRAINT PK_NOMENCLATURA PRIMARY KEY (id_cuenta);

ALTER TABLE Inventario
    ADD CONSTRAINT PK_INVENTARIO PRIMARY KEY (id_cuenta);

ALTER TABLE Partida_Diario
    ADD CONSTRAINT PK_PARTIDA_DIARIO PRIMARY KEY (id_partida);

ALTER TABLE Detalle_Partida_Diario
    ADD CONSTRAINT PK_DETALLE_PARTIDA_DIARIO PRIMARY KEY (id_cuenta, id_partida);


--********** LLAVES FORÁNEAS **********
ALTER TABLE Detalle_Partida_Diario
    ADD CONSTRAINT FK_DETALLE_NOMENCLATURA FOREIGN KEY(id_cuenta) 
        REFERENCES Nomenclatura(id_cuenta);

ALTER TABLE Detalle_Partida_Diario
	ADD CONSTRAINT FK_DETALLE_PARTIDA FOREIGN KEY(id_partida) 
        REFERENCES Partida_Diario(id_partida);




