using sim4solar.Entity;
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
				price += (double)dr[PowerGenerationResults.CONSUMPTION_AMOUNT]; // 消費電力量
			}

			// 切り捨て
			return (int)price;
		}

		/// <summary>
		/// 電気量料金 1段階目の取得
		/// </summary>
		/// <param name="usageAmount">使用量[kWh]</param>
		/// <param name="coef">係数</param>
		/// <returns>電力量料金 1段階目</returns>
		public static double GetPrice1(int usageAmount, double coef)
		{
			if (usageAmount > Consts.THRESHOLD_1ST)
			{
				usageAmount = Consts.THRESHOLD_1ST;
			}

			return usageAmount * coef;
		}

		/// <summary>
		/// 電力量料金 2段階目の取得
		/// </summary>
		/// <param name="usageAmount">使用量[kWh]</param>
		/// <param name="coef">係数</param>
		/// <returns>電力量料金 2段階目</returns>
		public static double GetPrice2(int usageAmount, double coef)
		{
			if (usageAmount <= Consts.THRESHOLD_1ST)
			{
				return 0;
			}

			if (usageAmount > Consts.THRESHOLD_2ND)
			{
				usageAmount = Consts.THRESHOLD_2ND;
			}

			return (usageAmount - Consts.THRESHOLD_1ST) * coef;
		}

		/// <summary>
		/// 電力量料金 3段階目の取得
		/// </summary>
		/// <param name="usageAmount">使用量[kWh]</param>
		/// <param name="coef">係数</param>
		/// <returns>電力量料金 3段階目</returns>
		public static double GetPrice3(int usageAmount, double coef)
		{
			if (usageAmount <= Consts.THRESHOLD_2ND)
			{
				return 0;
			}

			return (usageAmount - Consts.THRESHOLD_2ND) * coef;
		}

		/// <summary>
		/// 燃料費調整額の取得
		/// </summary>
		/// <param name="usageAmount">使用量[kWh]</param>
		/// <param name="coef">係数</param>
		/// <returns></returns>
		public static double GetAdjustPrice(int usageAmount, double coef)
		{
			return usageAmount * coef;
		}

		/// <summary>
		/// セット割引額等の取得
		/// </summary>
		/// <param name="dr">基準データ</param>
		/// <returns></returns>
		public static int GetDiscountPrice(DataRow dr)
		{
			return GetDiscountPrice(
				(double)dr[ElectricityBill.BASIC_PRICE],
				(double)dr[ElectricityBill.PRICE1],
				(double)dr[ElectricityBill.PRICE2],
				(double)dr[ElectricityBill.PRICE3],
				(double)dr[ElectricityBill.ADJUST_PRICE]);
		}

		public static int GetDiscountPrice(double basicPrice, double price1, double price2, double price3, double adjustPrice)
		{
			return - (int)Math.Truncate((
				basicPrice
				+ price1
				+ price2
				+ price3
				+ adjustPrice) * Consts.DISCOUNT_COEFFICIENT);
		}

		/// <summary>
		/// 再エネ促進賦課金の取得
		/// </summary>
		/// <param name="usageAmount">使用量[kWh]</param>
		/// <param name="coef">係数</param>
		/// <returns>再エネ促進賦課金</returns>
		public static double GetReEnergyCharge(int usageAmount, double coef)
		{
			return (int)(usageAmount * coef);
		}

		/// <summary>
		/// 合計金額の取得
		/// </summary>
		/// <param name="dr">算定基準データ</param>
		/// <returns>合計金額</returns>
		public static double GetTotalCost(DataRow dr)
		{
			return GetTotalCost(
				(double)dr[ElectricityBill.BASIC_PRICE],
				(double)dr[ElectricityBill.PRICE1],
				(double)dr[ElectricityBill.PRICE2],
				(double)dr[ElectricityBill.PRICE3],
				(double)dr[ElectricityBill.ADJUST_PRICE],
				(double)dr[ElectricityBill.DISCOUNT_PRICE],
				(long)dr[ElectricityBill.RE_ENERGY_CHARGE]);
		}

		public static double GetTotalCost(double basicPrice, double price1, double price2, double price3, double adjustPrice, double discountPrice, long reEnergyCharge)
		{
			double totalCost = basicPrice
				+ price1
				+ price2
				+ price3
				+ adjustPrice
				+ discountPrice
				+ reEnergyCharge;

			return (int)totalCost;
		}
	}
}
