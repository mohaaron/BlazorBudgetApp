using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Models
{
	public class Income
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public decimal Amount { get; set; } = 0;

		[Required]
		[StringLength(200)]
		public string Source { get; set; }

		[Required]
		public DateTime? PayDate { get; set; } = DateTime.Now;

		public Budget Budget { get; set; }

		/// <summary>
		/// Expenses grouped into paychecks
		/// </summary>
		public ICollection<Expense> Expenses { get; set; }

		[NotMapped]
		public decimal GetTotalExpenses => Expenses is not null ? Expenses.Sum(e => e.Cost) : 0;

		[NotMapped]
		public decimal GetTotalAvailable => this.Amount - GetTotalExpenses;
	}
}
