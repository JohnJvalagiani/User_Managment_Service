using Core.Models;
using Core.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Service.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Server.Controllers
{
    public class InvoiceController:BaseController
    {
        private readonly InvoiceService _service;
        private readonly IMailService _mailService;


        public InvoiceController(InvoiceService service, IMailService mailService)
        {
            this._service = service;
            
            this._mailService = mailService;
        }


        [HttpGet]
        public async Task<IActionResult> GenerateInvoice()
        {
          var invoices =  await _service.GetInvoiceAsync();

            return Ok(invoices);
        }

        [HttpPost]
        public async Task<IActionResult> SendInvoices()
        {
            var invoices = await _service.GetInvoiceAsync();

            var mail = new MailRequest { };

            await _mailService.SendEmailAsync(mail);

            return Ok(invoices);
        }



    }
}
