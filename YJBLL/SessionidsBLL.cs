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
    public class SessionidsBLL : IDataservices<Sessionids, SessionidsBLL>
    {
        IDataservices<Sessionids, SessionidsDAL> dal = SessionidsDAL.GetInstance();
        public override int Create(Sessionids t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Sessionids> Show()
        {
            return dal.Show();
        }

        public override Sessionids ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Sessionids t)
        {
            return dal.Update(t);
        }
    }
}
