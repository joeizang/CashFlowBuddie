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
                .ForMember(dest => dest.Transactions, source => source.MapFrom(propt => propt.CashFlows))
                .ForMember(dest => dest.AccountBalance, source => source.MapFrom(propt => propt.BankBalance))
                .ForMember(dest => dest.BankAccountNumber, source => source.MapFrom(propt => propt.Id));

            CreateMap<BankAccount, BankAccountEditModel>().ReverseMap()
                .ForMember(dest => dest.AccountName, source => source.MapFrom(opt => opt.NameOfAccount))
                .ForMember(dest => dest.InstitutionName, source => source.MapFrom(opt => opt.InstitutionName))
                .ForMember(dest => dest.BankBalance, source => source.MapFrom(opt => opt.AccountBalance));

            CreateMap<BankAccount, BankAccountDeleteModel>().ReverseMap()
                .ForMember(dest => dest.BankBalance, source => source.MapFrom(opt => opt.BankBalance))
                .ForMember(dest => dest.AccountName, source => source.MapFrom(opt => opt.AccountName))
                .ForMember(dest => dest.InstitutionName, source => source.MapFrom(opt => opt.InstitutionName));
        }
    }
}