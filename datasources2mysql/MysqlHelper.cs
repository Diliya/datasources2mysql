using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.IO;

namespace datasources2mysql
{
    public class MysqlHelper
    {
        /// <summary>
        /// MySqlHelper操作类
        /// </summary>
        
            /// <summary>
            /// 批量操作每批次记录数
            /// </summary>
            public static int BatchSize = 2000;

            /// <summary>
            /// 超时时间
            /// </summary>
            public static int CommandTimeOut = 600;


            #region 私有变量
            private const string defaultConfigKeyName = "MySqlConnection";//连接字符串 Database='数据库';Data Source='IP地址';User Id='sa';Password='sa';pooling=true
            private string connectionString;
            private string providerName;
            

            #endregion

            #region 构造函数

            /// <summary>
            /// 默认构造函数(DbHelper)
            /// </summary>
            public void MySqlDbHelper()
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[defaultConfigKeyName].ConnectionString;
                this.providerName = ConfigurationManager.ConnectionStrings[defaultConfigKeyName].ProviderName;
            }

            /// <summary>
            /// DbHelper构造函数
            /// </summary>
            /// <param name="keyName">连接字符串名</param>
            public void MySqlDbHelper(string keyName)
            {
                this.connectionString = ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
                this.providerName = ConfigurationManager.ConnectionStrings[keyName].ProviderName;
            }

            #endregion

            public int ExecuteNonQuery(string sql, params  MySqlParameter[] parameters)
            {
                int res = 0;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        try
                        {
                            res = cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            res = -1;
                        }
                    }
                }
                return res;
            }

            public object GetExeScalar(string sql, params MySqlParameter[] parameters)
            {
                object res = null;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        res = cmd.ExecuteScalar();
                    }
                }
                return res;
            }

            public DataTable GetDataTable(string sql, params MySqlParameter[] parameters)
            {
                DataSet dataset = new DataSet();
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dataset);
                    }
                }
                return dataset.Tables[0];
            }
            /// <summary>
            /// 在Mysql数据库中新建表，为datatable插入数据做准备
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>
            //public static void CreateByDataTable(string connectionString, string tableName,string[] tableHead)
            //{
            //    using (MySqlConnection con = new MySqlConnection(connectionString))
            //    {

            //        con.Open();
            //        StringBuilder sb = new StringBuilder();
            //        //sb.Append("INSERT INTO " + dataTable.TableName + "(");
            //        sb.Append("CREATE TABLE "+tableName+"(");
            //        foreach (string i in tableHead)
            //        {
            //            sb.Append(i);
            //        }
            //        sb.Append(");");

            //        //MySqlCommand cmd = new MySqlCommand(sb.ToString(), con)
            //        //{

            //        //}
            //    }
            //}

            /// <summary>
            /// DataTable批量加入MYSQL数据库
            /// </summary>
            /// <param name="dataTable"></param>
            /// <returns></returns>

            public static string InsertByDataTable(string connectionString, DataTable dataTable)
            {
                string result = string.Empty;
                if (null == dataTable || dataTable.Rows.Count <= 0)
                {
                    return string.Format("添加失败！{0}暂无数据！", dataTable.TableName);
                }
                //if (string.IsNullOrEmpty(dataTable.TableName))
                //{
                //    return "添加失败！请先设置DataTable的名称！";
                //}
                //构建INSERT语句
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO " + dataTable.TableName + "(");
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sb.Append(dataTable.Columns[i].ColumnName + ",");
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append(") VALUES ");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sb.Append("(");
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        sb.Append("'" + dataTable.Rows[i][j] + "',");
                    }
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("),");
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append(";");
                int res = -1;
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), con))
                    {
                        try
                        {
                            res = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res = -1;
                            // Unknown column 'names' in 'field list' 
                            result = "操作失败！" + ex.Message.Replace("Unknown column", "未知列").Replace("in 'field list'","存在字段集合中！");
                        }
                    }
                }

                int insertCount = 0;
                
                if (insertCount > 0)
                {
                    result = string.Format("{0}添加成功!",dataTable.TableName);
                }
                return result;
            }

        




            internal static string CsvToMysql(string connectionString, string tableNmae, string csvPath, string[] tableHead)
            {
                //throw new NotImplementedException();
                //将csv文件数据转入mysql
                int n = 0;
                try
                {
                    
                    //导入csv
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        MySqlCommand sqlCmd = new MySqlCommand(string.Format("TRUNCATE TABLE `{0}`",tableNmae), con);
                        sqlCmd.ExecuteNonQuery();
                        //MySqlCommand sqlCmd = new MySqlCommand(string.Format("LOAD DATA INFILE '{0}' INTO TABLE {1};", f.ToString(),
                        //    f.ToString().Substring(0, f.ToString().Length - 4)), con);
                        ////string str = sqlCmd.ExecuteReader();
                        //n = sqlCmd.ExecuteNonQuery();
                        MySqlBulkLoader bulkLoader = new MySqlBulkLoader(con);
                        
                        bulkLoader.TableName = tableNmae; //插入的表的名字
                        bulkLoader.FileName = csvPath + "\\" + tableNmae+".csv"; //文件的完整路径；先要把数据写入到csv中
                        
                        bulkLoader.FieldTerminator = ",";//这个地方字段间的间隔方式，为逗号
                        n = bulkLoader.Load();//这个地方是执行
                        con.Close();
                    }
                }
                catch 
                {
                    //建立表
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("CREATE TABLE " + tableNmae + "(" + tableHead[0] + " Text");
                        for (int t = 1; t < 10; t++)
                        {
                            sb.Append("," + tableHead[t] + " Text");
                        }
                        sb.Append(");");
                        MySqlCommand sqlCmd = new MySqlCommand(sb.ToString(), con);

                        sqlCmd.ExecuteNonQuery();

                        con.Close();
                        return "retry";
                    }
                }
                finally
                {

                }
                return string.Format("{0}添加成功!共插入{1}数据。", tableNmae, n.ToString());
            
            }


    }
}
