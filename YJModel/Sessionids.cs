using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YJModel
{
    //用户session表
    public class Sessionids
    {
        [Key]
        public int sessionid_Id { get; set; }//主键  标识列

        [ForeignKey("UserInfo")]
        public int sessionid_Userid { get; set; }//外键  用户Id
        public Users UserInfo { get; set; }
        public int sessionid_Sessionid { get; set; }//应用服务器分配给用户的sessionid
    }
}
