using Microsoft.Data.Sqlite;
using System.Data;
using System.Xml.Linq;

namespace sim4solar.Common
{
	/// <summary>
	/// DB Access Class
	/// </summary>
	internal static class DBAccess
	{

		private static String GetConnectionString()
		{
			return "DataSource=" + Environment.CurrentDirectory + @"\" + DBConsts.DB_FILE_NAME;
		}

		/// <summary>
		/// Initialize Database
		/// </summary>
		public static void InitializeDatabase()
		{
			CreateTable();
		}

		private static void CreateTable()
		{
			XElement xml = XElement.Load(string.Join(@"\", [Environment.CurrentDirectory, DBConsts.QUERY_PATH, DBConsts.INITIALIZE_XML]));
			var ddlScripts = from item in xml.Elements(DBConsts.SQL_TAG_NAME)
											 select item.Value;

			foreach (var script in ddlScripts)
			{
				var sql = script.ToString();
				CreateTable(sql);
			}
		}

		private static int CreateTable(string sql)
		{
			return ExecuteNonQuery(sql, null);
		}

		/// <summary>
		/// Insert Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Insert(string sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		/// <summary>
		/// Update Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Update(string sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		/// <summary>
		/// Delete Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Delete(string sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		private static int ExecuteNonQuery(string sql, Array? parameters)
		{
			using var con = new SqliteConnection(GetConnectionString());
			try
			{
				con.Open();

				SqliteCommand cmd = GetCommand(con, sql, parameters);
				return cmd.ExecuteNonQuery();
			}
			finally
			{
				con.Close();
			}
		}

		/// <summary>
		/// SELECT Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <returns>Result Data</returns>
		public static DataTable Select(string sql)
		{
			return GetData(sql, null);
		}

		/// <summary>
		/// SELECT Statement
		/// </summary>
		/// <param name="sql">SQL Statement</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Result Data</returns>
		public static DataTable Select(string sql, Array parameters)
		{
			return GetData(sql, parameters);
		}

		private static DataTable GetData(string sql, Array? parameters)
		{
			using var con = new SqliteConnection(GetConnectionString());
			try
			{
				con.Open();

				SqliteCommand cmd = GetCommand(con, sql, parameters);
				SqliteDataReader dr = cmd.ExecuteReader();

				DataTable dt = new();
				dt.Load(dr);
				return dt;
			}
			finally
			{
				con.Close();
			}
		}

		private static SqliteCommand GetCommand(SqliteConnection con, String sql, Array? parameters)
		{
			SqliteCommand cmd = con.CreateCommand();
			cmd.CommandText = sql;
			if (parameters != null)
			{
				cmd.Parameters.AddRange(parameters);
			}

			return cmd;
		}
	}
}
