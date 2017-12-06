using AutoMapper;
using CashBuddie.Web.Models.InputModels;
using CashFlowBuddie.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashBuddie.Web.Models.MappingProfiles
{
    //Mapper.CreateMap<person, Employee>()
    //.ForMember(dest => dest.Fname, opt => opt.MapFrom(src => src.FirstName))
    //.ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName));
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountVM>().ReverseMap()
                .ForMember(destination => destination.Id, source => source.MapFrom(propt => propt.BankAccountNumber));
            CreateMap<BankAccount, BankAccountDetailModel>()
                .ForMember(dest => dest.Transactions, source => source.MapFrom(propt => propt.CashFlows));
            CreateMap<BankAccount, BankAccountEditModel>().ReverseMap()
                .ForMember(dest => dest.AccountName, source => source.MapFrom(opt => opt.NameOfAccount))
                .ForMember(dest => dest.InstitutionName, source => source.MapFrom(opt => opt.InstitutionName))
                .ForMember(dest => dest.BankBalance, source => source.MapFrom(opt => opt.AccountBalance))
                .ForMember(dest => dest.AccountHolder, source => source.MapFrom(opt => opt.NameOfAccount));
        }
    }
}