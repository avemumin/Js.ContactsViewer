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

    [HttpGet("{id}")]
    public async Task<ActionResult<SubCategory>> GetSubcategoryById(int id)
    {
        var result = await _dbContext.SubCategories
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (result == null)
        {
            return NotFound("Brak podkategorii");
        }
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<List<SubCategory>>> CreateSubCategory(SubCategory subCategory)
    {
        _dbContext.SubCategories.Add(subCategory);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetSubCategoriesFromDb());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<SubCategory>>> UpdateSubCategory(SubCategory subCategory, int id)
    {
        var subCatToUpdate = await _dbContext.SubCategories
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (subCatToUpdate == null)
        {
            return NotFound("Brak podkategorii");
        }

        subCatToUpdate.SubCatName = subCategory.SubCatName;
        subCatToUpdate.SubCatDescription = subCategory.SubCatDescription;

        await _dbContext.SaveChangesAsync();
        return Ok(await GetSubCategoriesFromDb());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SubCategory>>> DeleteSubCategory(int id)
    {
        var subCatToRemove = await _dbContext.SubCategories
            .Include(x=>x.Contacts)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (subCatToRemove == null)
        {
            return NotFound("Brak podkategorii");
        }
        _dbContext.SubCategories.Remove(subCatToRemove);
        await _dbContext.SaveChangesAsync();
        return Ok(await GetSubCategoriesFromDb());
    }
    private async Task<List<SubCategory>> GetSubCategoriesFromDb()
    {
        return await _dbContext.SubCategories.ToListAsync();
    }
}
