using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_3
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
            sql = "CREATE DATABASE Los_Almacenes";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Los_Almacenes";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE ALMACENES
                    ( Codigo INT IDENTITY (1,1) PRIMARY KEY,
                      Lugar VARCHAR(100),
                      Capacidad INT )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE CAJAS
                    ( NumReferencia CHAR(5) PRIMARY KEY,
                    Contenido VARCHAR(100),
                    Valor INT,
                    Almacen INT FOREIGN KEY REFERENCES ALMACENES(Codigo) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO ALMACENES VALUES
                    ('Barcelona', 45),
                    ('Madrid', 25),
                    ('Mallorca', 30),
                    ('Tarragona', 60),
                    ('Lleida', 38) ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO CAJAS VALUES
                    ('123A', 'Ruedas', 15, 2),
                    ('678B', 'Suspensiones',40 , 4),
                    ('349C', 'Faros', 80, 1),
                    ('4560D', 'Volantes', 40, 5),
                    ('589E', 'Asientos', 50, 3) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS DE LAS TABLAS
            Console.WriteLine("ALMACENES");
            sql = "SELECT * FROM ALMACENES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("CAJAS");
            sql = "SELECT * FROM CAJAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS EL LUGAR DE LOS ALMACENES
            Console.WriteLine("LUGAR DE LOS ALMACENES");
            sql = "SELECT Lugar FROM ALMACENES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");
            //  MOSTRAMOS EL CONTENIDO DE LAS CAJAS
            Console.WriteLine("CONTENIDO DE LAS CAJAS");
            sql = "SELECT Contenido FROM CAJAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  REDUCIMOS UN 20% LA CAPACIDAD DE LOS ALMACENES Y MOSTRAMOS SU CODIGO
            Console.WriteLine("REDUCCION DE CAPACIDAD");
            sql = "SELECT Codigo, Capacidad*0.8 AS Capacidad FROM ALMACENES";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  BORRAMOS LAS CAJAS CON UN VALOR SUPERIOR A 45
            Console.WriteLine("ELIMINAMOS CAJAS CON VALOR > 45");
            sql = "DELETE CAJAS WHERE Valor> 45";
            ejecutable.Ejecutar(sql);
            //  MOSTRAMOS LAS CAJAS QUE QUEDAN
            sql = "SELECT * FROM CAJAS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }
}
