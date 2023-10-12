using BankPayments.Models;

namespace BankPayments.Interfaces
{
    public interface IBankPaymentsBusiness
    {
        public void AddBanco(Banco banco);

        public Task<IEnumerable<Banco>> GetAllBancos();

        public Task<Banco> GetBancoById(long id);

        public void AddBoleto(Boleto bolteto);

        public Task<Boleto> GetBoletoById(long id);

    }
}
