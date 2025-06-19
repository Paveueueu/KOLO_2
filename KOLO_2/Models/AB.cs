using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

public class AB
{
    [Key]
    public int Id { get; set; }
    
    
    
    
    public int IdA { get; set; }
    [ForeignKey(nameof(IdA))]
    public A A { get; set; } = null!;
    
    public int IdB { get; set; }
    [ForeignKey(nameof(IdB))]
    public B B { get; set; } = null!;
    
    public ICollection<ABC> ABCs { get; set; } = new HashSet<ABC>();
}