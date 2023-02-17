using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content101.DataSource {
	public class CitySource {

		private List<string> _cities;
		public CitySource() {
			_cities = new List<string> { "Barcelona", "São Paulo", "Singapore", "Bangkok" };
		}
		public List<string> Cities
		{
			get
			{
				return _cities;
			}
		}

	}
}
