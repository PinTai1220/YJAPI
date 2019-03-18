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
    /// 开发商申请记录
    /// </summary>
    public class Developers_apply_for
    {
        [Key]
        /// <summary>
        /// 标识列
        /// </summary>
        public int Developers_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [ForeignKey("UserInfo")]
        public int Developers_UserId { get; set; }
        public Users UserInfo { get; set; }
        /// <summary>
        /// 图片材料路径
        /// </summary>
        public string Developers_PhotoPath { get; set; }
        /// <summary>
        /// 申请信息
        /// </summary>
        public string Developers_Info { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string Developers_TimeG { get; set; }
    }
}
