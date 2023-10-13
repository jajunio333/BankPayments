using BankPayments.Models;

namespace BankPayments.Interfaces
{
    public interface IBancoRepository
    {
        public void AddBanco(Banco banco);

        public Task<IEnumerable<Banco>> GetAllBancosAsync();

        public Task<Banco> GetBancoByCode(string codigoBanco);
        public Task<Banco> GetBancoById(int id);

        public Task<bool> SaveAllAsync();
    }
}
