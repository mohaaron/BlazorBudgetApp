using AutoMapper;
using BudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Shared.AutoMapper
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            // TODO: Options.Ignore() doesn't work. Find out why
            CreateMap<Expense, Expense>()
                .ForMember(dest => dest.Budget, opt => opt.Condition(source => source.Budget == null))
                .ForMember(dest => dest.Income, opt => opt.Condition(source => source.Income == null));
        }
    }
}
