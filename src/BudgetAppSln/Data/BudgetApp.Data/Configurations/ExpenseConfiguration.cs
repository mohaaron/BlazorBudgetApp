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
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> entity)
        {
            //entity.HasOne<Budget>(e => e.Budget).WithMany(b => b.Expenses);
            entity.Property(p => p.DueDate).HasColumnType("date");
            entity.Property(p => p.Cost).HasPrecision(9, 2);
            //entity.HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
