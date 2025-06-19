using KOLO_2.Data;
using KOLO_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<AB>> GetABsData(string? aLastName)
    {
        return await _context.ABs
            .Include(ab => ab.A)
            .Include(ab => ab.ABCs)
            .ThenInclude(abc => abc.C)
            .Where(ab => aLastName == null || ab.A.LastName == aLastName)
            .ToListAsync();
    }
    
    public async Task<A?> GetAByLastName(string lastName)
    {
        return await _context.As.FirstOrDefaultAsync(a => a.LastName == lastName);
    }
    
    
    public async Task<bool> DoesAExist(int idA)
    {
        return await _context.As.AnyAsync(a => a.Id == idA);
    }

    public async Task<bool> DoesBExist(int idB)
    {
        return await _context.Bs.AnyAsync(b => b.Id == idB);
    }

    public async Task AddNewAB(AB ab)
    {
        await _context.AddAsync(ab);
        await _context.SaveChangesAsync();
    }

    public async Task<C?> GetCByName(string name)
    {
        return await _context.Cs.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task AddABCs(IEnumerable<ABC> abcs)
    {
        await _context.AddRangeAsync(abcs);
        await _context.SaveChangesAsync();
    }
}