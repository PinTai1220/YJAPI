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
        /// <summary>
        /// 标识列
        /// </summary>
        /// 
        [Key]
        public int SessionId_Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [ForeignKey("UserInfo")]
        public int SessionId_UserId { get; set; }
        public Users UserInfo { get; set; }
        /// <summary>
        /// 应用服务器分配给用户的sessionId
        /// </summary>
        public int SessionId_SessionId { get; set; }
    }
}
