using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    /// <summary>
    /// 开发商申请记录
    /// </summary>
    class Developers_apply_for
    {
        [Key]
        public int developers_Id { get; set; }//主键
        public int developers_Userid { get; set; }//User表外键id
        public string developers_Photopath { get; set; }//图片材料路径
        public string developers_Info { get; set; }//申请时间
        public string developers_Time { get; set; }//添加时间
    }
}
