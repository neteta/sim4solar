using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sim4solar.Common
{
	/// <summary>
	/// Common Caluration Class
	/// </summary>
	internal class CommonCalc
	{
		public static decimal GetDecimalValue(string targetVal)
		{
			decimal retVal;

			if (!decimal.TryParse(targetVal.Replace("\"", ""), out retVal))
			{
				return 0;
			}

			return retVal;
		}
	}
}
