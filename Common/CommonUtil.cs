using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sim4solar.Common
{
	internal class CommonUtil
	{
		public static decimal GetDecimalValue(string targetVal)
		{
			decimal retVal;

			if (!decimal.TryParse(CommonUtil.GetStringWithoutDblQuot(targetVal), out retVal))
			{
				return 0;
			}

			return retVal;
		}

		public static string GetStringWithoutDblQuot(string targetValue)
		{
			return targetValue.Replace("\"", "");
		}

		public static string GetDate(DateTime targetDate)
		{
			return targetDate.ToString("yyyy-MM-dd");
		}
	}
}
