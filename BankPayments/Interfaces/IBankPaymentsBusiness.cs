using BankPayments.Models;

namespace BankPayments.Interfaces
{
    public interface IBankPaymentsBusiness
    {
        public Task<bool> AddBancoAsync(Banco banco);

        public Task<IEnumerable<Banco>> GetAllBancos();

        public Task<Banco> GetBancoByCode(String codigoBanco);

        public Task<bool> AddBoletoAsync(Boleto bolteto);

        public Task<Boleto> GetBoletoById(int id);

    }
}
