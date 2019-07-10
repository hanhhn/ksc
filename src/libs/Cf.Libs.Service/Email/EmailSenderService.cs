using System;
using System.Threading.Tasks;

namespace Cf.Libs.Service.Email
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
