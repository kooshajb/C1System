using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table(" Transaction")]
public class TransactionEntity
{
    [Key]
    public int TransactionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDateTime { get; set; }
        
    public decimal Amount { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; }
    
    [Column("OK")]
    public bool Ok { get; set; } = false;
    
}