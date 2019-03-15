using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    /// <summary>
    /// 等级付费规则
    /// </summary>
    public class Levelcost
    {
        public int levelcost_Id { get; set; }//主键
        public int levelcost_Level { get; set; }//等级
        public float levelcost_Money { get; set; }//元/天
    }
}
