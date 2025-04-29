-- crear tabla de roles 
create table roles ( 
    rol_id int primary key identity(1,1), 
    descripcion varchar(100) not null, 
    fecha_creacion datetime default getdate() 
); 

-- crear tabla de usuarios 
create table usuarios ( 
    id int primary key identity(1,1), 
    nombres varchar(100) not null, 
    username varchar(50) not null unique, 
    rol_id int not null, 
    telefono varchar(20), 
    correo varchar(100), 
    foreign key (rol_id) references roles(rol_id) 
); 

-- crear tabla de solicitudes 
create table solicitudes ( 
    id int primary key identity(1,1), 
    descripcion varchar(500), 
    monto decimal(18,2), 
    fecha_esperada date, 
    estado varchar(20) not null check (estado in ('pendiente', 'aprobada','rechazada')), 
    comentario varchar(500)
); 

-- crear tabla de auditoría 
create table auditoria ( 
    id int primary key identity(1,1), 
    tabla_afectada varchar(50) not null, 
    id_registro int not null, 
    tipo_operacion varchar(20) not null, 
    fecha_operacion datetime default getdate(), 
    usuario_id int, 
    datos_anteriores varchar(max), 
    datos_nuevos varchar(max), 
    foreign key (usuario_id) references usuarios(id) 
); 

-- crear triggers para auditoría de usuarios 
create trigger tr_usuarios_auditoria 
on usuarios 
after insert, update, delete 
as 
begin 
    set nocount on; 
    
    -- para inserciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_nuevos) 
    select 
        'usuarios', 
        id, 
        'insert', 
        (select * from inserted i where i.id = inserted.id for json auto) 
    from inserted 
    where not exists (select 1 from deleted); 

    -- para actualizaciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores, datos_nuevos) 
    select 
        'usuarios', 
        i.id, 
        'update', 
        (select * from deleted d where d.id = i.id for json auto), 
        (select * from inserted i2 where i2.id = i.id for json auto) 
    from inserted i 
    inner join deleted d on i.id = d.id; 

    -- para eliminaciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores) 
    select 
        'usuarios', 
        id, 
        'delete', 
        (select * from deleted d where d.id = deleted.id for json auto) 
    from deleted 
    where not exists (select 1 from inserted); 
end; 

-- crear triggers para auditoría de solicitudes 
create trigger tr_solicitudes_auditoria 
on solicitudes 
after insert, update, delete 
as 
begin 
    set nocount on; 
    
    -- para inserciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_nuevos) 
    select 
        'solicitudes', 
        id, 
        'insert', 
        (select * from inserted i where i.id = inserted.id for json auto) 
    from inserted 
    where not exists (select 1 from deleted); 

    -- para actualizaciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores, datos_nuevos) 
    select 
        'solicitudes', 
        i.id, 
        'update', 
        (select * from deleted d where d.id = i.id for json auto), 
        (select * from inserted i2 where i2.id = i.id for json auto) 
    from inserted i 
    inner join deleted d on i.id = d.id; 

    -- para eliminaciones 
    insert into auditoria (tabla_afectada, id_registro, tipo_operacion, datos_anteriores) 
    select 
        'solicitudes', 
        id, 
        'delete', 
        (select * from deleted d where d.id = deleted.id for json auto) 
    from deleted 
    where not exists (select 1 from inserted); 
end;