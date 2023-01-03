

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using PartnerPortal.Domain.Model;
using PartnerPortal.WebApi.Settings;

namespace PartnerPortal.WebApi.Services
{
   
    
        public class MailService : IMailService
        {
            private readonly MailSettings _mailSettings;
            public MailService(MailSettings mailSettings)
            {
                _mailSettings = mailSettings;
            }
            public async Task SendEmailAsync(MailRequest mailRequest)
            {
                var email = new MimeMessage();
                //MailMessage email=new MailMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                //email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

                string[] multiEmail = mailRequest.ToEmail.Split(',');

                foreach (string emailid in multiEmail)
                {
                    email.To.Add(MailboxAddress.Parse(emailid));
                }
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            
                using var smtp = new SmtpClient();
            
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);

                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            
            }


        }
    }


