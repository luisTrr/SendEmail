using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using SendEmail.Services;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            try
            {
                _emailService.SendEmail(request);
                return Ok("Correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al enviar el correo electrónico: " + ex.Message);
            }
        }
    }
}
