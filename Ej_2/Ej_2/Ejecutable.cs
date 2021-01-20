using System;
using System.Collections.Generic;
using System.Text;

namespace Ej_2
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
            sql = "CREATE DATABASE Empleados";
            ejecutable.Ejecutar(sql);

            //  ENTRAMOS EN LA BASE DE DATOS
            sql = "USE Empleados";
            ejecutable.Ejecutar(sql);

            //  CREAMOS LAS TABLAS Y SUS ATRIBUTOS
            sql = @"CREATE TABLE DEPARTAMENTOS
                    ( Codigo INT PRIMARY KEY,
                      Nombre VARCHAR(100),
                      Presupuesto INT )";
            ejecutable.Ejecutar(sql);

            sql = @"CREATE TABLE EMPLEADOS
                    ( DNI VARCHAR(8) PRIMARY KEY,
                    Nombre VARCHAR(100),
                    Apellidos VARCHAR(255),
                    Departamento INT FOREIGN KEY REFERENCES DEPARTAMENTOS(Codigo) )";
            ejecutable.Ejecutar(sql);

            //  INSERTAMOS LOS DATOS EN LOS ATRIBUTOS DE LAS TABLAS
            sql = @"INSERT INTO DEPARTAMENTOS VALUES
                    (1, 'D. Financiero', 45000),
                    (2, 'D. Recursos Humanos', 25000),
                    (3, 'D. Marketing', 30000),
                    (4, 'D. Logistica', 60000),
                    (5, 'D. Comercial', 38000) ";
            ejecutable.Ejecutar(sql);

            sql = @"INSERT INTO EMPLEADOS VALUES
                    ('1234567A', 'Jesus', 'Sanchez', 2),
                    ('2345678B', 'Joana', 'Santos', 4),
                    ('3456789C', 'Ana', 'Bermudez', 1),
                    ('4567890D', 'Cristian', 'Martinez', 5),
                    ('5678901E', 'Claudia', 'Ruiz', 3) ";
            ejecutable.Ejecutar(sql);

            //  MOSTRAMOS POR PANTALLA TODOS LOS DATOS DE LAS TABLAS
            Console.WriteLine("DEPARTAMENTOS");
            sql = "SELECT * FROM DEPARTAMENTOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("EMPLEADOS");
            sql = "SELECT * FROM EMPLEADOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  MOSTRAMOS SOLO LOS NOMBRES DE LAS TABLAS
            Console.WriteLine("NOMBRE DE LOS DEPARTAMENTOS");
            sql = "SELECT Nombre FROM DEPARTAMENTOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            Console.WriteLine("NOMBRE DE LOS EMPLEADOS");
            sql = "SELECT Nombre FROM EMPLEADOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  REDUCIMOS UN 20% A TODOS LOS PRESUPUESTOS Y MOSTRAMOS SU NOMBRE
            Console.WriteLine("REDUCCION DE PRESUPUESTO");
            sql = "SELECT Nombre, Presupuesto*0.8 AS Presupuesto FROM DEPARTAMENTOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            //  BORRAMOS LOS EMPLEADOS QUE TRABAJAN EN DEPARTAMENTOS CON PRESUPUESTO INFERIOR A 35000
            Console.WriteLine("ELIMINAMOS TRABAJADORES EN DEPARTAMENTOS CON PRESUPUESTO < 35000");
            sql = "DELETE EMPLEADOS WHERE Departamento IN (SELECT Codigo FROM DEPARTAMENTOS WHERE Presupuesto < 35000)";
            ejecutable.Ejecutar(sql);
            //  MOSTRAMOS LOS DEPARTAMENTOS QUE QUEDAN
            sql = "SELECT * FROM EMPLEADOS";
            ejecutable.Lectura(sql);
            Console.WriteLine("");

            ejecutable.Desconexion();
        }

    }

}
