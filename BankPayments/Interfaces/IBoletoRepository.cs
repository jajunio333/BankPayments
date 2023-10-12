using BankPayments.Models;

namespace BankPayments.Interfaces
{
    public interface IBoletoRepository
    {
        public void AddBoleto(Boleto bolteto);

        public Task<Boleto> GetBoletoById(long id);

        public Task<bool> SaveAllAsync();
    }
}
