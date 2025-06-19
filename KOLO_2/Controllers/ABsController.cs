using KOLO_2.DTOs;
using KOLO_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLO_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ABsController : ControllerBase
{
    private readonly IDbService _dbService;
    public ABsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetABsData(string? aLastName = null)
    {
        if (aLastName == null)
            return BadRequest();
        if (await _dbService.GetAByLastName(aLastName) == null)
            return NotFound();
        
        var orders = await _dbService.GetABsData(aLastName);

        return Ok(orders.Select(e => new GetABsDTO()
        {
            Id = e.Id,
            ABCs = e.ABCs.Select(p => new GetABCsDTO()
            {
                Name = p.C.Name,
            }).ToList()
        }));
    }
}