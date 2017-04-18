using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class Ticket
    {

        public int ticketId { get; set; }
        public string status { get; set; }
        public int customerId { get; set; }
        public int helpDeskStaffId { get; set; }
        public string problemDesc { get; set; }
        public string resolution { get; set; }
        public string followUpRequired { get; set; }
        public string followUpComplete { get; set; }
        public DateTime ticketDate { get; set; }
        public DateTime? resolvedDate { get; set; }

        public Ticket(int ticketId, string status, int customerId, int helpDeskStaffId, string problemDesc, string resolution, string followUpRequired, string followUpComplete, DateTime ticketDate, DateTime resolvedDate)
        {
            this.ticketId = ticketId;
            this.status = status;
            this.customerId = customerId;
            this.helpDeskStaffId = helpDeskStaffId;
            this.problemDesc = problemDesc;
            this.resolution = resolution;
            this.followUpRequired = followUpRequired;
            this.followUpComplete = followUpComplete;
            this.ticketDate = ticketDate;
            this.resolvedDate = resolvedDate;
        }

        public Ticket(string status, int customerId, int helpDeskStaffId, string problemDesc, string resolution, string followUpRequired, string followUpComplete, DateTime ticketDate, DateTime resolvedDate)
        {
            this.status = status;
            this.customerId = customerId;
            this.helpDeskStaffId = helpDeskStaffId;
            this.problemDesc = problemDesc;
            this.resolution = resolution;
            this.followUpRequired = followUpRequired;
            this.followUpComplete = followUpComplete;
            this.ticketDate = ticketDate;
            this.resolvedDate = resolvedDate;
        }

        public Ticket(int ticketId, string status, int customerId, int helpDeskStaffId, string problemDesc, DateTime ticketDate)
        {
            this.ticketId = ticketId;
            this.status = status;
            this.customerId = customerId;
            this.helpDeskStaffId = helpDeskStaffId;
            this.problemDesc = problemDesc;
            this.ticketDate = ticketDate;
        }

        public Ticket(int ticketId, int helpDeskStaffId)
        {
            this.ticketId = ticketId;
            this.helpDeskStaffId = helpDeskStaffId;
        }

        public Ticket(string status, string resolution, string followUpReq, string followUpCom, DateTime resolvedDate)
        {
            this.status = status;
            this.resolution = resolution;
            this.followUpRequired = followUpReq;
            this.followUpComplete = followUpCom;
            this.resolvedDate = resolvedDate;
        }

        public override string ToString()
        {
            return "Ticket ID: " + ticketId + "\r\nStatus: " + status + "\r\nCustomer Id: " + customerId + "\r\nHelp Desk Staff Id: " + helpDeskStaffId + "\r\nDescription: " + problemDesc + "\r\nResolution: " + resolution +
                "\r\nFollow Up Required: " + followUpRequired + "\r\nFollow Up Complete: " + followUpComplete + "\r\nTicket Date: " + ticketDate + "\r\nResolved Date: " + resolvedDate;
        }

    }
}
