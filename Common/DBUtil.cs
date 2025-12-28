using System.Xml.Linq;

namespace sim4solar.Common
{
	internal static class DBUtil
	{
		public enum SqlType
		{
			Select,
			Insert,
			Update,
			Delete
		}

		private static string GetTargetXml(SqlType sqlType)
		{
			return sqlType switch
			{
				SqlType.Select => "select.xml",
				SqlType.Insert => "registration.xml",
				_ => string.Empty,
			};
		}

		public static string GetSelectSqlStatement(SqlType sqlType, string id)
		{
			XElement xml = XElement.Load(Environment.CurrentDirectory + @"\Query\" + GetTargetXml(sqlType));
			var sql = from item in xml.Elements("sql")
					  where item?.Attribute("id")?.Value == id
					  select item.Value;
			return sql.First().ToString() ?? "";
		}
	}
}
