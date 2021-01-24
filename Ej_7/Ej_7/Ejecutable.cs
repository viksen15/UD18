using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_7
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
            sql = "CREATE DATABASE Los_Cientificos";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Los_Cientificos";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE CIENTIFICOS
                    ( DNI VARCHAR(8) PRIMARY KEY,
                      NomApels VARCHAR(255) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE PROYECTO
                    ( Id CHAR(4) PRIMARY KEY,
                      Nombre VARCHAR(255),
                      Horas INT)";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE ASIGNADO_A
                    ( Cientifico VARCHAR(8) FOREIGN KEY REFERENCES CIENTIFICOS(DNI),
                      Proyecto CHAR(4) FOREIGN KEY REFERENCES PROYECTO(Id),
                      CONSTRAINT PK PRIMARY KEY (Cientifico, Proyecto) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO CIENTIFICOS VALUES
                    ('2345678B', 'Cristian Bal'),
                    ('3456789C', 'Hugo Marin'),
                    ('6789012F', 'Martina Bermudez'),
                    ('7890123G', 'Antonio Ruiz'),
                    ('8901234H', 'Marc Santos')";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO PROYECTO VALUES
                    ('A1','Proyecto 1','20'),
                    ('B2','Proyecto 2','35'),
                    ('C3','Proyecto 3','40'),
                    ('D4','Proyecto 4','55'),
                    ('E5','Proyecto 5','60')";            
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO ASIGNADO_A VALUES
                    ('2345678B', 'D4'),
                    ('3456789C', 'E5'),
                    ('7890123G', 'A1'),
                    ('6789012F', 'C3'),
                    ('8901234H', 'B2')";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS
            Console.WriteLine("CIENTIFICOS");
            sql = "SELECT * FROM CIENTIFICOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("PROYECTO");
            sql = "SELECT * FROM PROYECTO";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("ASIGNADO_A");
            sql = "SELECT * FROM ASIGNADO_A";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DE LOS CIENTIFICOS Y LAS HORAS DE CADA PROYECTO
            Console.WriteLine("NOMBRE CIENTIFICOS Y HORAS DE PROYECTO");
            sql = "SELECT NomApels, PROYECTO.Horas FROM CIENTIFICOS LEFT JOIN (ASIGNADO_A JOIN PROYECTO ON ASIGNADO_A.Proyecto = PROYECTO.Id) ON CIENTIFICOS.DNI = ASIGNADO_A.Cientifico";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS LOS PROYECTOS DE MAS DE 35 HORAS Y SU NOMBRE
            Console.WriteLine("PROYECTOS > 35 HORAS");
            sql = "SELECT Nombre, Horas FROM PROYECTO WHERE HORAS>35";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN NUEVO PROYECTO
            Console.WriteLine("NUEVO PROYECTO");
            sql = @"INSERT INTO PROYECTO VALUES 
                ('F6', 'Proyecto 6', 15)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT TOP 1 * FROM PROYECTO ORDER BY Id DESC";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
