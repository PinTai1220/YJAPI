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
    /// 信息状态表
    /// </summary>
    public class Infostate
    {
        [Key]
        /// <summary>
        /// 标识列
        /// </summary>
        public int InfoState_Id { get; set; }
        /// <summary>
        /// HomeInfo表Id
        /// </summary>
        [ForeignKey("HomeInfo")]
        public int InfoState_HomeInfoId { get; set; }
        public HomeInfo HomeInfo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int InfoState_Start { get; set; }
        /// <summary>
        /// 上挂等级
        /// </summary>
        public int InfoState_Level { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public int InfoState_Continuou { get; set; }
        /// <summary>
        /// 续费时间
        /// </summary>
        public string InfoState_Time { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int InfoState_State { get; set; }
    }
}
