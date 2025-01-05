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
		private const string DB_FILENAME = "sim4solar.db";

		private static String GetConnectionString()
		{
			return "DataSource=" + Environment.CurrentDirectory + "\\" + DB_FILENAME;
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
			XElement xml = XElement.Load(Environment.CurrentDirectory + "\\" + @"Query\initialize.xml");
			var ddlScripts = from item in xml.Elements("sql")
											 select item.Value;

			foreach (var script in ddlScripts)
			{
				var sql = script.ToString();
				CreateTable(sql);
			}
		}

		private static int CreateTable(String sql)
		{
			return ExecuteNonQuery(sql, null);
		}

		/// <summary>
		/// Insert Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Insert(String sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		/// <summary>
		/// Update Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Update(String sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		/// <summary>
		/// Delete Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Effected Rows Count</returns>
		public static int Delete(String sql, Array? parameters)
		{
			return ExecuteNonQuery(sql, parameters);
		}

		private static int ExecuteNonQuery(String sql, Array? parameters)
		{
			using (var con = new SqliteConnection(GetConnectionString()))
			{
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
		}

		/// <summary>
		/// SELECT Data
		/// </summary>
		/// <param name="sql">SQL</param>
		/// <returns>Result Data</returns>
		public static DataTable Select(String sql)
		{
			return GetData(sql, null);
		}

		/// <summary>
		/// SELECT Statement
		/// </summary>
		/// <param name="sql">SQL Statement</param>
		/// <param name="parameters">Query Parameters</param>
		/// <returns>Result Data</returns>
		public static DataTable Select(String sql, Array parameters)
		{
			return GetData(sql, parameters);
		}

		private static DataTable GetData(String sql, Array? parameters)
		{
			using (var con = new SqliteConnection(GetConnectionString()))
			{
				try
				{
					con.Open();

					SqliteCommand cmd = GetCommand(con, sql, parameters);
					SqliteDataReader dr = cmd.ExecuteReader();

					DataTable dt = new DataTable();
					dt.Load(dr);
					return dt;
				}
				finally
				{
					con.Close();
				}
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
