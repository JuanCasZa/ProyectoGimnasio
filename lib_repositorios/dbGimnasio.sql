create database dbGimnasio;
go
use dbGimnasio;
go

create table [Instalaciones]
(
	[Id] int primary key identity(1,1),
	[Direccion] nvarchar(150) not null,
	[Telefono] nvarchar(10)
);

create table [Clientes]
(
	[Id] int primary key identity (1,1),
	[Nombre] nvarchar(50) not null,
	[Identificacion] nvarchar(20) not null,
	[Edad] int,
	[CorreoElectronico] nvarchar(100),
	[Telefono] nvarchar(10) not null,
	[Estatura] decimal(4,2) not null,
	[Peso] decimal(5,2) not null
);

create table [Empleados]
(
	[Id] int primary key identity(1,1),
	[Nombre] nvarchar(50) not null,
	[Identificacion] nvarchar(20) not null,
	[Telefono] nvarchar(10) not null,
	[AnhosExperiencia] int not null,
	[Salario] decimal (10,2) not null,
	[Estado] bit not null,
	[Especialidad] nvarchar(50) not null,
	[Cargo] nvarchar(30) not null,
	[HorarioDisponible] nvarchar(50) not null,
	[FechaContratacion] smalldatetime default getdate()
);

create table [Proveedores]
(
	[Id] int primary key identity(1,1),
	[NombreEntidad] nvarchar(50) not null,
	[ValorTotalVenta] decimal (10,2) not null,
	[Direccion] nvarchar (50) not null,
	[Telefono] nvarchar(20) not null
);

create table [Instrumentos]
(
	[Id] int primary key identity(1,1),
	[NombreInstrumento] nvarchar(50) not null,
	[CantidadEquip] int not null,
	[Piezas] int not null,
	[Marca] nvarchar (30) not null,
	[DescripcionGeneral] nvarchar(200),
	[Estado] bit not null,
	[Proveedor] int references [Proveedores]([Id]) 
);

create table [Membresias]
(
	[Id] int primary key identity(1,1),
	[Valor] decimal (10,2) not null,
	[TipoMembresia] nvarchar (40) not null
);

create table [Suplementos]
(
	[Id] int primary key identity(1,1),
	[NombreSuplemento] nvarchar(50) not null,
	[TipoSuplemento] nvarchar(20) not null,
	[Valor] decimal (10,2) not null,
	[Cantidad] int not null,
	[Proveedor] int references [Proveedores]([Id])
);

create table [ClasesGrupales]
(
	[Id] int primary key identity(1,1),
	[Duracion] decimal (4,2) not null,
	[TipoClase] nvarchar(20) not null, 
	[CapacidadMax] int not null,
	[Nivel] nvarchar(20) not null
);

	/*Tablas de relaciones muchos a muchos con Instalaciones*/

/*Instalaciones-Clientes*/
create table [InstalacionesClientes]
(
	[Id] int primary key identity(1,1),
	[IdInstalaciones] int references [Instalaciones]([Id]),
	[IdClientes] int references [Clientes]([Id]),
	[RegistroIngresoClientes] int not null
);

/*Instalaciones-Empleados*/
create table [InstalacionesEmpleados]
(
	[Id] int primary key identity(1,1),
	[IdInstalaciones] int references [Instalaciones]([Id]),
	[IdEmpleados] int references [Empleados]([Id])
);

	/*Tablas de relaciones muchos a muchos con Clientes*/

/*Clientes-Membresias*/
create table [ClientesMembresias]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdMembresias] int references [Membresias]([Id]) not null,
	[FechaInicio] smalldatetime default getdate(),
	[FechaFin] smalldatetime default getdate(),
);

/*Clientes-Suplementos*/
create table [ClientesSuplementos]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdSuplementos] int references [Suplementos]([Id]) not null,
	[CantidadCompraSuplementos] int not null,
	[ValorTotalCompra] decimal (10,2) not null,
);

/*Clientes-ClasesGrupales*/
create table [ClientesClasesGrupales]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdClasesGrupales] int references [ClasesGrupales]([Id]) not null,
	[Asistencias] int,
);

/*Clientes-Instrumentos*/
create table [ClientesInstrumentos]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdInstrumentos] int references [Instrumentos]([Id]) not null,
);

	/*Atributos multivalorados*/

/*Beneficios-Membresias*/
create table [BeneficiosMembresias]
(
	[Id] int primary key identity(1,1),
	[Beneficios] nvarchar(20) not null,
	[IdMembresias] int references [Membresias]([Id])
);

INSERT INTO Instalaciones (Direccion, Telefono) VALUES
('Calle 123 #45-67', '3104567890'),
('Av. Siempre Viva 742', '3112345678'),
('Cra 10 #20-30', '3009876543'),
('Calle 50 #10-20', '3021234567'),
('Carrera 100 #200-10', '3159871234');

