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
            
        }
    }
}