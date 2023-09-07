using Js.ContactsViewer.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CategoriesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategories()
    {
        var result = await _dbContext.Categories
            .ToListAsync();

        return Ok(result);
    }
}
