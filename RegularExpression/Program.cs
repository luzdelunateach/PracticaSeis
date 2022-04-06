using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainValidation();
            phoneNumber();
            PasswordValidator();
            static void DomainValidation()
            {
                var domain = "https://www.something.com"; //El más es por que forzosamente tiene que existir esa parte
                Regex regex = new Regex(@"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$"); //Filtros de busqueda Recibe - Afecta al elemento que lo precede solo a la s
                Console.WriteLine(regex.IsMatch(domain));
            }

            static void phoneNumber()
            {
                var phoneNumber = "+52 (715) 118 1098";
                Regex regex = new Regex(@"[\+][\d]{2}\s[\(][\d]{3}[\)]\s[\d]{3}\s[\d]{4}$");
                Console.WriteLine(regex.IsMatch(phoneNumber));
            }

            static void PasswordValidator()
            {
                //Debe de contener como minimo 8 caracteres
                //Al menos una mayuscula
                //Al menos una minuscula
                //Al menos un numero
                //Al menos un caracter especial * @ ? !
                //No debe tener espacios
                //var password = "Abcd1234#";
                var password = ".arpmor";
                Regex regex = new Regex(@"^(?=\S*[a-zA-Z])+(?=\S\d*)+(?=\S*[\#\*\!\$\@\?\.]).{8,}$"); //?= Define la subexpreccion \S le quita los espacios
                Console.WriteLine(regex.IsMatch(password));

            }
    
        }
    }
}
