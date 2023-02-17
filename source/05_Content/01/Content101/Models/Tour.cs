
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataSources
{
	
		public class Tour
		{
			public int TourId { get; set; }
			public string TourName { get; set; }
			public string Description { get; set; }

			public bool SeniorDiscountAvailable { get; set; }
			public bool KidFriendly { get; set; }
			public bool MultiDay { get; set; }
			public int MaxPeoplePerTour { get; set; }
			public string Region { get; set; }
			public Uri TourImagePath { get; set; }
		}
	
}