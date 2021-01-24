using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_5
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
            sql = "CREATE DATABASE Los_Directores";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Los_Directores";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE DESPACHOS
                    ( Numero INT PRIMARY KEY,
                      Capacidad INT )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE DIRECTORES
                    ( DNI VARCHAR(8) PRIMARY KEY,
                    NombreApels VARCHAR(255),
                    DNIJefe VARCHAR(8) FOREIGN KEY REFERENCES DIRECTORES(DNI),
                    Despacho INT FOREIGN KEY REFERENCES DESPACHOS(Numero) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO DESPACHOS VALUES
                    (1,15),
                    (2,14),
                    (3,17),
                    (4,13),
                    (5,12) ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO DIRECTORES VALUES
                    ('0123456J', 'Mateo Sanchez', NULL, 1),
                    ('5678901E', 'Sofia Ramos', NULL, 3),
                    ('3456789C', 'Hugo Marin', '5678901E', 4),
                    ('7890123G', 'Marc Santos', NULL, 2),
                    ('8901234H', 'Antonio Ruiz', '7890123G', 5) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS
            Console.WriteLine("DESPACHOS");
            sql = "SELECT * FROM DESPACHOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("DIRECTORES");
            sql = "SELECT * FROM DIRECTORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DE LOS DIRECTORES
            Console.WriteLine("NOMBRE DE LOS DIRECTORES");
            sql = "SELECT NombreApels FROM DIRECTORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS LOS DIRECTORES QUE NO TIENEN JEFE
            Console.WriteLine("DIRECTORES SIN JEFE");
            sql = "SELECT * FROM DIRECTORES WHERE DNIJefe IS NULL";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN NUEVO DIRECOR AL DESPACHO 2
            Console.WriteLine("NUEVO DIRECTOR");
            sql = @"INSERT INTO DIRECTORES VALUES 
                ('4567890A', 'Fran Bermudez', '0123456J', 2)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT * FROM DIRECTORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  DESPEDIMOS A TODOS LOS DIRECTORES QUE TIENEN JEFE
            Console.WriteLine("DIRECTORES RESTANTES");
            sql = "DELETE FROM DIRECTORES WHERE DNIJefe IS NOT NULL";
            ejecutable.Ejecutar(sql);
            sql = "SELECT * FROM DIRECTORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
