namespace Practica_14_02_2024.Models
{
    public class OrdenCompra
    {
        idOrdenCompra int auto_increment primary key,
        consecutivo varchar(200),
proyecto varchar(200),
status int default 1,
no_consecutivo int,
referencia varchar(200),
fecha date,
empresa varchar(200),
vendedor varchar(200),
direccion varchar(200),
subtotal real,
iva real,
total real,
moneda varchar(20),
condicionPago varchar(200),
entrega varchar(200),
tiempoEntrega varchar(200),
activo bool default true,
idCompradorFK int,
foreign key(idCompradorFK) references Comprador(idcomprador) on delete cascade
    }
}
