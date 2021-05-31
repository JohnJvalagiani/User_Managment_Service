using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
