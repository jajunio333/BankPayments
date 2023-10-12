using BankPayments.Interfaces;
using BankPayments.Models;

namespace BankPayments.Business
{
    public class BankPaymentsBusiness : IBankPaymentsBusiness
    {
        private readonly IBancoRepository _bancoRepository;

        private readonly IBoletoRepository _boletoRepository;

        public BankPaymentsBusiness (IBancoRepository bancoRepository, IBoletoRepository boletoRepository)
        {
            _bancoRepository = bancoRepository;
            _boletoRepository = boletoRepository;
        }

        public void AddBanco(Banco banco) => _bancoRepository.AddBanco(banco);

        public async Task<IEnumerable<Banco>> GetAllBancos() => await _bancoRepository.GetAllBancosAsync();

        public async Task<Banco> GetBancoById(long id) => await _bancoRepository.GetBancoById(id);

        public void AddBoleto(Boleto boleto) => _boletoRepository.AddBoleto(boleto);

        public async Task<Boleto> GetBoletoById(long id)
        {
            return await _boletoRepository.GetBoletoById(id);
        }
    }
}
