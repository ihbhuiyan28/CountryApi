using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountryApi.Data;
using CountryApi.Models;

namespace CountryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private static CountryApiContext _context = null!;
    public CountryController(CountryApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> FindAllCountry()
    {
        var countries = await _context.Countries.ToListAsync();
        return Ok(countries);
    }

    [HttpGet("id")]
    public async Task<IActionResult> FindCountryById(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(data => data.Id == id);
        if (country == null)
        {
            return BadRequest("Invalid Id!");
        }
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry(Country country)
    {
        await _context.AddAsync(country);
        await _context.SaveChangesAsync();
        return CreatedAtAction("FindAllCountry", country.Id, country);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCountry(int id, string name)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(data => data.Id == id);
        if (country == null)
        {
            return BadRequest("Invalid Id!");
        }
        country.Name = name;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(data => data.Id == id);
        if (country == null)
        {
            return BadRequest("Invalid Id!");
        }
        _context.Remove(country);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
