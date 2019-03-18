using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        /// <summary>
        /// 标识列
        /// </summary>
        public int LeavelCost_Id { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int LeavelCost_Level { get; set; }
        /// <summary>
        /// 元/天
        /// </summary>
        public double LevelCost_Money { get; set; }
    }
}
