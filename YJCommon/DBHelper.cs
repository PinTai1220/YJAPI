using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;  //  注意引用 NEWTONSOFT
using System.Configuration;

namespace YJCommon
{
    public  class DBHelper
    {
        //连接
        private static string connstr=ConfigurationManager.ConnectionStrings["conn"].ToString();
        public static SqlConnection conn = new SqlConnection(connstr);
        //执行添加删除修改
        public static int ExecuteNonQuery(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            int i=cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //查询首行首列
        public static object ExecuteScalar(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object i = cmd.ExecuteScalar();
            conn.Close();
            return i;
        }
        //查询多行多列
        public static SqlDataReader ExecuteReader(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr; 
        }

        //查询多行多列
        public static DataTable GetDataTable(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        //引用 newtownsoft 后 去掉注释
        public static List<T> GetList<T>(string sql)
        {
            DataTable dt = GetDataTable(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }
        public static List<T> GetList_Proc<T>(string procName, SqlParameter[] paras = null)
        {
            conn.Open();
            SqlCommand command = new SqlCommand(procName, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (paras != null)
            {
                command.Parameters.AddRange(paras);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            List<T> list = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(ds.Tables[0]));
            return list;
        }
        public static int ExecuteNonQuery_Proc(string procName, SqlParameter[] paras)
        {
            conn.Open();
            SqlCommand command = new SqlCommand(procName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(paras);

            int result = command.ExecuteNonQuery();
            conn.Close();

            return result;


        }
        public static int tran(List<string> sqlstrs)
        {
            conn.Open();
            int result=0;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            SqlTransaction transaction= command.Transaction;
            conn.BeginTransaction();
            try
            {
                foreach (string item in sqlstrs)
                {
                    command.CommandText = item;
                    result+= command.ExecuteNonQuery();
                }
                return result;
            }
            catch(SqlException)
            {
                result = 0;
                return result;
            }
            catch (Exception)
            {
                result = 0;
                return result;
            }
            conn.Close();
        }
    }
}
