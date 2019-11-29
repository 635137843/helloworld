using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtktkj.Station.DAL
{
    /// <summary>
    /// 工具类：数据库操作类
    /// Creator：何明鑫
    /// Date：2019/7/16
    /// </summary>
    public class SqlHelper
    {
        readonly static string SqlConnectionString = "server=.;database=satDB;uid=sa;pwd=sa123";

        /// <summary>
        /// 根据参数执行sql语句
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>影响数据的行数</returns>
        public static int ExecSql(string sqlStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 根据sql语句返回对应字段的值
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="fieldName">字段名</param>
        /// <returns>对应的字段值</returns>
        public static string GetValue(string sqlStr, string fieldName)
        {
            string returnValue = string.Empty;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(SqlConnectionString))
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlStr, conn);
                sqlDa.Fill(dt);
            }
            if (dt.Rows.Count != 0)
            {
                returnValue = dt.Rows[0][fieldName].ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>影响行数</returns>
        public static object RunSQL(string sql)
        {
            object runCount = 0;
            using (SqlConnection conn = new SqlConnection(SqlConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                runCount = cmd.ExecuteScalar();
                conn.Close();
            }
            return runCount;
        }

        /// <summary>
        /// 查询数据返回数据表
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>数据表</returns>
        public static DataTable ExecuteDataTable(string sqlStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(SqlConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStr;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                    sqa.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
