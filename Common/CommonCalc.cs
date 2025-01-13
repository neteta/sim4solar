using System.Data;

namespace sim4solar.Common
{
	/// <summary>
	/// Common Caluration Class
	/// </summary>
	internal static class CommonCalc
	{
		public static double GetUsageAmount(DataTable dt)
		{
			double price = 0;

			foreach (DataRow dr in dt.Rows)
			{
				price = price
					+ (double)dr["consumption_amount"] // 消費電力量
					+ (double)dr["purchased_amount"]   // 買電電力量
					+ (double)dr["discharge_amount"];  // 放電電力量
			}

			// 切り捨て
			return (double)((int)price);
		}

		public static double GetPrice1(int usageAmount, double coef)
		{
			if (usageAmount > 120)
			{
				usageAmount = 120;
			}

			return usageAmount * coef;
		}

		public static double GetPrice2(int usageAmount, double coef)
		{
			if (usageAmount <= 120)
			{
				return 0;
			}

			if (usageAmount > 300)
			{
				usageAmount = 300;
			}

			return (usageAmount - 120) * coef;
		}

		public static double GetPrice3(int usageAmount, double coef)
		{
			if (usageAmount <= 300)
			{
				return 0;
			}

			return (usageAmount - 300) * coef;
		}

		public static double GetAdjustPrice(int usageAmount, double coef)
		{
			return usageAmount * coef;
		}

		public static double GetDiscountPrice(DataRow dr, double reEnergyCharge, double coef)
		{
			return -(
				(double)dr["basic_price"]
				+ (double)dr["price1"]
				+ (double)dr["price2"]
				+ (double)dr["price3"]
				+ (double)dr["adjust_price"]
				+ reEnergyCharge) * coef;
		}

		public static double GetReEnergyCharge(int usageAmount, double coef)
		{
			return (double)(int)(usageAmount * coef);
		}

		public static double GetTotalCost(DataRow dr)
		{
			double totalCost = (double)dr["basic_price"]
				+ (double)dr["price1"]
				+ (double)dr["price2"]
				+ (double)dr["price3"]
				+ (double)dr["adjust_price"]
				+ (double)dr["discount_price"]
				+ (long)dr["re_energy_charge"];

			return (double)(int)totalCost;
		}
	}
}
