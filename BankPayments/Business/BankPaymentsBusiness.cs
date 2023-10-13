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

        public async Task<bool> AddBancoAsync(Banco banco)
        {
            _bancoRepository.AddBanco(banco);
            if ( await _bancoRepository.SaveAllAsync())
                return true;

            return false;
        }

        public async Task<bool> AddBoletoAsync(Boleto boleto)
        {
            _boletoRepository.AddBoleto(boleto);

            if (await _boletoRepository.SaveAllAsync())
                return true;

            return false;
        }

        public async Task<IEnumerable<Banco>> GetAllBancos() => await _bancoRepository.GetAllBancosAsync();

        public async Task<Banco> GetBancoByCode(String codigoBanco) => await _bancoRepository.GetBancoByCode(codigoBanco);

        public async Task<Boleto> GetBoletoById(int id)
        {
          Boleto result = await _boletoRepository.GetBoletoById(id);

            if (result.DataVencimento < DateTime.Today)
            {
                return await CalculateInterest(result);
            }
                
            return result;
        }

        #region private methodes

        private async Task<Boleto> CalculateInterest(Boleto boleto)
        {
            int numDays = (int)(DateTime.Today - boleto.DataVencimento).TotalDays;
            var bank = await _bancoRepository.GetBancoById(boleto.BancoId);

            decimal juros = boleto.Valor * (bank.PercentualJuros / 100);
            decimal valorComJuros = boleto.Valor + juros * numDays;

            boleto.Valor = Math.Round(valorComJuros, 2);

            return boleto;
        }

        #endregion
    }
}
