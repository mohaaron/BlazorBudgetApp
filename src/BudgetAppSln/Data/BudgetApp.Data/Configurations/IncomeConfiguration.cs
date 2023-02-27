using BudgetApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Configurations
{
	internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> entity)
        {
            entity.Property(p => p.PayDate).HasColumnType("date");
            entity.Property(p => p.Amount).HasPrecision(9, 2);
            //entity.HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
