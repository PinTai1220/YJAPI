using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    //用户表
    public class Users
    {
        public int user_Id { get; set; }//标识列  主键
        public string user_Phone { get; set; }//手机号
        public string user_Pwd { get; set; }//密码
        public string user_PhotoUrl { get; set; }//用户头像路径
        public int user_wx_Id { get; set; }//微信号Id
        public string user_wx_Name { get; set; }//微信名
        public string user_wx_PhotoUrl { get; set; }//微信头像
        public int user_wx_Sex { get; set; }//微信性别
        public string user_wx_Country { get; set; }//微信用户国家
        public string user_Type { get; set; }//用户类型
        public float user_Backmoey { get; set; }//退回金额
    }
}
