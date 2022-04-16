using System;
using System.Linq;

namespace LinqMethodSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Distinct solo traera un elemento unico en el listado aun si se repiten
            int[] factoriales = { 2, 2, 3, 5, 5 };
            int fatoriasUnicos = factoriales.Distinct().Count();

            Console.WriteLine($"Hoy {factoriales} factoriales unicos");

            //Suma de elementos
            int[] numbers = { 5, 4, 1, 4, 6, 34 };
            double numSum = numbers.Sum();
            Console.WriteLine($"La suma de elementos es: {numSum}");

            //El valor minimo dentro de un listado
            int[] numbers2 = { 5, 4, 1, 4, 6, 34 };
            int minNum = numbers.Min();
            int maxNum = numbers.Max();
            Console.WriteLine($"El numero más chico es: {minNum}");
            Console.WriteLine($"El numero más chico es: {maxNum}");

            //Proyecciones en min y max
            string[] words = { "cherry", "apple", "banana" };
            int shortedWord = words.Min(w => w.Length);
            int longestWord = words.Max(w => w.Length);
            Console.WriteLine($"La palabra más corta es:{shortedWord} character");
            Console.WriteLine($"La palabra más larga tiene:{longestWord} character");

            //promedio en un listado
            double averageNum = numbers.Average();
            Console.WriteLine($"El promedio es: {averageNum}");

            //proyecciones en average
            double averageLength = words.Average(w => w.Length);
            Console.WriteLine($"El promedio de caracter es: {averageLength}");

            //Conversion de listas y Arrays

            double[] doubles = { 1.4, 5.3, 6.4 };
            var sortedDoubles = doubles.OrderBy(d => d);
            var doublesArray = sortedDoubles.ToArray();
           

            for(int i=0;i< doublesArray.Length; i++)
            {
                Console.WriteLine(doublesArray[i]);
            }

            var doublesList = sortedDoubles.ToList();

            foreach (var d in doublesList)
                Console.WriteLine(d);

            //Conversiones a diccionario
            var scoreRecord = new[] {new {Name="Alice", Score=50},
                new {Name="Alice", Score=40},
                new {Name ="Bob", Score = 45},
                new {Name="Cathy", Score=40}
            };

            //El diccionario es una colección de llave y valor
            //var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);

            //Console.WriteLine("Bob's score: {0} ", scoreRecord["Bob"]);

            //Convertir datos obtenidos
            object[] numbersObjects = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d };
            var doubles1 = numbersObjects.OfType<double>();

            foreach(var d in doubles1)
            {
                Console.WriteLine(d);
            }

            var stringObjects = numbersObjects.OfType<string>();
            Console.WriteLine("Numeros guardados como string");
            foreach(var d in stringObjects)
            {
                Console.WriteLine(d);
            }

            string[] strings = { "zero", "one", "two", "three", "four", "five" };
            var theFirstOne = strings.First();
            var theOne = strings.First(c => c == "one");

            Console.WriteLine($"El primer elemento de la lista es: {theFirstOne}");
            Console.WriteLine($"El primer elemento que coincide con 'one' es: {theOne}");

            //talvez exista un elemento de listado
            string[] strings2 = { };
            var maybeTheFirstOne = strings2.FirstOrDefault() ?? "";

            //si el listado no tiene valores se le asignará el valor de 'hola'
            strings2.DefaultIfEmpty("Hola").First();

            //obtener un objeto de la posición en un listado
            int[] numbers3 = { 5, 4, 1, 4, 6, 34 };
            var InPosition = numbers3.ElementAt(2);

            Console.WriteLine("Numero en la posicion 2 es:" + InPosition);

            //ordenamiento de listados
            var sortedStringsAsc = strings.OrderBy(c => c);
            var sortedStringsDesc = strings.OrderByDescending(c => c);
            var sortedMultipledTimes = strings
                .OrderBy(c => c[0])
                .ThenBy(c => c.Length); //cuando van a coincidir multiples elementos
            Console.WriteLine("El orden ascendiente de la lista es:");
            foreach(var s in sortedStringsDesc)
            {
                Console.WriteLine(s);
            }
            //toma la lista y lar ordena alrevés
            var sortedReverse = strings.Reverse();

            //particiones en una lista
            int[] numbers4 = { 5, 4, 1, 8, 6, 4, 9, 0 };
            var first3Numbers = numbers4.Take(3);
            Console.WriteLine("Los primeros 3 numeros");
            foreach (var number in first3Numbers)
            {
                Console.WriteLine(number);
            }

            var takeWhile=numbers4.TakeWhile(c => c > 3);
            Console.WriteLine("Tomará mientras la condicion de que el numero sea mayor a 3 se cumple");
            foreach(var number in takeWhile)
            {
                Console.WriteLine(number);
            }

            var allButFirst4Numbers = numbers4.Skip(4);
            Console.WriteLine("Los elementos después de los primeros 4 son:");
            foreach(var number in allButFirst4Numbers)
            {
                Console.WriteLine(number);
            }

            var skipWhile = numbers4.SkipWhile(c=>c>2);
            Console.WriteLine("Los elementos que fueron brincados cumpliendo mientras se cumplia la condicion de ser mayores a 2 son:");
            foreach (var number in skipWhile)
            {
                Console.WriteLine(number);
            }

            //Proyecciones
            var selectList = strings.Select(c => new { Length = c.Length, Word = c });
            //Creamos un listado a partir de una clase definida
            var selectListWithEntity = strings.Select(c => new MyWord{ Length = c.Length, Word = c });  // suponiendo que exite una clase llamada MyWord con los atributos Lenght y WORD
            foreach (var str in selectListWithEntity)
            {
                Console.WriteLine($"la palabra: {str.Word} tiene {str.Length}");
            }

            //Contains
            //regresa un booleano si la condicion se cumple
            var existeZero = strings.Contains("zero"); //true o false

            //Any se cumple si cualquier elemento es igual a 'three'
            var esIgualATres = strings.Any(c => c.Equals("Three"));

            //Concat
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 4, 5, 6 };
            foreach(var n in nums1.Concat(nums2))
            {
                Console.WriteLine(n);
            }

        }
    }
}
