using MailManagement.Data;
using MailManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController_D_BIT_22_0015 : ControllerBase
    {
        private readonly AppDbContext _context;

        public MailsController_D_BIT_22_0015(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMails_D_BIT_22_0015([FromQuery] int? senderId, [FromQuery] int? recipientId)
        {
            var query = _context.Mails.AsQueryable();
            if (senderId.HasValue)
                query = query.Where(m => m.SenderDepartmentId == senderId);
            if (recipientId.HasValue)
                query = query.Where(m => m.RecipientDepartmentId == recipientId);

            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMailById_D_BIT_22_0015(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
                return NotFound();

            return Ok(mail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMail_D_BIT_22_0015(Mail_D_BIT_22_0015 mail)
        {
            _context.Mails.Add(mail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMailById_D_BIT_22_0015), new { id = mail.Id }, mail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMailStatus_D_BIT_22_0015(int id, MailStatus_D_BIT_22_0015 status)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
                return NotFound();

            mail.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMail_D_BIT_22_0015(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
                return NotFound();

            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetMailStatus_D_BIT_22_0015(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
                return NotFound();

            return Ok(mail.Status);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateMailDeliveryStatus_D_BIT_22_0015(int id, MailStatus_D_BIT_22_0015 status)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
                return NotFound();

            mail.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
