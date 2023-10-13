﻿using BankPayments.Interfaces;
using BankPayments.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankPayments.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BankPaymentsController : Controller
    {
        private readonly IBankPaymentsBusiness _bankPaymentsBusiness;

        public BankPaymentsController(IBankPaymentsBusiness bankPaymentsBusiness)
        {
            _bankPaymentsBusiness = bankPaymentsBusiness;
        }

        [HttpPost("contribuicao-boleto")]
        public async Task<ActionResult> CreateBoleto([FromBody] Boleto boletoCreate)
        {
            try
            {
                var entity = await _bankPaymentsBusiness.AddBoletoAsync(boletoCreate);

                if (entity)
                    return Ok();

                return BadRequest("Falha ao salvar");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("boleto/{id}")]
        public async Task<ActionResult<Boleto>> GetBoletoById(int id)
        {
            try
            {
                var boleto = await _bankPaymentsBusiness.GetBoletoById(id);
                
                if (boleto == null)
                {
                    return NotFound();
                }
                return Ok(boleto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("contribuicao-banco")]
        public async Task<ActionResult> CreateBanco([FromBody] Banco bancoCreate)
        {
            try
            {
                var entity = await _bankPaymentsBusiness.AddBancoAsync(bancoCreate);

                if (entity)
                    return Ok();

                return BadRequest("Falha ao salvar");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpGet("bancos/{codigoBanco}")]
        public async Task<ActionResult<Banco>> GetBancoByCode(String codigoBanco)
        {
            try
            {
                var banco = await _bankPaymentsBusiness.GetBancoByCode(codigoBanco);
                if (banco == null)
                {
                    return NotFound();
                }

                return Ok(banco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
