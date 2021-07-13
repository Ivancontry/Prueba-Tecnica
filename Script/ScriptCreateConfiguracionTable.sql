create database clientes_db;
use clientes_db;
create table clientes( id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY, 
identificacion VARCHAR(10) not null, nombre varchar(30), apellidos varchar(30),
 telefono varchar(15), direccion varchar(50), salario double, estado tinyint,
 fechaCreacion datetime);

delimiter $$
CREATE PROCEDURE `ConsultarClientePorIdentificacion`(_identificacion varchar(10))
BEGIN
	SELECT * FROM clientes WHERE identificacion = _identificacion;
END$$

delimiter $$
CREATE PROCEDURE `ConsultarClientes`()
BEGIN
	SELECT * FROM clientes;
END$$

delimiter $$
CREATE PROCEDURE `CambiarEstadoCliente`(_id INT, _nuevo_estado TINYINT)
BEGIN
	UPDATE clientes SET estado = _nuevo_estado WHERE id = _id;
END$$

delimiter $$
create procedure RegistrarCliente ( in _identificacion varchar(10), in _nombres varchar(30), in _apellidos varchar(30), in _telefono varchar(15), in
_direccion varchar(50), in _salario double, in _estado tinyint, in _fechaCreacion datetime ) 
 begin 
 insert into clientes(identificacion,nombre,apellidos, telefono, direccion, salario, estado, fechaCreacion) values (_identificacion,_nombres,_apellidos,_telefono,_direccion,_salario,_estado,_fechaCreacion); 
end$$

delimiter $$
CREATE PROCEDURE `ActualizarCliente`(in _id int, in _identificacion varchar(10), in _nombres varchar(30), in _apellidos varchar(30), in _telefono varchar(15), in _direccion varchar(50), in _salario double, in _estado tinyint, in _fechaCreacion datetime )
BEGIN
UPDATE clientes SET
identificacion = _identificacion,
nombre = _nombres,
apellidos = _apellidos,
telefono = _telefono,
direccion =  _direccion,
salario= _salario,
estado = _estado,
fechaCreacion = _fechaCreacion
WHERE id = _id;
END$$