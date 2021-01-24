using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_9
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
            sql = "CREATE DATABASE Los_Investigadores";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Los_Investigadores";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE FACULTAD
                    ( Codigo INT PRIMARY KEY,
                      Nombre VARCHAR(100))";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE INVESTIGADORES
                    ( DNI VARCHAR(8) PRIMARY KEY,
                      NomApels VARCHAR(255), 
                      Facultad INT FOREIGN KEY REFERENCES FACULTAD(Codigo) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE EQUIPOS
                    ( NumSerie CHAR(4) PRIMARY KEY,
                      Nombre VARCHAR(100),
                      Facultad INT FOREIGN KEY REFERENCES FACULTAD(Codigo) )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE RESERVA
                    ( DNI VARCHAR(8) FOREIGN KEY REFERENCES INVESTIGADORES(DNI),
                      NumSerie CHAR(4) FOREIGN KEY REFERENCES EQUIPOS(NumSerie),
                      Comienzo DATETIME,
                      Fin DATETIME,
                      CONSTRAINT PK PRIMARY KEY(DNI, NumSerie) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO FACULTAD VALUES
                    (1, 'Derecho'),
                    (2, 'Medicina'),
                    (3, 'Ciencias'),
                    (4, 'Psicologia'),
                    (5, 'Filosofia')";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO INVESTIGADORES VALUES
                    ('6789012F', 'Martina Bermudez', 5),
                    ('7890123G', 'Antonio Ruiz', 4),
                    ('8901234H', 'Marc Santos', 3),
                    ('9012345I', 'Maria Ramirez', 2),
                    ('0123456J', 'Mateo Sanchez', 1)";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO EQUIPOS VALUES
                    ('A1', 'Equipo 1', 5),
                    ('B2', 'Equipo 2', 4),
                    ('C3', 'Equipo 3', 2),
                    ('D4', 'Equipo 4', 3),
                    ('E5', 'Equipo 5', 1)";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO RESERVA VALUES
                    ('8901234H', 'C3', '03/08/2011', '31/08/2012'),
                    ('0123456J', 'A1', '30/10/2012', '20/02/2013'),
                    ('9012345I', 'B2', '18/01/2008', '20/09/2008'),
                    ('6789012F', 'D4', '13/05/2010', '16/02/2011'),
                    ('7890123G', 'E5', '24/02/2008', '15/12/2008')";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS
            Console.WriteLine("FACULTAD");
            sql = "SELECT * FROM FACULTAD";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("INVESTIGADORES");
            sql = "SELECT * FROM INVESTIGADORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("EQUIPOS");
            sql = "SELECT * FROM EQUIPOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("RESERVA");
            sql = "SELECT * FROM RESERVA";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL NOMBRE DE LOS INVESTIGADORES Y LA FECHA DE LAS RESERVAS
            Console.WriteLine("NOMBRE INVESTIGADOR Y FECHA RESERVA");
            sql = "SELECT NomApels, RESERVA.Comienzo, RESERVA.Fin FROM INVESTIGADORES JOIN RESERVA ON INVESTIGADORES.DNI = RESERVA.DNI";
            ejecutable.Lectura(sql);
            Console.WriteLine("");
            
            //  MOSTRAMOS EL INVETIGADOR Y EL NOMBRE DE SU EQUIPO
            Console.WriteLine("NOMBRE INVESTIGADOR Y NOMBRE DE EQUIPO");
            sql = "SELECT NomApels, EQUIPOS.Nombre FROM INVESTIGADORES JOIN (EQUIPOS JOIN RESERVA ON RESERVA.NumSerie = EQUIPOS.NumSerie) ON INVESTIGADORES.DNI = RESERVA.DNI";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  AÑADIMOS UN NUEVO INVESTIGADOR
            Console.WriteLine("INVESTIGADOR NUEVO");
            sql = @"INSERT INTO INVESTIGADORES VALUES 
                ('2447568I', 'Sandra Bullock', 3)";
            ejecutable.Ejecutar(sql);
            sql = "SELECT * FROM INVESTIGADORES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }
    }
}
