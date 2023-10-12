using BankPayments.Infrastructure;
using BankPayments.Interfaces;
using BankPayments.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankPayments.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly BankPaymentsManagerDBContext _context;

        public BancoRepository(BankPaymentsManagerDBContext context)
        {
            _context = context;
        }
        public void AddBanco(Banco banco) => _context.Banco.Add(banco);

        public async Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            IEnumerable<Banco> listBancos = await _context.Banco.ToListAsync();
            return listBancos;
        }

        public async Task<Banco> GetBancoById(long id) => await _context.Banco.Where(x => x.Id == id).FirstOrDefaultAsync();
     
        public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;
    }
}
