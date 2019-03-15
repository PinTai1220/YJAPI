using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJDAL;
using YJModel;
using YJCommon;

namespace YJBLL
{
    public class LevelcostBLL:IDataservices<Levelcost,LevelcostBLL>
    {
        IDataservices<Levelcost, LevelcostDAL> dal = LevelcostDAL.GetInstance();
        public override int Create(Levelcost t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Levelcost> Show()
        {
            return dal.Show();
        }

        public override Levelcost ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Levelcost t)
        {
            return dal.Update(t);
        }
    }
}
