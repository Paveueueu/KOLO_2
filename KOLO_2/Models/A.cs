using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Models;

public class A
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;

    
    public ICollection<AB> ABs { get; set; }  = new HashSet<AB>();
}