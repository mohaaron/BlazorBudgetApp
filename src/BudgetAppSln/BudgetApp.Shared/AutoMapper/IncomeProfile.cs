using AutoMapper;
using BudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Shared.AutoMapper
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            // TODO: Options.Ignore() doesn't work. Find out why
            CreateMap<Income, Income>()
                .ForMember(dest => dest.Budget, opt => opt.Condition(source => source.Budget == null))
                .ForMember(dest => dest.Expenses, opt => opt.Condition(source => source.Expenses == null));
        }
    }
}
