using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SMTP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an email address:\n");
          //  string id = Console.ReadLine();
            string id = "<email here>";
            Console.WriteLine("Please enter password:\n");
            //string pass = Console.ReadLine();
            string pass = "<enter pass here>"; 
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Password: " + pass);
            while (true){
                Console.WriteLine("Press 1 to send the email\nAny other key to exit.");
                char c = Console.ReadKey().KeyChar;
                if (c != '1')
                {
                    Console.WriteLine("Ending Program");
                    break;
                }
                else
                {
                    Console.WriteLine("Trying to send an Email.");
                    sendEmail(id, pass);
                }
            }
            
            
        }
        static void sendEmail(string uname, string pass)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(uname, pass),
                    
                };
                MailMessage mm = new MailMessage(uname, uname, "Testing", "This is a test Email.\n");
                client.Send(mm);
                Console.WriteLine("Email Sent");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send email\n\n" + e.ToString());
            }
        }
    }
}
