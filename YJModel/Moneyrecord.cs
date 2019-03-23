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
    /// 金额记录表
    /// </summary>
    [Table("Moneyrecord")]
    public class Moneyrecord
    {

        /// <summary>
        /// 标识列
        /// </summary>
        /// 
        [Key]
        public int MoneyRecord_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        /// 
        [ForeignKey("UserInfo")]
        public int MoneyRecord_UserId { get; set; }
        public Users UserInfo { get; set; }
        /// <summary>
        /// 金钱流水记录
        /// </summary>
        public int MoneyRecord_Record { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string MoneyRecord_Time { get; set; }
    }
}
