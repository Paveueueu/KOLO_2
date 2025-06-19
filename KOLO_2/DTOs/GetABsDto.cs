namespace KOLO_2.DTOs;

public class GetABsDTO
{
    public int Id { get; set; }
    public ICollection<GetABCsDTO> ABCs { get; set; } = null!;
}

public class GetABCsDTO
{
    public string Name { get; set; } = null!;
}