using System.Transactions;
using KOLO_2.DTOs;
using KOLO_2.Models;
using KOLO_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLO_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsController : ControllerBase
{
    private readonly IDbService _dbService;
    public AsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost("{idA}/abs")]
    public async Task<IActionResult> AddNewOrder(int idA, NewABDTO newAB)
    {
        if (!await _dbService.DoesAExist(idA))
            return NotFound($"A with given ID - {idA} doesn't exist");
        if (!await _dbService.DoesBExist(newAB.IdB))
            return NotFound($"B with given ID - {newAB.IdB} doesn't exist");
    
        var ab = new AB()
        {
            IdA = idA,
            IdB = newAB.IdB,
        };
    
        var abcs = new List<ABC>();
        foreach (var newABC in newAB.ABCs)
        {
             var c = await _dbService.GetCByName(newABC.Name);
             if(c is null) 
                 return NotFound($"C with name - {newABC.Name} doesn't exist");
            
    
             abcs.Add(new ABC
             {
                 IdC = c.Id,
                 AB = ab
             });
        }
    
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewAB(ab);
            await _dbService.AddABCs(abcs);
    
            scope.Complete();
        }
    
        return Created("api/abs", new
        {
            Id = ab.Id,
        });

    }
}