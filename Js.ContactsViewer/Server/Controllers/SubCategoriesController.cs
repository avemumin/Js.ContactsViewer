using Js.ContactsViewer.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SubCategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public SubCategoriesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<SubCategory>>> GetAllSubCategories()
    {
        var result = await _dbContext.SubCategories
            .ToListAsync();

        return Ok(result);
    }
}
