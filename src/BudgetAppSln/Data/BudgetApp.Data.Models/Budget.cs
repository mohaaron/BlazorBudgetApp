using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Models
{
	public class Budget
	{
		[Key]
		public int Id { get; set; }

		public ICollection<Expense> Expenses { get; set; }

		public ICollection<Income> Incomes { get; set; }

		[NotMapped]
		public decimal GetTotalExpenses => Expenses.Sum(s => s.Cost);

		[NotMapped]
		public decimal GetTotalIncome => Incomes.Sum(s => s.Amount);

		[NotMapped]
		public decimal GetTotalAvailable => GetTotalIncome - GetTotalExpenses;
	}
}
