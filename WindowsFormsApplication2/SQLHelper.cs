using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication2
{
    //数据库操作类
    class SQLHelper
    {
        //数据库服务器
        private string strCon = "Server=昔景;User= sa;Pwd=qingfeng;DataBase=SKHS";
        
        //数据库操作参数
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        SqlDataReader sqldr;
        //设置sql语句
        public string setsql(string str)
        {
            return str;
        }

        //构造函数
        public SQLHelper()
        {
            sqlcon = new SqlConnection(strCon);
            sqlcmd = new SqlCommand();
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            sqlcmd.Connection = sqlcon;
        }
        //数据库查询
        public ArrayList sqlRead()
        {
            sqlcmd.CommandText = setsql("select * from TB_DOCTOR_ADVICE");
            sqldr = sqlcmd.ExecuteReader();
            ArrayList list = new ArrayList();
            sqldr.Read();
            for (int i = 0; i < sqldr.FieldCount; i++)
            {
                list.Add(sqldr[i]);
            }
                return list;
        }
    }
}
