using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJCommon;
using YJModel;
using YJDAL;

namespace YJBLL
{
    public class AttentionBLL : IDataservices<Attention, AttentionBLL>
    {
        IDataservices<Attention, AttentionDAL> dal = AttentionDAL.GetInstance();
        
        public override int Create(Attention t)
        {
            return dal.Create(t);
        }
        
        public override int Delete(int id)
        {
            return dal.Delete(id);
        }
        
        public override List<Attention> Show()
        {
            return dal.Show();
        }
        
        public override Attention ShowById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public override int Update(Attention t)
        {
            throw new NotImplementedException();
        }
    }
}
