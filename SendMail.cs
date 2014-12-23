using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ThirdExercise {
    class SendMail {

        public void sendEmail() {
            try {
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 25;
                bool enableSSL = true;

                string emailFrom = "testingmail123@yahoo.com";
                string password = "Qwer1234";
                string emailTo = "bousamra.ralph@gmail.com";
                string subject = "Test";
                string body = "This is a test";

                using (MailMessage mail = new MailMessage()) {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            } catch (SmtpException ex) {
                MessageBox.Show("The error is: " + ex);
            }
        }
    }
}
