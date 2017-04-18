using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int roomNumber  { get; set; }

        public Customer(int customerId, string firstName, string lastName, string department, string email, string phone, int roomNumber)
        {
            CustomerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
            this.email = email;
            this.phone = phone;
            this.roomNumber = roomNumber;
        }

        public Customer(string firstName, string lastName, string department, string email, string phone, int roomNumber)
        {            
            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
            this.email = email;
            this.phone = phone;
            this.roomNumber = roomNumber;
        }

        public override string ToString()
        {
            return "CustomerId: " + CustomerId + "\r\nFirst Name: " + firstName + "\r\nLast Name: " + lastName + "\r\nDepartment: " + department + "\r\nEmail: " + email + "\r\nPhone: " + phone + "\r\nRoom Number: " + roomNumber;
        }

    }
}
