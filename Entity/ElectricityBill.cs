namespace sim4solar.Entity
{
	internal class ElectricityBill
	{
		/// <summary>
		/// 請求年
		/// </summary>
		public const string YEAR = "year";

		/// <summary>
		///	請求月
		/// </summary>
		public const string MONTH = "month";

		/// <summary>
		///	電気料金合計
		/// </summary>
		public const string TOTAL_COST = "total_cost";

		/// <summary>
		/// 基本料金
		/// </summary>
		public const string BASIC_PRICE = "basic_price";

		/// <summary>
		/// 電力量料金1
		/// </summary>
		public const string PRICE1 = "price1";

		/// <summary>
		/// 電力量料金2
		/// </summary>
		public const string PRICE2 = "price2";

		/// <summary>
		///	電力量料金3
		/// </summary>
		public const string PRICE3 = "price3";

		/// <summary>
		/// 燃料費調整額
		/// </summary>
		public const string ADJUST_PRICE = "adjust_price";

		/// <summary>
		/// セット割引額等
		/// </summary>
		public const string DISCOUNT_PRICE = "discount_price";

		/// <summary>
		/// 再エネ促進賦課金
		/// </summary>
		public const string RE_ENERGY_CHARGE = "re_energy_charge";

		/// <summary>
		///	使用期間From
		/// </summary>
		public const string USAGE_PERIOD_FROM = "usage_period_from";

		/// <summary>
		///	使用期間To
		/// </summary>
		public const string USAGE_PERIOD_TO = "usage_period_to";

		/// <summary>
		///	使用量[kWh]
		/// </summary>
		public const string USAGE_AMOUNT = "usage_amount";
	}
}
