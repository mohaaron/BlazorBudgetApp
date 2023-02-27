using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Models
{
	public class Expense
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string ExpenseName { get; set; }

		[Required]
		public decimal Cost { get; set; }

		[StringLength(800)]
		public string Notes { get; set; }

		public DateTime? DueDate { get; set; }

		public int BudgetId { get; set; }
		public Budget Budget { get; set; }

		public int? IncomeId { get; set; }
		public Income Income { get; set; }
	}
}
