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

/*Instalaciones Empleados*/


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

