using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_6
{
    class Ejecutable
    {
        public void ejecuta()
        {
            string sql;
            Metodos ejecutable = new Metodos();
            //  CONECTAMOS AL SERVIDOR Y A LA BASE DE DATOS MASTER
            ejecutable.Conexion("192.168.0.38", "Master");
            Console.WriteLine("");

            //  CREAMOS LA BASE DE DATOS 
            sql = "CREATE DATABASE Piezas_y_Proveedores";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Piezas_y_Proveedores";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE PIEZAS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      Nombre VARCHAR(100) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE PROVEEDORES
                    ( Id CHAR(4) PRIMARY KEY,
                    Nombre VARCHAR(100) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE SUMINISTRA
                    ( CodigoPieza INT FOREIGN KEY REFERENCES PIEZAS(Codigo),
                    IdProveedor CHAR(4) FOREIGN KEY REFERENCES PROVEEDORES(Id),
                    Precio INT,
                    CONSTRAINT PK PRIMARY KEY (CodigoPieza, IdProveedor) )";
            ejecutable.Ejecutar(sql);


            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO PIEZAS VALUES
                    ('Ventana'),
                    ('Muelle'),
                    ('Suspension'),
                    ('Llanta'),
                    ('Puerta') ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO PROVEEDORES VALUES
                    ('1A', 'Ventanas'),
                    ('2B', 'Llantas'),
                    ('3C', 'Muelles'),
                    ('4E', 'Puertas'),
                    ('5F', 'Suspensiones')";

            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO SUMINISTRA VALUES
                    (2, '3C', 280),
                    (4, '2B', 450),
                    (5, '4E', 80),
                    (1, '1A', 70),
                    (3, '5F', 320) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS
            Console.WriteLine("PIEZAS");
            sql = "SELECT * FROM PIEZAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("PROVEEDORES");
            sql = "SELECT * FROM PROVEEDORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("SUMINISTRA");
            sql = "SELECT * FROM SUMINISTRA";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DE LOS PROVEEDORES Y LAS PIEZAS
            Console.WriteLine("NOMBRE DE LOS PROVEEDORES");
            sql = "SELECT Nombre FROM PROVEEDORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("NOMBRE DE LAS PIEZAS");
            sql = "SELECT Nombre FROM PIEZAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL PRECIO DE LAS PIEZAS, SU CODIGO Y EL NOMBRE DEL PROVEEDOR
            Console.WriteLine("CODIGO PIEZA, PRECIO Y NOMBRE PROVEEDOR");
            sql = "SELECT CodigoPieza, Precio, PROVEEDORES.Nombre FROM SUMINISTRA JOIN PROVEEDORES ON SUMINISTRA.IdProveedor = PROVEEDORES.Id";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN NUEVO PROVEEDOR Y PIEZA RELACIONADA CON EL
            sql = @"INSERT INTO PROVEEDORES VALUES 
                ('6H', 'Centralitas')";
            ejecutable.Ejecutar(sql);
            sql = @"INSERT INTO PIEZAS VALUES
                ('Centralita')";
            ejecutable.Ejecutar(sql);
            sql = @"INSERT INTO SUMINISTRA VALUES
                (6, '6H', 335)";
            ejecutable.Ejecutar(sql);
            Console.WriteLine("NUEVO PROVEEDOR");
            sql = "SELECT TOP 1 * FROM PROVEEDORES ORDER BY Id DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("NUEVA PIEZA");
            sql = "SELECT TOP 1 * FROM PIEZAS ORDER BY Codigo DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("NUEVA RELACION PIEZA -- PROVEEDOR");
            sql = "SELECT TOP 1 * FROM SUMINISTRA ORDER BY CodigoPieza DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
