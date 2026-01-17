namespace sim4solar.Entity
{
	internal class PowerGenerationResults
	{
		/// <summary>
		/// 対象年月日
		/// </summary>
		public const string TARGET_DATE = "target_date";

		/// <summary>
		/// 発電電力量[kWh]
		/// </summary>
		public const string GENERATE_AMOUNT = "generate_amount";

		/// <summary>
		/// 消費電力量[kWh]
		/// </summary>
		public const string CONSUMPTION_AMOUNT = "consumption_amount";

		/// <summary>
		/// 売電電力量[kWh]
		/// </summary>
		public const string SALES_AMOUNT = "sales_amount";

		/// <summary>
		/// 買電電力量[kWh]
		/// </summary>
		public const string PURCHASED_AMOUNT = "purchased_amount";

		/// <summary>
		/// 充電電力量[kWh]
		/// </summary>
		public const string CHARGE_AMOUNT = "charge_amount";

		/// <summary>
		/// 放電電力量[kWh]
		/// </summary>
		public const string DISCHARGE_AMOUNT = "discharge_amount";

		/// <summary>
		/// 開始日（検索条件として利用）
		/// </summary>
		public const string SEARCH_START_DATE = "start";

		/// <summary>
		/// 終了日（検索条件として利用）
		/// </summary>
		public const string SEARCH_END_DATE = "end";
	}
}
