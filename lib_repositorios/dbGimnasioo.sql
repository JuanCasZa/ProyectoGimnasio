create database dbGimnasioo
go
use dbGimnasio
go


create table [Personas] 
(
	[Id] int primary key identity(1,1),
	[Nombre] nvarchar(50) not null,
	[Identificacion] nvarchar(20) not null,
	[Edad] int,
	[CorreoElectronico] nvarchar(100),
	[Telefono] nvarchar(20) not null,
	[Genero]nvarchar (10) not null
);

create table [Clientes]
(
	[Id] int primary key references [Personas]([Id]), /*Heredando la misma clave primaria de Personas*/
	[Estatura] decimal(4,2) not null,
	[Peso] decimal(5,2) not null
);

create table [Empleados]
(
	[Id] int primary key references [Personas]([Id]), /*Heredando la misma clave primaria de Personas*/
	[AnhosExperiencia] int not null,
	[Salario] decimal (10,2) not null,
	[Estado] bit not null, /*Disponible (1) / No disponible (0)*/
	[FechaContratacion] smalldatetime default getdate()
);

create table [Entrenadores]
(
	[Id] int primary key references [Empleados]([Id]), /*Heredando la misma clave primaria de PersonasEmpleados*/
	[Especialidad] nvarchar(50) not null,
	[HorarioDisponible] nvarchar(50) not null
);

create table [OtrosEmpleados]
(
	[id] int primary key references [Empleados]([Id]), /*Heredando la misma clave primaria de PersonasEmpleados*/
	[Cargo] nvarchar(30) not null,
	[Turno] nvarchar(20) not null,
	[HorasTrabajo] int not null
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
	[DescripcionGeneral] nvarchar(200),
	[Estado] bit not null,
	[Proveedor] int references [Proveedores]([Id]) 
);

create table [Equipamientos]
(
	[Id] int primary key references [Instrumentos]([Id]), /*Heredando la misma clave primaria de Instrumentos*/
	[CantidadEquip] int not null,
	[Peso] decimal (10,2) not null,
	[Material] nvarchar (30) not null
);

create table [Maquinarias]
(
	[Id] int primary key references [Instrumentos]([Id]), /*Heredando la misma clave primaria de Instrumentos*/
	[PesoMax] decimal (10,2) not null,
	[PesoMin] decimal (10,2) not null,
	[Piezas] int not null,
	[Marca] nvarchar (30) not null,
	[AnhoFabricacion] nvarchar (10)
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

	/*Tablas de relaciones muchos a muchos con Clientes*/

/*Clientes-Membresias*/

create table [ClientesMembresias]
(
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdMembresias] int references [Membresias]([Id]) not null,
	[FechaInicio] smalldatetime default getdate(),
	[FechaFin] smalldatetime default getdate(),
	[Id] int primary key ([IdClientes], [IdMembresias])
);

/*Clientes-Suplementos*/

create table [ClientesSuplementos]
(
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdSuplementos] int references [Suplementos]([Id]) not null,
	[CantidadCompraSuplementos] int not null,
	[ValorTotalCompra] decimal (10,2) not null,
	[Id] int primary key ([IdClientes], [IdSuplementos])
);

/*Clientes-ClasesGrupales*/

create table [ClientesClasesGrupales]
(
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdClasesGrupales] int references [ClasesGrupales]([Id]) not null,
	[Asistencias] int,
	[Id] int primary key ([Idclientes], [IdClasesGrupales])
);

/*Clientes-Instrumentos*/
create table [ClientesInstrumentos]
(
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdInstrumentos] int references [Instrumentos]([Id]) not null,
	[Id] int primary key ([IdClientes], [IdInstrumentos])
);

	/*Tabla de relación muchos a muchos con Entrenadores*/

/*Entrenadores-ClasesGrupales*/

create table [EntrenadoresClasesGrupales]
(
	[IdEntrenadores] int references [Entrenadores]([Id]) not null,
	[IdClasesGrupales] int references [ClasesGrupales]([Id]) not null,
	[Id] int primary key (IdEntrenadores, IdClasesGrupales)
);

