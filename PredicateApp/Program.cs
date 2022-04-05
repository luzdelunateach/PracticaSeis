using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateApp
{
    class Program
    {
        static void Main(string[] args)
        {

            String dato = "";
            int opcion = 0;
            Console.Write("Bienvenido, selecciona una de las siguientes opciones para buscar: \n 1.Identificacion\n 2.Buscar por Nombre de la Mascota \n 3.Nombre del Adoptante \n 4.Fecha de Nacimiento \n 5.Fecha de Adopcion \n 6. Disponibilidad de Visita \n Opción: ");
            dato = Console.ReadLine();
            opcion = Convert.ToInt32(dato);
            Searcher(opcion);

            static void Searcher(int op)
            {
                //User.Input = dato;
                //Llenado de la base de datos
                Predicate<Mascota> predicateByIdPet = new Predicate<Mascota>(Mascota.GetById);
                Predicate<Mascota> predicateByNamePet = new Predicate<Mascota>(Mascota.GetByNombre);
                Predicate<Mascota> predicateByNameAdopt = new Predicate<Mascota>(Mascota.GetByAdoptante);
                Predicate<Mascota> predicateByDisponibilidad = new Predicate<Mascota>(Mascota.GetByDisponibilidad);
                Predicate<Mascota> predicateByNacimiento = new Predicate<Mascota>(Mascota.GetByDisponibilidad);
                List<Mascota> pet = new List<Mascota>()
                {
                new Mascota() {Id = 1, NombreMascota = "Demi", NombreAdoptante = "Alejandra", FechaNacimiento = new DateTime(2021,1,12), FechaAdopcion = new DateTime(2021,4,4), Disponibilidad = true},
                new Mascota() {Id = 2, NombreMascota = "Nieve", NombreAdoptante = "Ana", FechaNacimiento = new DateTime(2019,4,4), FechaAdopcion = new DateTime(2021,1,12), Disponibilidad = true},
                new Mascota() {Id = 3, NombreMascota = "Bunny", NombreAdoptante = "Paty", FechaNacimiento = new DateTime(2018,12,1), FechaAdopcion = new DateTime(2019,12,12), Disponibilidad = false}
                };
                switch (op)
                {
                    case 1:
                        String dato1 = "";
                        Console.Write("Ingresa el Id de la mascota: ");
                        dato1 = Console.ReadLine();
                        User.Input = dato1;

                        var result = pet.FindAll(predicateByIdPet);
                        if (result.Any()) //determina una lista si tiene elementos - si tiene o no, pero puedo filtrar 
                        {
                            Console.WriteLine("Se encontraron las siguientes mascotas");
                            foreach (var item in result)
                            {
                                Console.WriteLine("Id: {0}, Nombre: {1}, Adoptante: {2}, Fecha de Nacimiento: {3}, Fecha de Adopcion {4}, Disponibiliad de Visita {5}", item.Id, item.NombreMascota, item.NombreAdoptante, item.FechaNacimiento, item.FechaAdopcion, item.Disponibilidad );
                                Console.WriteLine("----------------------------------");
                            }
                        }
                        else
                            Console.WriteLine("NO se encontró la mascota");
                        break;
                    case 2:
                        String dato2 = "";
                        Console.Write("Ingresa el nombre de la mascota: ");
                        dato2 = Console.ReadLine();
                        User.Input = dato2;

                        var result1 = pet.FindAll(predicateByNamePet);
                        if (result1.Any()) //determina una lista si tiene elementos - si tiene o no, pero puedo filtrar 
                        {
                            Console.WriteLine("Se encontraron las siguientes mascotas");
                            foreach (var item in result1)
                            {
                                Console.WriteLine("Id: {0}, Nombre: {1}, Adoptante: {2}, Fecha de Nacimiento: {3}, Fecha de Adopcion {4}, Disponibiliad de Visita {5}", item.Id, item.NombreMascota, item.NombreAdoptante, item.FechaNacimiento, item.FechaAdopcion, item.Disponibilidad);
                                Console.WriteLine("----------------------------------");
                            }
                        }
                        else
                            Console.WriteLine("NO se encontró la mascota");
                        break;
                    case 3:
                        String dato3 = "";
                        Console.Write("Ingresa el nombre del Adoptante: ");
                        dato3 = Console.ReadLine();
                        User.Input = dato3;

                        var result2 = pet.FindAll(predicateByNameAdopt);
                        if (result2.Any()) //determina una lista si tiene elementos - si tiene o no, pero puedo filtrar 
                        {
                            Console.WriteLine("Se encontraron las siguientes mascotas");
                            foreach (var item in result2)
                            {
                                Console.WriteLine("Id: {0}, Nombre: {1}, Adoptante: {2}, Fecha de Nacimiento: {3}, Fecha de Adopcion {4}, Disponibiliad de Visita {5}", item.Id, item.NombreMascota, item.NombreAdoptante, item.FechaNacimiento, item.FechaAdopcion, item.Disponibilidad);
                                Console.WriteLine("----------------------------------");
                            }
                        }
                        else
                            Console.WriteLine("NO se encontró la mascota");
                        break;
                    case 4:

                        break;
                    case 5:
                        break;
                    case 6:
                        String dato6 = "";
                        Console.Write("Ingresa Disponible o No Disponible: ");
                        dato6 = Console.ReadLine();
                        User.Input = dato6;

                        var result6 = pet.FindAll(predicateByDisponibilidad);
                        if (result6.Any()) //determina una lista si tiene elementos - si tiene o no, pero puedo filtrar 
                        {
                            Console.WriteLine("Se encontraron las siguientes mascotas");
                            foreach (var item in result6)
                            {
                                Console.WriteLine("Id: {0}, Nombre: {1}, Adoptante: {2}, Fecha de Nacimiento: {3}, Fecha de Adopcion {4}, Disponibiliad de Visita {5}", item.Id, item.NombreMascota, item.NombreAdoptante, item.FechaNacimiento, item.FechaAdopcion, item.Disponibilidad);
                                Console.WriteLine("----------------------------------");
                            }
                        }
                        else
                            Console.WriteLine("NO se encontró la mascota");
                        break;

                }
            }
        }
    }
    class Mascota
    {
        public int Id { get; set; }
        public string NombreMascota { get; set; }
        public string NombreAdoptante { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public bool Disponibilidad { get; set; }

        public static bool GetById(Mascota pet)
        {
            var verificar = Int32.TryParse(User.Input, out int id); //validar que no haya entrado una palabra
            if (verificar)
                return pet.Id.Equals(id);
            else
                return false;
        }
        public static bool GetByNombre(Mascota pet)
        {
            return pet.NombreMascota.Equals(User.Input);
        }

        public static bool GetByAdoptante(Mascota pet)
        {
            return pet.NombreAdoptante.Equals(User.Input);
        }

        public static bool GetByDisponibilidad(Mascota pet)
        {
            var respuesta = false;
            if (User.Input.Equals("Disponible"))
            {
                respuesta = true;
            }
            return pet.Disponibilidad.Equals(respuesta);
        }
        public static bool GetByNacimiento(Mascota pet)
        {
            DateTime fecha = DateTime.Parse(User.Input);
            if (pet.FechaNacimiento.Equals(fecha))
                return true;
            else
                return false;
        }

    }

    class User
    {
        public static string? Input { get; set; } //Se hizo nuleable
    }
}
