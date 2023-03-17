using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute]Guid id, )
        {

        }
    }
}
