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

insert into [Instalaciones] (Direccion, Telefono)
values ('Calle 50', '215451554');

insert into [Clientes] (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso)
values ('Juan Pérez', 'CC123456', 25, 'juanperez@mail.com', '3001234567', 1.75, 70.5);

/*Instalaciones-Empleados*/
create table [InstalacionesEmpleados]
(
	[Id] int primary key identity(1,1),
	[IdInstalaciones] int references [Instalaciones]([Id]),
	[IdEmpleados] int references [Empleados]([Id])
);

insert into [Instalaciones] (Direccion, Telefono)
values ('Carrera 45 #20-15, Medellín', '6047654321');


insert into [Empleados] (Nombre, Identificacion, Telefono, AnhosExperiencia, Salario, Estado, Especialidad, Cargo, HorarioDisponible)
values ('Ana Gómez', 'CC987654', '3019876543', 5, 2500000, 1, 'Entrenamiento Funcional', 'Instructor', 'Lunes a Viernes 6-10am');

insert into [Empleados] (Nombre, Identificacion, Telefono, AnhosExperiencia, Salario, Estado, Especialidad, Cargo, HorarioDisponible)
values ('Julian Arias', 'CC123456', '3000000000', 6, 1600000, 1, 'Entrenamiento', 'Instructor', 'Lunes a Viernes 6-10am');

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

insert into [Clientes] (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso)
values ('Carlos López', 'CC654321', 30, 'carloslopez@mail.com', '3016543210', 1.80, 80.0);

insert into [Membresias] (Valor, TipoMembresia)
values (120000, 'Mensual');


/*Clientes-Suplementos*/
create table [ClientesSuplementos]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdSuplementos] int references [Suplementos]([Id]) not null,
	[CantidadCompraSuplementos] int not null,
	[ValorTotalCompra] decimal (10,2) not null,
);

insert into [Clientes] (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso)
values ('María Torres', 'CC456789', 28, 'mariatorres@mail.com', '3024567890', 1.65, 60.0);

insert into [Proveedores] (NombreEntidad, ValorTotalVenta, Direccion, Telefono)
values ('Fitness Corp', 15000000, 'Carrera 80 #45-12, Medellín', '6047654321');

insert into [Suplementos] (NombreSuplemento, TipoSuplemento, Valor, Cantidad, Proveedor)
values ('Proteína Whey', 'Proteína', 150000, 50, 1);


/*Clientes-ClasesGrupales*/
create table [ClientesClasesGrupales]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdClasesGrupales] int references [ClasesGrupales]([Id]) not null,
	[Asistencias] int,
);

insert into [Clientes] (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso)
values ('Laura Martínez', 'CC112233', 22, 'lauramartinez@mail.com', '3031122334', 1.70, 58.0);

insert into [ClasesGrupales] (Duracion, TipoClase, CapacidadMax, Nivel)
values (1.5, 'Yoga', 20, 'Principiante');


/*Clientes-Instrumentos*/
create table [ClientesInstrumentos]
(
	[Id] int primary key identity(1,1),
	[IdClientes] int references [Clientes]([Id]) not null,
	[IdInstrumentos] int references [Instrumentos]([Id]) not null,
);

insert into [Clientes] (Nombre, Identificacion, Edad, CorreoElectronico, Telefono, Estatura, Peso)
values ('Pedro Ramírez', 'CC998877', 35, 'pedroramirez@mail.com', '3049988776', 1.78, 82.0);

insert into [Proveedores] (NombreEntidad, ValorTotalVenta, Direccion, Telefono)
values ('Strong Machines', 20000000, 'Av. Industriales #10-22, Medellín', '6043344556');

insert into [Instrumentos] (NombreInstrumento, CantidadEquip, Piezas, Marca, DescripcionGeneral, Estado, Proveedor)
values ('Cinta de correr', 5, 5, 'Athletic', 'Cintas eléctricas para cardio', 1, 2);


	/*Atributos multivalorados*/

/*Beneficios-Membresias*/
create table [BeneficiosMembresias]
(
	[Id] int primary key identity(1,1),
	[Beneficios] nvarchar(20) not null,
	[IdMembresias] int references [Membresias]([Id])
);

insert into [Membresias] (Valor, TipoMembresia)
values (250000, 'Trimestral');
