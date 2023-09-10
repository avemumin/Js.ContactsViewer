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



    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(int id)
    {
        var result = await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (result == null)
        {
            return NotFound("Brak kategorii");
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetCategoriesFromDb());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Category>>> UpdateCategory(Category category, int id)
    {
        var catToUpdate = await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (catToUpdate == null)
        {
            return NotFound("Brak kategorii");
        }

        catToUpdate.CategoryName = category.CategoryName;
        catToUpdate.CategoryDescription = category.CategoryDescription;

        await _dbContext.SaveChangesAsync();
        return Ok(await GetCategoriesFromDb());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
    {
        var catToRemove = await _dbContext.Categories
            .Include(x => x.Contacts)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (catToRemove == null)
        {
            return NotFound("Brak kategorii");
        }
        _dbContext.Categories.Remove(catToRemove);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetCategoriesFromDb());
    }
    private async Task<List<Category>> GetCategoriesFromDb()
    {
        return await _dbContext.Categories.ToListAsync();
    }
}
