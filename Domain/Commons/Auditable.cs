using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Commons;

public class Auditable
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Display(Name = "CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Display(Name = "UpdateAt")]
    public DateTime? UpdatedAt { get; set;}
}
