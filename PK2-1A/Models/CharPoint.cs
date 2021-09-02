using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belofor.Models
{
	public class ChartPoint
	{

		public DateTime DTS { get; set; }


		public double Measure { get; set; }

		public ChartPoint(DateTime dts, double meas)
		{
			this.DTS = dts;
			this.Measure = meas;
		}
	}
}
