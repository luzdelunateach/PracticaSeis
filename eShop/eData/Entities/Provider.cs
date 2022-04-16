using System;
namespace Data.Entities
{
    public class Provider
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string City { get; private set; }

        public Provider(int id, string name, string emailAddress)
        {
            if (id <= 0)
                throw new ArgumentException("El ID tiene que ser mayor a 0");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacío");

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException("El email no puede ser vacío");

            try
            {
                var email = new System.Net.Mail.MailAddress(emailAddress);
                EmailAddress = emailAddress;
            }
            catch (FormatException)
            {
                throw new ArgumentNullException("El correo no es válido");
            }

            Id = id;
            Name = name;
        }

        public void AddAddress(string address, string city)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("La dirección no puede ser vacía");

            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException("La ciudad no puede ser vacía");

            Address = address;
            City = city;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException("El número no puede ser vacío");

            if (phoneNumber.Length < 10)
                throw new ArgumentNullException("El número no puede ser menor de 10 dígitos");

            PhoneNumber = phoneNumber;
        }
    }

}
