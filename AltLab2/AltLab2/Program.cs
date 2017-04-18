using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Begin HelpDeskStaffUtil Test
            //HelpDeskStaffUtil helpDeskUtil = new HelpDeskStaffUtil();
            //List<HelpDeskStaff> onDutyHelpDeskStaff = new List<HelpDeskStaff>();
            //onDutyHelpDeskStaff = helpDeskUtil.GetOnDutyHelpDeskStaff("On Duty");

            //foreach (HelpDeskStaff helpers in onDutyHelpDeskStaff)
            //{
            //    Console.WriteLine(helpers.firstName + " " + helpers.lastName + "\r\n");
            //}
            ////End HelpDeskStaffUtil Test

            ////Begin CustomerUtil Test#1
            //CustomerUtil custUtil = new CustomerUtil();
            //List<Customer> customers = custUtil.GetAllCustomers();
            //foreach (Customer cust in customers)
            //{
            //    Console.WriteLine(cust.ToString());
            //}
            ////End CustomerUtil Test#1

            ////Begin CustomerUtil Test#2
            //CustomerUtil custUtil = new CustomerUtil();
            //Customer foundCustomer = custUtil.GetCustomer(4);
            //Console.WriteLine(foundCustomer.ToString());
            ////End CustomerUtil Test#3

            ////Begin TicketUtil Test#1
            //TicketUtil ticketUtil = new TicketUtil();
            //List<Ticket> tickets = ticketUtil.GetAllTickets();
            //foreach (Ticket ticks in tickets)
            //{
            //    Console.WriteLine(ticks.ToString()+"\r\n");
            //}
            ////End TicketUtil Test#1

            ////Begin TicketUtil Test#2
            //TicketUtil ticketUtil = new TicketUtil();
            //List<Ticket> openTickets = new List<Ticket>();
            //openTickets = ticketUtil.GetTicketsByStatus("Open");
            //foreach (Ticket openTicks in openTickets)
            //{
            //    Console.WriteLine(openTicks.ToString() + "\r\n");

            //}
            ////End TicketUtil Test#2

            ////Begin TicketUtil Test#3
            //TicketUtil ticketUtil = new TicketUtil();
            //Ticket ticket = ticketUtil.GetTicket(7);
            //Console.WriteLine(ticket.ToString());
            ////End TicketUtil Test#3

            ////Begin TicketUtil Test#4
            //TicketUtil ticketUtil = new TicketUtil();
            //Ticket ticket = ticketUtil.UpdateTicket(6, "Open", 1, 3, "Broken Pencils", "Buy New Ones", "No", "No", DateTime.Today, new DateTime(1753, 1, 1));
            //List<Ticket> tickets = ticketUtil.GetAllTickets();
            //foreach (Ticket ticks in tickets)
            //{
            //    Console.WriteLine(ticks.ToString() + "\r\n");
            //}
            ////End TicketUtil Test#4

            ////Begin TicketUtil Test#5
            //TicketUtil ticketUtil = new TicketUtil();
            //Ticket ticket = ticketUtil.InsertTicket(new Ticket("Open", 1, 3, "Broken Pencil", "Buy New One", "No", "No", DateTime.Today, new DateTime(1753, 1, 1)));
            //Ticket ticket2 = ticketUtil.GetTicket(Convert.ToInt32(ticket.ticketId.ToString()));
            //Console.WriteLine(ticket2.ToString());
            ////End TicketUtil Test#5

            ////Begin Extra Credit Test#1
            //Console.WriteLine("Welcome, please fill out the information below to create a service account.");
            //Console.WriteLine("\r\n" + "Please Enter Your First Name: ");
            //string firstName = Console.ReadLine();
            //Console.WriteLine("\r\n" + "Please Enter Your Last Name: ");
            //string lastName = Console.ReadLine();
            //Console.WriteLine("\r\n" + "Please Enter The Department Name: ");
            //string department = Console.ReadLine();
            //Console.WriteLine("\r\n" + "Please Enter Your Email: ");
            //string email = Console.ReadLine();
            //Console.WriteLine("\r\n" + "Please Enter Your Phone Number: ");
            //string phoneNumber = Console.ReadLine();
            //Console.WriteLine("\r\n" + "Please Enter Your Room Number: ");
            //int roomNumber = Convert.ToInt32(Console.ReadLine());
            //CustomerUtil customerUtil = new CustomerUtil();
            //Customer customer = customerUtil.InsertCustomer(new Customer(firstName, lastName, department, email, phoneNumber, roomNumber));

            //int customerId = customer.CustomerId;

            //TicketUtil ticket = new TicketUtil();
            //Console.WriteLine("\r\n" + "Thank you, please enter the information below to create your ticket. ");
            //Console.WriteLine("\r\n" + "Please enter the description of your problem. ");
            //string probDesc = Console.ReadLine();
            //Console.WriteLine("Thank you, your ticket has been created. ");
            //Ticket newTicket = ticket.InsertTicket(new Ticket("Open", 1, customerId, probDesc, "", "", "", DateTime.Today, new DateTime(1753, 1, 1)));
            //Ticket newTicket2 = ticket.GetTicket(Convert.ToInt32(newTicket.ticketId.ToString()));
            //Console.WriteLine(newTicket2.ToString());
            ////End Extra Credit Test #1


            ////Begin Extra Credit Test 2 & 3
            //Boolean acceptableInput = false;
            //Console.Write("Please enter 1 for Help Desk Staff access or 2 for Supervisor access: ");
            //int input = Convert.ToInt16(Console.ReadLine());

            //while (acceptableInput == false)
            //{
            //    switch (input)
            //    {
            //        case 1:
            //            {
            //                acceptableInput = true;
            //                Console.Write("Please enter your Staff Id to display a list of all tickets assigned to you: ");
            //                int staffId = Convert.ToInt16(Console.ReadLine());
            //                Console.WriteLine();

            //                List<Ticket> ticketsForStaffId = new List<Ticket>();
            //                TicketUtil ticketUtil = new TicketUtil();
            //                ticketsForStaffId = ticketUtil.GetTicketsByStaffId(staffId);
            //                foreach (Ticket tickets in ticketsForStaffId)
            //                {
            //                    Console.WriteLine(tickets.ToString());
            //                    Console.WriteLine();
            //                }

            //                Console.Write("Please enter the Ticket Id of the Ticket you would like to edit: ");
            //                int ticketId = Convert.ToInt16(Console.ReadLine());
            //                Console.Write("Please enter the updated status information: ");
            //                string status = Console.ReadLine();
            //                Console.Write("Please enter the updated resolution information: ");
            //                string resolution = Console.ReadLine();
            //                Console.Write("Please enter the updated follow up required field information: ");
            //                string followUpReq = Console.ReadLine();
            //                Console.Write("Please enter the updated follow up complete field information: ");
            //                string followUpComp = Console.ReadLine();
            //                Console.Write("Please enter the updated resolved date(YYYY-MM-DD hh:mm:ss): ");
            //                DateTime resolvedDate = Convert.ToDateTime(Console.ReadLine());

            //                ticketUtil.StaffUpdateTicket(ticketId, status, resolution, followUpReq, followUpComp, resolvedDate);
            //                Console.WriteLine("Thank you, here is the updated ticket information.");
            //                Ticket updatedTicket = ticketUtil.GetTicket(ticketId);
            //                Console.WriteLine(updatedTicket.ToString());

            //                break;
            //            }
            //        case 2:
            //            {
            //                acceptableInput = true;
            //                Console.WriteLine("Here is a list of currently on duty Help Desk Staff. ");
            //                HelpDeskStaffUtil helpDeskUtil = new HelpDeskStaffUtil();
            //                List<HelpDeskStaff> onDutyHelpDeskStaff = new List<HelpDeskStaff>();
            //                onDutyHelpDeskStaff = helpDeskUtil.GetOnDutyHelpDeskStaff("On Duty");

            //                foreach (HelpDeskStaff helpers in onDutyHelpDeskStaff)
            //                {
            //                    Console.WriteLine("StaffID: " + helpers.helpDeskStaffId + " " + helpers.firstName + " " + helpers.lastName);
            //                }

            //                Console.WriteLine("Here is a list of currently open tickets.\r\n");
            //                TicketUtil ticketUtil = new TicketUtil();
            //                List<Ticket> openTickets = new List<Ticket>();
            //                openTickets = ticketUtil.GetTicketsByStatus("Open");
            //                foreach (Ticket openTicks in openTickets)
            //                {
            //                    Console.WriteLine(openTicks.ToString() + "\r\n");

            //                }

            //                Console.Write("Please enter the Ticket Id you would like to assign to a different Help Desk Staff Member: ");
            //                int ticketId = Convert.ToInt16(Console.ReadLine());
            //                Console.WriteLine();
            //                Console.Write("Please enter the Staff Id of the Help Desk Staff Member you would like to assign it to: ");
            //                int staffId = Convert.ToInt16(Console.ReadLine());
            //                Console.WriteLine();

            //                Ticket ticketUpdate = ticketUtil.ReAssignTicket(ticketId, staffId);
            //                Console.WriteLine("Thank you, here is the updated ticket information. ");
            //                Console.WriteLine(ticketUtil.GetTicket(ticketId).ToString());

            //                break;
            //            }
            //        default:
            //            {
            //                Console.WriteLine("You did not make a valid selection. Please try again. ");
            //                break;
            //            }
            //    }
            //}
            ////End Extra Credit Test 2 & 3

            Console.ReadKey();
        }
    }
}
