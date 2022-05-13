using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System.DataLayar.Entities.Wallet;

public class BankTransaction
{
    [Key]
    public int BankTransactionId { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime? CreateDateTime { get; set; }

    [Column("order_id")]
    [StringLength(50)]
    public string OrderId { get; set; }
    
    [Column("amount", TypeName = "decimal(18, 0)")]
    public decimal? Amount { get; set; }
    
    [Column("OK")]
    public bool Ok { get; set; }
}