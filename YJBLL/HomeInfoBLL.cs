using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJModel;
using YJCommon;
using YJDAL;

namespace YJBLL
{
    public class HomeInfoBLL : IDataservices<HomeInfo, HomeInfoBLL>
    {
        IDataservices<HomeInfo, HomeInfoDAL> dal = HomeInfoDAL.GetInstance();
        public override int Create(HomeInfo t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<HomeInfo> Show()
        {
            return dal.Show();
        }

        public override HomeInfo ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(HomeInfo t)
        {
            return dal.Update(t);
        }
        public dynamic ShowBySome(int pageindex, int pagesize)
        {
            HomeInfoDAL hdal = dal as HomeInfoDAL;
            return hdal.ShowBySome(pageindex, pagesize);
        }
    }
}
