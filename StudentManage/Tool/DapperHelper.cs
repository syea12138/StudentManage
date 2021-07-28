using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public static class DapperHelper
    {
       public static string connMySQL = ConfigurationManager.AppSettings["MySQL"].ToString();//mysql
       public static string connSqlServer = ConfigurationManager.AppSettings["Local"].ToString();//sqlserver
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connType"></param>
        /// <returns></returns>
        public static IDbConnection GetConnection(string connType)
        {
            try
            {
                switch (connType)
                {
                    case "MySQL":
                        return new MySqlConnection(connMySQL);
                    case "SQLServer":
                        return new SqlConnection(connSqlServer);
                    default:
                        return new SqlConnection(connSqlServer);
                }
            }
            catch (Exception ex)
            {
               // LogHelper.ErrorLog(ex);
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="sqlType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Execute<T>(T model,string sqlType,string sql) where T : class
        {
            try
            {
                using (IDbConnection connection = GetConnection(sqlType))
                {
                    return connection.Execute(sql, model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        /// <summary>
        /// 无参查询所有数据
        /// </summary>
        /// <returns></returns>
        public static List<T> Query<T>(string sqlType, string sql) where T : class
        {
            try
            {
                using (IDbConnection connection = GetConnection(sqlType))
                {
                    return connection.Query<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 无参查询并返回DataTable
        /// </summary>
        /// <param name="sqlType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteReadder(string sqlType, string sql)
        {
            var dt = new DataTable();
            try
            {
                using (IDbConnection connection = GetConnection(sqlType))
                {
                    dt.Load(connection.ExecuteReader(sql));
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 无参查询并返回首行首列
        /// </summary>
        /// <param name="sqlType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetCount(string sqlType, string sql)
        {
            try
            {
                using (IDbConnection connection = GetConnection(sqlType))
                {
                     return Convert.ToInt32(DapperHelper.Query<String>(sqlType, sql)[0]);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }


        /// <summary>
        /// 查询指定数据
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<T> Query<T>(T model, string sqlType, string sql) where T:class
        {
            try
            {
                using (IDbConnection connection = GetConnection(sqlType))
                {
                    return connection.Query<T>(sql, model).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                //LogHelper.ErrorLog(ex);
                return null;
            }
        }

    }
}
