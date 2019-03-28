using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{ 
    [Table("Attention")]
    public class Attention
    {
        [Key]
        public int Attention_Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int Attention_Uid { get; set; }
        /// <summary>
        /// 关注的信息id集合字符串（1,2,3...）
        /// </summary>
        [ForeignKey("HomeInfo")]
        public int Attention_Infoids { get; set; }

        public HomeInfo HomeInfo { get; set; }

    }
}