INSERT INTO Clientes (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso) VALUES
('Juan Perez', '123456789', 25, 'juanperez@gmail.com', '3101234567', 1.75, 70.5),
('Maria Lopez', '987654321', 30, 'marialopez@hotmail.com', '3207654321', 1.60, 60.2),
('Carlos Gomez', '112233445', 40, 'cgomez@outlook.com', '3119988776', 1.80, 82.0),
('Ana Torres', '556677889', 22, 'ana.torres@gmail.com', '3125556677', 1.68, 58.4),
('Luis Ramirez', '443322110', 35, 'lramirez@hotmail.com', '3131239876', 1.70, 75.0);

INSERT INTO Empleados (Nombre, Identificacion, Telefono, AnhosExperiencia, Salario, Estado, Especialidad, Cargo, HorarioDisponible) VALUES
('Pedro Sanchez', '100200300', '3101122334', 5, 2500000, 1, 'Pesas', 'Instructor', 'Lunes-Viernes 8-12'),
('Laura Martinez', '200300400', '3202233445', 3, 1800000, 1, 'Yoga', 'Entrenadora', 'Lunes-Viernes 6-10'),
('Andres Rios', '300400500', '3113344556', 7, 3000000, 1, 'Crossfit', 'Coach', 'Lunes-Sábado 14-18'),
('Sofia Castro', '400500600', '3124455667', 2, 1600000, 1, 'Pilates', 'Instructora', 'Martes-Jueves 10-14'),
('Diego Fernandez', '500600700', '3135566778', 10, 4000000, 1, 'Natación', 'Entrenador', 'Todos los días 7-11');

INSERT INTO Proveedores (NombreEntidad, ValorTotalVenta, Direccion, Telefono) VALUES
('Fitness World', 5000000, 'Av. Central #45', '6011234567'),
('NutriHealth', 3000000, 'Cra 15 #20-50', '6019876543'),
('StrongEquip', 8000000, 'Calle 77 #33-44', '6017654321'),
('PowerFoods', 2500000, 'Av. Norte #88-22', '6013456789'),
('SportLife', 4500000, 'Cra 30 #40-90', '6012349876');

INSERT INTO Instrumentos (NombreInstrumento, CantidadEquip, Piezas, Marca, DescripcionGeneral, Estado, Proveedor) VALUES
('Mancuernas', 20, 40, 'StrongEquip', 'Set de mancuernas de acero', 1, 3),
('Bicicleta Estática', 10, 10, 'FitnessPro', 'Bicicletas para cardio', 1, 1),
('Caminadora', 5, 5, 'SportRun', 'Caminadora eléctrica con monitor', 1, 5),
('Banco de Pesas', 8, 8, 'StrongEquip', 'Banco ajustable para pesas', 1, 3),
('Elíptica', 6, 6, 'FitMotion', 'Máquina elíptica de resistencia', 1, 1);

INSERT INTO Membresias (Valor, TipoMembresia) VALUES
(100000, 'Mensual'),
(270000, 'Trimestral'),
(500000, 'Semestral'),
(900000, 'Anual'),
(1500000, 'VIP Anual');

INSERT INTO Suplementos (NombreSuplemento, TipoSuplemento, Valor, Cantidad, Proveedor) VALUES
('Proteína Whey', 'Proteína', 120000, 50, 2),
('Creatina Monohidratada', 'Creatina', 90000, 40, 2),
('BCAA 2:1:1', 'Aminoácidos', 80000, 30, 4),
('Glutamina', 'Aminoácidos', 70000, 25, 2),
('Omega 3', 'Vitaminas', 60000, 60, 4);

INSERT INTO ClasesGrupales (Duracion, TipoClase, CapacidadMax, Nivel) VALUES
(1.00, 'Yoga', 20, 'Básico'),
(1.50, 'Crossfit', 15, 'Intermedio'),
(2.00, 'Spinning', 25, 'Avanzado'),
(1.00, 'Pilates', 18, 'Básico'),
(1.20, 'Zumba', 30, 'Intermedio');

INSERT INTO InstalacionesClientes (IdInstalaciones, IdClientes, RegistroIngresoClientes) VALUES
(1, 1, 15),
(1, 2, 12),
(2, 3, 8),
(3, 4, 20),
(4, 5, 10);

INSERT INTO InstalacionesEmpleados (IdInstalaciones, IdEmpleados) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5);

INSERT INTO ClientesMembresias (IdClientes, IdMembresias, FechaInicio, FechaFin) VALUES
(1, 1, GETDATE(), DATEADD(MONTH, 1, GETDATE())),
(2, 2, GETDATE(), DATEADD(MONTH, 3, GETDATE())),
(3, 3, GETDATE(), DATEADD(MONTH, 6, GETDATE())),
(4, 4, GETDATE(), DATEADD(YEAR, 1, GETDATE())),
(5, 5, GETDATE(), DATEADD(YEAR, 1, GETDATE()));

