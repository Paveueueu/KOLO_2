using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

public class C
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<ABC> ABCs { get; set; } = new HashSet<ABC>();
}