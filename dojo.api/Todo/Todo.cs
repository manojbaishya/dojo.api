using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dojo.Api.Todo;

public class Todo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; init; }
    
    [MaxLength(20)]
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}