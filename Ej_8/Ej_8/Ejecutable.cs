using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_8
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
            sql = "CREATE DATABASE Los_Grandes_Almacenes";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Los_Grandes_Almacenes";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE CAJEROS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      NomApels VARCHAR(255))";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE PRODUCTOS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      Nombre VARCHAR(100),
                      Precio INT)";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE MAQUINAS_REGISTRADORAS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      Piso INT)";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE VENTA
                    ( Cajero INT FOREIGN KEY REFERENCES CAJEROS(Codigo),
                      Maquina INT FOREIGN KEY REFERENCES MAQUINAS_REGISTRADORAS(Codigo),
                      Producto INT FOREIGN KEY REFERENCES PRODUCTOS(Codigo),
                      CONSTRAINT PK PRIMARY KEY (Cajero, Maquina, Producto) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO CAJEROS VALUES
                    ('Pablo Martinez'),
                    ('Sofia Ramos'),
                    ('Martina Bermudez'),
                    ('Antonio Ruiz'),
                    ('Marc Santos')";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO PRODUCTOS VALUES
                    ('Sofas', 180),
                    ('Sillas', 35),
                    ('Mesas', 80),
                    ('Camas', 90),
                    ('Escritorios', 110)";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO MAQUINAS_REGISTRADORAS VALUES
                    (1),
                    (3),
                    (2),
                    (3),
                    (1)";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO VENTA VALUES
                    (1,2,3),
                    (3,1,2),
                    (2,5,1),
                    (4,3,5),
                    (5,4,4)";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS
            Console.WriteLine("CAJEROS");
            sql = "SELECT * FROM CAJEROS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("PRODUCTOS");
            sql = "SELECT * FROM PRODUCTOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("MAQUINAS_REGISTRADORAS");
            sql = "SELECT * FROM MAQUINAS_REGISTRADORAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("VENTA");
            sql = "SELECT * FROM VENTA";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DEL CAJERO Y EL PRODUCTO QUE VENDE
            Console.WriteLine("NOMBRE CAJERO Y PRODUCTO QUE VENDE");
            sql = "SELECT NomApels, PRODUCTOS.Nombre FROM CAJEROS JOIN (PRODUCTOS JOIN VENTA ON VENTA.Producto = PRODUCTOS.Codigo) ON VENTA.Cajero = CAJEROS.Codigo";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS LAS VENTAS DE CADA PISO
            Console.WriteLine("VENTAS DE CADA PISO");
            sql = "SELECT Piso, SUM(Precio) AS Precio FROM VENTA, PRODUCTOS, MAQUINAS_REGISTRADORAS WHERE VENTA.Producto = PRODUCTOS.Codigo AND VENTA.Maquina = MAQUINAS_REGISTRADORAS.Codigo GROUP BY PISO";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN CAJERO NUEVO
            Console.WriteLine("CAJERO NUEVO");
            sql = @"INSERT INTO CAJEROS VALUES 
                ('Juan José')";
            ejecutable.Ejecutar(sql);
            sql = "SELECT TOP 1 * FROM CAJEROS ORDER BY Codigo DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN PRODUCTO NUEVO
            Console.WriteLine("PRODUCTO NUEVO");
            sql = @"INSERT INTO PRODUCTOS VALUES 
                ('Camaras', 100)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT TOP 1 * FROM PRODUCTOS ORDER BY Codigo DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UNA MAQUINA NUEVA
            Console.WriteLine("MAQUINA REGISTRADORA NUEVA");
            sql = @"INSERT INTO MAQUINAS_REGISTRADORAS VALUES 
                (2)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT TOP 1 * FROM MAQUINAS_REGISTRADORAS ORDER BY Codigo DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  ASOCIAMOS EL CAJERO, EL PRODUCTO Y LA MAQUINA 
            Console.WriteLine("ASOCIACION");
            sql = @"INSERT INTO VENTA VALUES 
                (6,6,6)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT * FROM VENTA";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }
    }
}
