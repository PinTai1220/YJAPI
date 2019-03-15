using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    /// <summary>
    /// 付费规则表(天)
    /// </summary>
    public class Daycost
    {
        public int daycost_Id { get; set; }//主键
        public float daycost_Money { get; set; }//元/天
    }
}
