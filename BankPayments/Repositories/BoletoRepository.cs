using BankPayments.Infrastructure;
using BankPayments.Interfaces;
using BankPayments.Models;
using Microsoft.EntityFrameworkCore;

namespace BankPayments.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly BankPaymentsManagerDBContext _context;

        public BoletoRepository(BankPaymentsManagerDBContext context) 
        {
            _context = context;
        }

        public void AddBoleto(Boleto boleto)
        {
            _context.Boleto.Add(boleto);
        }

        public async Task<Boleto> GetBoletoById(long id) => await _context.Boleto.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
