using Js.ContactsViewer.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ContactsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetAllContacts()
    {
        var result = await _dbContext.Contacts
            .Include(c => c.Category)
            .Include(x => x.SubCategory)
            .ToListAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactById(int id)
    {
        var contact = await _dbContext.Contacts
            .FirstOrDefaultAsync(x => x.Id == id);
        if (contact is null)
        {
            throw new Exception($"Sorry there is no user with id:{id}");
        }
        return Ok(contact);
    }


    [HttpPost]
    public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
    {

        contact.Category = null;
        contact.SubCategory = null;
        _dbContext.Contacts.Add(contact);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetContactsFromDb());
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact, int id)
    {
        var contactToUpdate = await _dbContext.Contacts
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contactToUpdate == null)
        {
            return NotFound("Brak kategorii");
        }

        contactToUpdate.Name = contact.Name;
        contactToUpdate.LastName = contact.LastName;
        contactToUpdate.Phone = contact.Phone;
        contactToUpdate.Email = contact.Email;
        contactToUpdate.BirthDay = contact.BirthDay;
        contactToUpdate.Password = contact.Password;
        contactToUpdate.SubCategoryId =contact.SubCategoryId;
        contactToUpdate.CategoryId = contact.CategoryId;
      
        await _dbContext.SaveChangesAsync();
        return Ok(await GetContactsFromDb());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Contact>>> DeleteCategory(int id)
    {
        var contactToRemove = await _dbContext.Contacts
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contactToRemove == null)
        {
            return NotFound("Brak kategorii");
        }
        _dbContext.Contacts.Remove(contactToRemove);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetContactsFromDb());
    }
    private async Task<List<Contact>> GetContactsFromDb()
    {
        return await _dbContext.Contacts
            .Include(x => x.Category)
            .Include(z => z.SubCategory)
            .ToListAsync();
    }
}

