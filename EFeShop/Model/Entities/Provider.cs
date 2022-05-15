using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
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
        public Provider(string name, string address, string phoneNumber, string emailAdress, string city)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAdress;
            City = city;
        }
    }
}
