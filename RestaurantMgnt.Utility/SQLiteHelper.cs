using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMgnt.Utility
{
    public class SQLiteHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["RestaurantMgnt"].ConnectionString;

        /// <summary>
        /// 获取受影响行数
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddRange(sp);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        public static object ExecuteScalar(string sql,params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add(sp);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 获取结果集
        /// </summary>
        public static DataTable GetDataTable(string sql,params SQLiteParameter[] sp)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);//适配器
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(sp);
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
