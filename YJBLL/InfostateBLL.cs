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
    public class InfostateBLL : IDataservices<Infostate, InfostateBLL>
    {
        IDataservices<Infostate, InfostateDAL> dal = InfostateDAL.GetInstance();
        public override int Create(Infostate t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Infostate> Show()
        {
            return dal.Show();
        }

        public override Infostate ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Infostate t)
        {
            return dal.Update(t);
        }
    }
}
