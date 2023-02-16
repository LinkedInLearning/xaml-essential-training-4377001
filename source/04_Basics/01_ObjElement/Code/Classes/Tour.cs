using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectElements {
	public class Tour {
		public string TourName { get; set; }
		public string City { get; set; }

		public override string ToString() {
			return $"Tour: {TourName},{City}";
		}
	}
}
