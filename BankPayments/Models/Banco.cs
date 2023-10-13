using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankPayments.Models;

public partial class Banco
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string NomeBanco { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string CodigoBanco { get; set; }

    [Required]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal PercentualJuros { get; set; }

}