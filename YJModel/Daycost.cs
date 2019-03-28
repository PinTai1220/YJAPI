using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    /// <summary>
    /// 付费规则表(天)
    /// </summary>
    [Table("Daycost")]
    public class Daycost
    {
        [Key]
        /// <summary>
        /// 标识列
        /// </summary>
        public int DayCost_Id { get; set; }
        /// <summary>
        /// 多少元/天
        /// </summary>
        public double DayCost_Money { get; set; }
    }
}
