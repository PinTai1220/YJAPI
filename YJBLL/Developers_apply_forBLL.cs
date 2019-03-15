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
    public class Developers_apply_forBLL : IDataservices<Developers_apply_for, Developers_apply_forBLL>
    {
        IDataservices<Developers_apply_for, Developers_apply_forDAL> dal = Developers_apply_forDAL.GetInstance();

        public override int Create(Developers_apply_for t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Developers_apply_for> Show()
        {
            return dal.Show();
        }

        public override Developers_apply_for ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Developers_apply_for t)
        {
            return dal.Update(t);
        }
    }
}
