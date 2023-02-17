using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigStar.Models{
	public class CitySource {

		private ObservableCollection<string> _cities;
		public CitySource() {
			_cities = new ObservableCollection<string> { "Barcelona", "São Paulo", "Singapore", "Bangkok" };
		}
		public ObservableCollection<string> Cities
		{
			get
			{
				return _cities;
			}
		}

	}
}
