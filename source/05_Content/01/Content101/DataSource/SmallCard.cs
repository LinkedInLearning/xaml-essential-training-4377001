using BigStar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content101.DataSource {
	internal class SmallCard {
		public int Id { get; set; }
		public string CardName { get; set; }
		public decimal Price { get; set; }
		public TeamNames Team { get; set; }

		public override string ToString() {
			return $"Card: {CardName}, {Team}, {Price:C}";
		}
	}
}