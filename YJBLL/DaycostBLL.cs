using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJModel;
using YJDAL;
using YJCommon;

namespace YJBLL
{
    public class DaycostBLL : IDataservices<Daycost, DaycostBLL>
    {
        IDataservices<Daycost, DaycostDAL> dal = DaycostDAL.GetInstance();
        public override int Create(Daycost t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Daycost> Show()
        {
            return dal.Show();
        }

        public override Daycost ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Daycost t)
        {
            return dal.Update(t);
        }
    }
}
