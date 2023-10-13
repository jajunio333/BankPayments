using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankPayments.Models;

public partial class Boleto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string NomePagador { get; set; }

    [Required]
    [Column("CPFCNPJPagador")]
    [StringLength(20)]
    [Unicode(false)]
    public string CpfCnpjPagador { get; set; }

    [Required]
    [StringLength(200)]
    [Unicode(false)]
    public string NomeBeneficiario { get; set; }

    [Required]
    [Column("CPFCNPJBeneficiario")]
    [StringLength(20)]
    [Unicode(false)]
    public string CpfCnpjBeneficiario { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Valor { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime DataVencimento { get; set; }

    [Column(TypeName = "text")]
    public string? Observacao { get; set; }


    [Required]
    public int BancoId { get; set; }

}