using System.Text.RegularExpressions;

class Program
{
    static List<string> estudiantes = new List<string>(); //listas para almacenar los nombres de los estudiantes.
    static List<double> calificaciones = new List<double>(); //listas para almacenar las calificaciones de los estudiantes.

    static void Main()
    {

        Console.WriteLine("Bienvenido al Sistema de Gestión de Estudiantes.");

        int opcion; //variable para el switch de opciones

        do
        { //ciclo para mostrar el menú de opciones, hecho con do while para que se ejecute al menos una vez
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Mostrar lista de estudiantes");
            Console.WriteLine("3. Calcular promedio de calificaciones");
            Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            { //switch para seleccionar la opción deseada
                case 1: addEstudiante(); break; //llama la función "addEstudiante" que es la que agrega un estudiante.
                case 2: listEstudiante(); break; //llama la función "listEstudiante" que es la que muestra la lista de estudiantes.
                case 3: promCalificacion(); break; //llama la función "promCalificacion" que es la que calcula el promedio de calificaciones.
                case 4: caliEstudiante(); break; //llama la función "CaliAlt" que es la que muestra el estudiante con la calificación más alta.
                case 5: Console.WriteLine("¡Hasta luego! Saliendo del sistema... "); break;
                default: Console.WriteLine("Opción no válida. Intente de nuevo."); break;
            }
        } while (opcion != 5);
    }

    static void addEstudiante()
    {
        string nombre;
        do
        {
            Console.Write("Ingrese el nombre del estudiante (solo letras): ");
            nombre = Console.ReadLine();

            if (!Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Error: El nombre solo puede contener letras y espacios.");
            }

        } while (!Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"));

        double calificacion;
        while (true)
        {
            Console.Write("Ingrese la calificación del estudiante (0 - 100): ");
            if (double.TryParse(Console.ReadLine(), out calificacion) && calificacion >= 0 && calificacion <= 100)
            {
                break;
            }
            Console.WriteLine("Error: Ingrese una calificación válida entre 0 y 100.");
        }

        estudiantes.Add(nombre);
        calificaciones.Add(calificacion);
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    static void listEstudiante()
    { //función para mostrar la lista de estudiantes
        if (estudiantes.Count == 0)
        { //con el "if" podemos determinar si por lo menos hay algun estudiante en el listado.
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        { //si hay estudiantes, se muestra la lista
            Console.WriteLine("\nLista de estudiantes:");
            for (int i = 0; i < estudiantes.Count; i++)
            { //ciclo para recorrer la lista de estudiantes
                Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
            }
        }
    }

    static void promCalificacion()
    { //funcion para calcular el promedio de calificaciones
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }
            double promedio = suma / calificaciones.Count; //calcula el promedio de las calificaciones registradas y ese valor lo almacena en promedio.
            Console.WriteLine($"El promedio de calificaciones es: {promedio}");
        }
    }

    static void caliEstudiante()
    { //funcion para mostrar el estudiante con la calificación más alta

        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        { //Busca la calificación más alta en la lista, guarda la calificación y el nombre del estudiante.
            double maxCalificacion = calificaciones[0];
            string estudianteMax = estudiantes[0];
            for (int i = 1; i < calificaciones.Count; i++)
            {
                if (calificaciones[i] > maxCalificacion)
                {
                    maxCalificacion = calificaciones[i];
                    estudianteMax = estudiantes[i];
                }
            }
            Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
        }
    }
}
