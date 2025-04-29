-- crear tabla de roles 
create table tbl_roles ( 
    rol_id int primary key identity(1,1), 
    descripcion varchar(100) not null, 
    fecha_creacion datetime default getdate() 
); 

-- crear tabla de usuarios 
create table tbl_usuarios ( 
    id int primary key identity(1,1), 
    nombres varchar(100) not null, 
    username varchar(50) not null unique, 
    rol_id int not null, 
    clave varchar(20), 
    correo varchar(100), 
    foreign key (rol_id) references tbl_roles(rol_id) 
); 

-- crear tabla de solicitudes 
create table tbl_solicitudes ( 
    id int primary key identity(1,1), 
    descripcion varchar(500), 
    monto decimal(18,2), 
    fecha_esperada date, 
    estado varchar(20) not null check (estado in ('pendiente', 'aprobada','rechazada')), 
    comentario varchar(500)
); 

-- crear tabla de auditor�a 
create table tbl_auditoria ( 
    id int primary key identity(1,1), 
    tabla_afectada varchar(50) not null, 
    id_registro int not null, 
    tipo_operacion varchar(20) not null, 
    fecha_operacion datetime default getdate(), 
    usuario_id int, 
    datos_anteriores varchar(max), 
    datos_nuevos varchar(max), 
    foreign key (usuario_id) references tbl_usuarios(id) 
); 

-- crear triggers para auditor�a de usuarios 
create trigger tr_usuarios_auditoria 
on tbl_usuarios 
after insert, update, delete 
as 
begin 
    set nocount on; 
    
    -- para inserciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_nuevos) 
    select 
        'tbl_usuarios', 
        id, 
        'insert', 
        (select * from inserted i where i.id = inserted.id for json auto) 
    from inserted 
    where not exists (select 1 from deleted); 

    -- para actualizaciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores, datos_nuevos) 
    select 
        'tbl_usuarios', 
        i.id, 
        'update', 
        (select * from deleted d where d.id = i.id for json auto), 
        (select * from inserted i2 where i2.id = i.id for json auto) 
    from inserted i 
    inner join deleted d on i.id = d.id; 

    -- para eliminaciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores) 
    select 
        'tbl_usuarios', 
        id, 
        'delete', 
        (select * from deleted d where d.id = deleted.id for json auto) 
    from deleted 
    where not exists (select 1 from inserted); 
end; 

-- crear triggers para auditor�a de solicitudes 
create trigger tr_solicitudes_auditoria 
on tbl_solicitudes 
after insert, update, delete 
as 
begin 
    set nocount on; 
    
    -- para inserciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_nuevos) 
    select 
        'tbl_solicitudes', 
        id, 
        'insert', 
        (select * from inserted i where i.id = inserted.id for json auto) 
    from inserted 
    where not exists (select 1 from deleted); 

    -- para actualizaciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores, datos_nuevos) 
    select 
        'tbl_solicitudes', 
        i.id, 
        'update', 
        (select * from deleted d where d.id = i.id for json auto), 
        (select * from inserted i2 where i2.id = i.id for json auto) 
    from inserted i 
    inner join deleted d on i.id = d.id; 

    -- para eliminaciones 
    insert into tbl_auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores) 
    select 
        'tbl_solicitudes', 
        id, 
        'delete', 
        (select * from deleted d where d.id = deleted.id for json auto) 
    from deleted 
    where not exists (select 1 from inserted); 
end;




-- Insertar roles
INSERT INTO tbl_roles (descripcion)
VALUES 
('Administrador'),
('Usuario'),
('Supervisor'),
('Invitado');

-- Insertar usuarios
INSERT INTO tbl_usuarios (nombres, username, rol_id, clave, correo)
VALUES 
('kevin P�rez', 'kperez', 1, '1234567890', 'juan.perez@ejemplo.com'),
('Ana G�mez', 'agomez', 2, '0987654321', 'ana.gomez@ejemplo.com'),
('Luis Torres', 'ltorres', 3, '3216549870', 'luis.torres@ejemplo.com'),
('Mar�a Ruiz', 'mruiz', 4, '4561237890', 'maria.ruiz@ejemplo.com');

select * from [dbo].[tbl_usuarios];