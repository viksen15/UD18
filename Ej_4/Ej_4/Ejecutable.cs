using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_4
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
            sql = "CREATE DATABASE Peliculas_Y_Salas";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Peliculas_Y_Salas";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE PELICULAS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      Nombre VARCHAR(100),
                      CalificacionEdad INT )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE SALAS
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                    Nombre VARCHAR(100),
                    Pelicula INT FOREIGN KEY REFERENCES PELICULAS(Codigo) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO PELICULAS VALUES
                    ('The Wizard Of Oz', 0),
                    ('The Last Tango in Paris', 18),
                    ('Some Like it Hot', 13),
                    ('Citizen King', 7),
                    ('The Quiet Man', NULL) ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO SALAS VALUES
                    ('Paraiso', 1),
                    ('Nickelodeon', 4),
                    ('Royale', 2),
                    ('Imperial', 5),
                    ('Odeon', 3) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS DE LAS TABLAS
            Console.WriteLine("PELICULAS");
            sql = "SELECT * FROM PELICULAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("SALAS");
            sql = "SELECT * FROM SALAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DE LAS PELICULAS
            Console.WriteLine("NOMBRE DE LAS PELICULAS");
            sql = "SELECT Nombre FROM PELICULAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");
            //  MOSTRAMOS EL NOMBRE DE LAS SALAS
            Console.WriteLine("NOMBRE DE LAS SALAS");
            sql = "SELECT Nombre FROM SALAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  ELIMINAMOS LAS SALAS QUE REPRODUZCAN PELICULAS SIN CALIFICACION DE EDAD Y MOSTRAMOS LAS QUE QUEDAN 
            Console.WriteLine("SALAS CON PELICULAS QUE TIENEN CALIFICACION DE EDAD");
            sql = "DELETE FROM SALAS WHERE Pelicula IN (SELECT Codigo FROM PELICULAS WHERE CalificacionEdad IS NULL)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT * FROM SALAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
