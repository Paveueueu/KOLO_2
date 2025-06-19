using KOLO_2.Models;

namespace KOLO_2.Services;

public interface IDbService
{
    Task<A?> GetAByLastName(string lastName);
    Task<ICollection<AB>> GetABsData(string? aLastName);
    
    Task<bool> DoesAExist(int idA);
    Task<bool> DoesBExist(int idB);
    Task AddNewAB(AB ab);
    Task<C?> GetCByName(string name);
    Task AddABCs(IEnumerable<ABC> abcs);
}