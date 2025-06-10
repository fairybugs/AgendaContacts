using AgendaContacts.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaContacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaContactsController : ControllerBase
    {
        private readonly AgendaDBContext _dbContext;

        public AgendaContactsController(AgendaDBContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> ContactList()
        {
            var Contacts = await _dbContext.Contacts.ToListAsync();

            return Ok(Contacts);
        }

        [HttpGet]
        [Route("GetContact")]
        public async Task<IActionResult> GetContact(int id)
        {
            Contact contact = await _dbContext.Contacts.FindAsync(id);

            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult>EditContact(int id, Contact contact )
        {
            var CurrentContact = await _dbContext.Contacts.FindAsync(id);

            CurrentContact.Name = contact.Name;
            CurrentContact.Email = contact.Email;
            CurrentContact.Phone = contact.Phone;
            CurrentContact.Note = contact.Note;
            
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult>DeleteContact(int id)
        {
            var ContactDeleted = await _dbContext.Contacts.FindAsync(id);

            _dbContext.Contacts.Remove(ContactDeleted!);

            await _dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
