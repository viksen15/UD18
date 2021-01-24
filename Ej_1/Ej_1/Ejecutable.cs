using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_1
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
            sql = "CREATE DATABASE La_tienda_de_informatica";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE La_tienda_de_informatica";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE FABRICANTES
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                  Nombre VARCHAR(100) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE ARTICULOS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                    Nombre VARCHAR(100),
                    Precio INT,
                    Fabricante INT FOREIGN KEY REFERENCES FABRICANTES(Codigo) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO FABRICANTES VALUES
                    ('Ruedas'),
                    ('Suspensiones'),
                    ('Puertas'),
                    ('Parachoques'),
                    ('Motores') ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO ARTICULOS VALUES
                    ('Suspensiones KW', 600, 2),
                    ('Parachoques BadBoy', 320, 4),
                    ('Ruedas SemiSlick', 305, 1),
                    ('Motor St2 + Launch', 640, 5),
                    ('Puerta de serie', 60, 3) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS DE LAS TABLAS
            Console.WriteLine("FABRICANTES");
            sql = "SELECT * FROM FABRICANTES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("ARTICULOS");
            sql = "SELECT * FROM ARTICULOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS SOLO LOS NOMBRES DE LAS TABLAS
            Console.WriteLine("NOMBRE DE LOS FABRICANTES");
            sql = "SELECT NOMBRE FROM FABRICANTES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("NOMBRE DE LOS ARTICULOS");
            sql = "SELECT NOMBRE FROM ARTICULOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  REDUCIMOS UN 20% A TODOS LOS ARTICULOS Y MOSTRAMOS SU NOMBRE
            Console.WriteLine("ARTICULOS CON DESCUENTO");
            sql = "SELECT NOMBRE, PRECIO*0.8 AS PRECIO FROM ARTICULOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  BORRAMOS LOS ARTICULOS CON PRECIO SUPERIOR A 500
            Console.WriteLine("ELIMINAMOS ARTICULOS CON PRECIO > 500");
            sql = "DELETE FROM ARTICULOS WHERE PRECIO>500";
            ejecutable.Ejecutar(sql);
            //  MOSTRAMOS LOS ARTICULOS QUE QUEDAN
            sql = "SELECT * FROM ARTICULOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
