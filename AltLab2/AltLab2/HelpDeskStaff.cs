using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class HelpDeskStaff
    {
   
        public int helpDeskStaffId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string status { get; set; }

        public HelpDeskStaff(int helpDeskStaffId, string firstName, string lastName, string email, string phone, string status)
        {
            this.helpDeskStaffId = helpDeskStaffId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.status = status;
        }

        public HelpDeskStaff(string firstName, string lastName, string email, string phone, string status)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.status = status;
        }

        public override string ToString()
        {
            return "\r\nHelp Desk Staff Id: " + helpDeskStaffId + "\r\nFirst Name: " + firstName + "\r\nLast Name: " + lastName + "\r\nEmail: " + email + "\r\nPhone: " + phone + "\r\nStatus: " + status;
        }
    }
}
