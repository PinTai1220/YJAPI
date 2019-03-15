using System;
using System.Collections.Generic;
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
        public int infostate_Id { get; set; }//标识列  主键
        public int infostate_Homeinfoid { get; set; }//外键 HomeInfo表Id
        public int infostate_Start { get; set; }//开始时间(yyyy-MM-dd hh:mm:ss)
        public int infostate_Level { get; set; }//上挂等级
        public int infostate_Continuou { get; set; }//持续时间
        public string infostate_Time { get; set; }//续费时间
        public int infostate_State { get; set; }//状态(0过期，1正常)
    }
}
