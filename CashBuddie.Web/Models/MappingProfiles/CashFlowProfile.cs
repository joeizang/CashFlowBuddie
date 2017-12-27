using AutoMapper;
using CashFlowBuddie.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashBuddie.Web.Models.InputModels;

namespace CashBuddie.Web.Models.MappingProfiles
{
    public class CashFlowProfile : Profile
    {
        public CashFlowProfile()
        {
            CreateMap<CashFlow, CashFlowVM>().ReverseMap();
            CreateMap<CashFlow, CashFlowDetailModel>()
                .ForMember(dest => dest.Amount, source => source.MapFrom(propt => propt.Amount))
                .ForMember(dest => dest.BankAccountName,
                source => source.MapFrom(propt => propt.BankAccount.AccountName))
                .ForMember(dest => dest.BankAccountNumber,
                source => source.MapFrom(propt => propt.BankAccount.Id))
                .ForMember(dest => dest.CashFlowSource,
                source => source.MapFrom(propt => propt.CashFlowSouce))
                .ForMember(dest => dest.CashFlowType,
                source => source.MapFrom(propt => propt.CashFlowType))
                .ForMember(dest => dest.Date, source => source.MapFrom(propt => propt.CreatedAt))
                .ForMember(dest => dest.Id, source => source.MapFrom(propt => propt.Id));
            CreateMap<CashFlow, CreateCashFlowModel>()
                .ForMember(dest => dest.Amount, source => source.MapFrom(propt => propt.Amount))
                .ForMember(dest => dest.BankAccount,
                source => source.MapFrom(propt => propt.BankAccount))
                .ForMember(dest => dest.CashFlowSouce,
                source => source.MapFrom(propt => propt.CashFlowSouce))
                .ForMember(dest => dest.CashFlowType,
                source => source.MapFrom(propt => propt.CashFlowType))
                .ForMember(dest => dest.Description,
                source => source.MapFrom(propt => propt.Description));
            
        }
    }
}