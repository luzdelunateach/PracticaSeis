using System;
namespace Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }

        public Provider()
        {

        }
        public Provider(string name, string address, string phoneNumber, string emailAddress, string city)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            City = city;
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
