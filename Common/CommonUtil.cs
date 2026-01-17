using sim4solar.Entity;
using System.Data;

namespace sim4solar.Common
{
	internal class CommonUtil
	{
		public static decimal GetDecimalValue(string targetVal)
		{
			if (!decimal.TryParse(GetStringWithoutDblQuot(targetVal), out decimal retVal))
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

		public static double GetDoubleValue(DataTable dt, string subCode)
		{
			return Convert.ToDouble(GetStringValue(dt, subCode));
		}

		public static string GetStringValue(DataTable dt, string subCode)
		{
			DataRow[] dr = dt.Select(MstCode.CODE + "='" + subCode + "'");
			return dr == null ? string.Empty : (string)dr[0][MstCode.VALUE];
		}

		public static DateTime GetDefaultDateTime(DateTime targetDate)
		{
			return new DateTime(targetDate.Year, targetDate.Month, 17);
		}
	}
}
