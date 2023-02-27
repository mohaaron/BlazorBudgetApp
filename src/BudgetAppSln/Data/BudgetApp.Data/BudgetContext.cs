using BudgetApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data
{
    // https://stackoverflow.com/questions/52020107/how-to-add-the-same-column-to-all-entities-in-ef-core/52021425#52021425
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    foreach (var entityProperty in entityType.GetProperties())
            //    {
            //        if (entityProperty.ClrType == typeof(decimal)
            //            && entityProperty.Name.Contains("Price"))
            //        {
            //            entityProperty.SetPrecision(9);
            //            entityProperty.SetScale(2);
            //        }

            //        if (entityProperty.ClrType == typeof(string)
            //            && entityProperty.Name.EndsWith("Url"))
            //        {
            //            entityProperty.SetIsUnicode(false);
            //        }
            //    }
            //}
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Debt> Debts { get; set; }
    }
}
