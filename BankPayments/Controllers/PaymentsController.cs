using BankPayments.Interfaces;
using BankPayments.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankPayments.Controllers
{
    public class PaymentsController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class BoletoController : ControllerBase
        {
            private readonly IBankPaymentsBusiness _bankPaymentsBusiness;

            public BoletoController(IBankPaymentsBusiness bankPaymentsBusiness)
            {
                _bankPaymentsBusiness = bankPaymentsBusiness;
            }

            //[HttpPost]
            //public async Task<ActionResult> CreateBoleto([FromBody] Boleto boletoCreate)
            //{
            //    try
            //    {
            //        var boletoDto = await _boletoService.AddBoleto(boletoCreate);
            //        //return CreatedAtAction(nameof(GetBoletoById), new { id = boletoDto.Id }, boletoDto);
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}

            //[HttpGet("{id}")]
            //public async Task<ActionResult<BoletoDto>> GetBoletoById(int id)
            //{
            //    try
            //    {
            //        var boletoDto = await _boletoService.GetBoletoByIdAsync(id);
            //        if (boletoDto == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(boletoDto);
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}

            [HttpGet("bancos")]
            public async Task<ActionResult<IEnumerable<Banco>>> GetAllBancos()
            {
                try
                {
                    var bancos = await _bankPaymentsBusiness.GetAllBancos();
                    return Ok(bancos);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            //[HttpGet("bancos/{codigoBanco}")]
            //public async Task<ActionResult<BancoDto>> GetBancoByCodigo(string codigoBanco)
            //{
            //    try
            //    {
            //        var bancoDto = await _boletoService.GetBancoByCodigoAsync(codigoBanco);
            //        if (bancoDto == null)
            //        {
            //            return NotFound();
            //        }
            //        return Ok(bancoDto);
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}
        }
    }
}
