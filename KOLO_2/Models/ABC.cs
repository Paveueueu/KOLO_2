using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

[Table("ABC")]
[PrimaryKey(nameof(IdAB), nameof(IdC))]
public class ABC
{
    
    
    public int IdAB { get; set; }
    [ForeignKey(nameof(IdAB))]
    public AB AB { get; set; } = null!;
    
    public int IdC { get; set; }
    [ForeignKey(nameof(IdC))]
    public C C { get; set; } = null!;
}