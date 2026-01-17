namespace sim4solar.Common
{
	/// <summary>
	/// Common Consts Class
	/// </summary>
	internal static class Consts
	{
		/// <summary>
		/// 電気量料金 1段階目 閾値
		/// </summary>
		public const int THRESHOLD_1ST = 120;

		/// <summary>
		/// 電気量料金 2段階目 閾値
		/// </summary>
		public const int THRESHOLD_2ND = 300;

		/// <summary>
		/// 割引係数
		/// </summary>
		public const double DISCOUNT_COEFFICIENT = 0.005;

		/// <summary>
		/// FIT単価
		/// </summary>
		public const decimal FIT = 8.5M;
	}
}