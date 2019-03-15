using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    /// <summary>
    /// 金额记录表
    /// </summary>
    public class Moneyrecord
    {
        public int moneyrecord_Id { get; set; }//主键
        public int moneyrecord_Userid { get; set; }//User表外键
        public int moneyrecord_Record { get; set; }//金钱流水记录
        public string monevrecord_Time { get; set; }//时间
    }
}
