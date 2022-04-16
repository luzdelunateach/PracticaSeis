using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDos
{
    class Program
    {
        private static List<Student> students = new List<Student>{
        new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
        new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
        new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
        new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
        new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
        new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
        new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
        new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
        new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
        new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
        new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
        new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
    };
        static void Main(string[] args)
        {
            //LISTADO DE ENTIDADES
            //Console.WriteLine("Hello World!");
            int[] scores = { 94, 73, 95, 67, 45 };
            //usando linq to objects in query's format
            IEnumerable<int> scoreQuery = from score in scores
                                          where score > 70
                                          select score * score;
            //linq con exprecion lambada - con metodo de extensión y expresiones lambda
            var scoreQueryLambda = scores.Where(score => score > 70).Select(score => score*score);
            /*foreach (var i in scoreQuery)
            {
                Console.WriteLine(i + "");
            }*/
            // TODO: comparar cada calificacion que sea mayor a 80
            var studentQuery =
                from student in students
                    //where student.Scores.Average() > 80
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;
            //No es necesario regresar un select si retorna el mismo tipo de objeto
            var studentQueryLambda = students.Where(student => student.Scores[0] > 90 && student.Scores[3] < 80).OrderByDescending(student => student.Scores[0]);
            var studentQueryLambda2 = students.Where(student => student.Scores.All(score => score >80)).OrderByDescending(student => student.Scores[0]); //All regresara solo si la condicion se cumple
            //para todos los de la lista y para el caso de where
            //var studentQueryLambda2 = students.Where(student => student.Scores.Any(score => score >80)).OrderByDescending(student => student.Scores[0]); 
            //sOLO SI LA CONDICION SE CUMPLE EN UNO CON EL ANY


            foreach (var student in studentQuery)
            {
                Console.WriteLine(student.LastName + " " + student.FirstName +" "+student.Scores[0]);
            }

            //Comparar cada calificacion que sea m

            //meter a los estudiantes en una sola agrupacion por la letra de su nombre
            //tambien se pueden agrupar los elemetnos del listado utilizando el group by
            var studentQuery2 = 
                from student in students
                group student by student.LastName[0]
                into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            var studentQuery2Lambda = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            foreach(var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach(var student in studentGroup)
                {
                    //usaremos la interpolacion de strings
                    Console.WriteLine($"nombre: {student.LastName} apellido: {student.FirstName}");
                    //sin interpolacion de strings
                    //Console.WriteLine("nombre: "+student.LastName+ "apellido: "+ student.FirstName);
                }
            }

            // se puede utilizar linq para realizar operaciones dentro de la comparacion y además regresar el valor
            // deseado ya formateado

            IEnumerable<string> studentQuery3 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select $"{student.FirstName}{student.LastName}";

            var studentLambda3 = students
                .Where(student => (student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]) / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName}{student.LastName}");

            foreach (var student in studentQuery3)
            {
                Console.WriteLine(student);
            }

            IEnumerable<string> studentQuery4 = from student in students
                                                let totalS = student.Scores.Sum()
                                                where totalS / 4 < student.Scores[0]
                                                select $"{student.FirstName}{student.LastName}";

            var studentLambda4 = students
                .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName}{student.LastName}");

            IEnumerable<string> studentQuery5 = from student in students
                                                let totalS = student.Scores.Average()
                                                where totalS / 4 < student.Scores[0]
                                                select $"{student.FirstName}{student.LastName}";

            var studentLambda5 = students
                .Where(student => student.Scores.Average() < student.Scores[0])
                .Select(student => $"{student.FirstName}{student.LastName}");

            //promedio general de toda la clase
            var promedio = students.Average(student => student.Scores.Average());
            //tammiben se pueden hacaer consultas linq con variables externas a ellas
            var lastName = "Garcia";
            var studentQuery6 = from student in students
                                where student.LastName.Equals(lastName)
                                select student.FirstName;

            Console.WriteLine("Todos los Garcia de las clases son: ");
            Console.WriteLine(string.Join(", ", studentQuery6)); //se puede utilizar en los demás suplanda al foreach

            var studentLambda6 = students
                .Where(Student => Student.LastName.Equals(lastName))
                .Select(Student => Student.FirstName);

            //podemos crear también, nuevos objetos a partir de nuestra consulta
            var studentQuery7 = from student in students
                                let totalScore = student.Scores.Sum()
                                where totalScore > promedio
                                select new { ID = student.ID, Scores = totalScore };

            var studentQuery7Lambda = students
                .Where(student => student.Scores.Sum() > promedio)
                .Select(student => new
                {
                    Id = student.ID,
                    Score = student.Scores.Sum()
                });

            var primerEstudianteFiltrado = studentQuery7Lambda.First(); //va a traer una exepcion si no tiene datos
            var ultimoEstudianteFiltrado = studentQuery7Lambda.Last();
            var porDefectoEstudianteFiltrado = studentQuery7Lambda.FirstOrDefault();

            //Student primerEstudianteFiltrado = studentQuery7LambdaX.Where(c=> c.IsDigit > 1000).First();
            Student primerEstudianteFiltradoSinResultado = studentQueryLambdaX.Where(c => c.IsDigit > 1000).FirstOrDefault();
            Console.WriteLine(primerEstudianteFiltroradoSinResultados == null ? "es nulo" : primerEstudianteFiltradoSinResultado.FirstName);

            Student primerEstudianteFiltradoSinResultadosReducido = studentQuery7Lambda.FirstOrDefault(c => c.Id > 1000);

            Student single = studentQueryLambdaX
                .SingleOrDefault(c=> c.ID == 101);

            foreach (var item in studentQuery7)
            {
                Console.WriteLine($"student id:{item.ID} Score:{item.Scores}");
            }
 

        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
