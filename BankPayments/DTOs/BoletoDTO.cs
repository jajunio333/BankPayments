using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankPayments.DTOs
{
    public class BoletoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string NomePagador { get; set; }

        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string NomeBeneficiario { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        public string? Observacao { get; set; }
    }
}