INSERT INTO ClientesSuplementos (IdClientes, IdSuplementos, CantidadCompraSuplementos, ValorTotalCompra) VALUES
(1, 1, 2, 240000),
(2, 2, 1, 90000),
(3, 3, 3, 240000),
(4, 4, 1, 70000),
(5, 5, 2, 120000);

INSERT INTO ClientesClasesGrupales (IdClientes, IdClasesGrupales, Asistencias) VALUES
(1, 1, 10),
(2, 2, 5),
(3, 3, 8),
(4, 4, 12),
(5, 5, 7);

INSERT INTO ClientesInstrumentos (IdClientes, IdInstrumentos) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

INSERT INTO BeneficiosMembresias (Beneficios, IdMembresias) VALUES
('Spa', 5),
('Entrenador Personal', 5),
('Descuento Suplemento', 4),
('Clases Ilimitadas', 4),
('Locker Privado', 3);

/*Creación nuevas tablas e incersiones de datos*/

create table [Roles]
(
	[Id] int primary key identity,
	[Tipo] nvarchar(20) not null,
);

create table [Usuarios]
(
	[Id] int primary key identity,
	[Nombre] nvarchar(50) not null,
	[Contrasenha] nvarchar(100) not null,
	[IdEmpleado] int references [Empleados]([Id]),
	[IdRol] int references [Roles]([Id])
);


create table [Permisos]
(
	[Id] int primary key identity,
	[TipoPermiso] nvarchar(10) not null,
	[Permitido] bit not null,
	[IdRol] int references [Roles]([Id])
);

create table [Auditorias]
(
	[Id] int primary key identity,
	[TipoOperacion] nvarchar(10) not null,
	[Fecha] smalldatetime default getdate(),
	[ValoresAntiguos] nvarchar(50) not null default 'Sin valores',
	[ValoresNuevos] nvarchar(50) not null,
	[IdUsuario] int references [Usuarios]([Id])
);

/*Drops tablas*/
/*
drop table Roles;
drop table Permisos;
drop table Auditorias;
drop table Usuarios;
*/

/*Inserciones Ejecutadas*/
INSERT INTO Roles (Tipo) VALUES ('Administrador');
INSERT INTO Roles (Tipo) VALUES ('Entrenador');
INSERT INTO Roles (Tipo) VALUES ('Recepcionista');
INSERT INTO Roles (Tipo) VALUES ('Ventas');

INSERT INTO Usuarios (Nombre, Contrasenha, IdEmpleado, IdRol) VALUES ('JuanPerez', '1234Segura!', 1, 1);
INSERT INTO Usuarios (Nombre, Contrasenha, IdEmpleado, IdRol) VALUES ('MariaGomez', 'Passw0rd$', 2, 2);
INSERT INTO Usuarios (Nombre, Contrasenha, IdEmpleado, IdRol) VALUES ('CarlosDiaz', 'Clave#2025', 3, 3);
INSERT INTO Usuarios (Nombre, Contrasenha, IdEmpleado, IdRol) VALUES ('LauraMendez', 'Admin@123', 4, 4);

INSERT INTO Permisos (TipoPermiso, Permitido, IdRol) VALUES ('Leer', 1, 1);
INSERT INTO Permisos (TipoPermiso, Permitido, IdRol) VALUES ('Escribir', 1, 1);
INSERT INTO Permisos (TipoPermiso, Permitido, IdRol) VALUES ('Modificar', 1, 2);
INSERT INTO Permisos (TipoPermiso, Permitido, IdRol) VALUES ('Eliminar', 0, 3);
INSERT INTO Permisos (TipoPermiso, Permitido, IdRol) VALUES ('Leer', 1, 4);

/*Inserciones NO realizadas*/
INSERT INTO Auditorias (TipoOperacion, ValoresAntiguos, ValoresNuevos, IdUsuario)
VALUES ('INSERT', 'Sin valores', 'Nuevo usuario creado: JuanPerez', 1);

INSERT INTO Auditorias (TipoOperacion, ValoresAntiguos, ValoresNuevos, IdUsuario)
VALUES ('UPDATE', 'Salario=2000', 'Salario=2500', 2);

INSERT INTO Auditorias (TipoOperacion, ValoresAntiguos, ValoresNuevos, IdUsuario)
VALUES ('DELETE', 'ClienteID=5', 'Sin valores', 3);

INSERT INTO Auditorias (TipoOperacion, ValoresAntiguos, ValoresNuevos, IdUsuario)
VALUES ('INSERT', 'Sin valores', 'Nuevo rol asignado: Soporte', 4);

INSERT INTO Auditorias (TipoOperacion, ValoresAntiguos, ValoresNuevos, IdUsuario)
VALUES ('UPDATE', 'Permiso=Leer', 'Permiso=Escribir', 5);
