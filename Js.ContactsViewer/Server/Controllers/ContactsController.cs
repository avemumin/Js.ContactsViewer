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
            .Include(c=>c.Category)
            .Include(x=>x.SubCategory)
            .ToListAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactById(int id)
    {
        var contact = await _dbContext.Contacts
            .FirstOrDefaultAsync(x => x.Id == id);
        if(contact is null)
        {
            throw new Exception($"Sorry there is no user with id:{id}");
        }
        return Ok(contact);
    }
}

