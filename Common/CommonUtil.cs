using System.Data;

namespace sim4solar.Common
{
	internal class CommonUtil
	{
		public static decimal GetDecimalValue(string targetVal)
		{
			if (!decimal.TryParse(CommonUtil.GetStringWithoutDblQuot(targetVal), out decimal retVal))
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
			DataRow[] dr = dt.Select("code='" + subCode + "'");
			return dr == null ? string.Empty : (string)dr[0]["value"];
		}
	}
}
