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
				SqlType.Select => DBConsts.SELECT_XML,
				SqlType.Insert => DBConsts.REGISTRATION_XML,
				_ => string.Empty,
			};
		}

		public static string GetSelectSqlStatement(SqlType sqlType, string id)
		{
			XElement xml = XElement.Load(string.Join(@"\", [Environment.CurrentDirectory, DBConsts.QUERY_PATH, GetTargetXml(sqlType)]));
			var sql = from item in xml.Elements(DBConsts.SQL_TAG_NAME)
								where item?.Attribute(DBConsts.ATTRIBUTE_ID)?.Value == id
								select item.Value;
			return sql.First().ToString() ?? "";
		}
	}
}
