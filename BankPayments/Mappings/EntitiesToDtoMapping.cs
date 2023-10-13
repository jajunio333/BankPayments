using AutoMapper;
using BankPayments.DTOs;
using BankPayments.Models;

namespace BankPayments.Mappings
{
    public class EntitiesToDtoMapping : Profile
    {
        public EntitiesToDtoMapping()
        {
            CreateMap<Boleto, BoletoDTO>();
        }
    }
}
