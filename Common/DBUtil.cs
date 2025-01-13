using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			switch (sqlType)
			{
				case SqlType.Select:
					return "select.xml";
				case SqlType.Insert:
					return "registration.xml";
				default:
					return String.Empty;
			}
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
