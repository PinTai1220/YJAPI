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
    public class MoneyrecordBLL : IDataservices<Moneyrecord, MoneyrecordBLL>
    {
        IDataservices<Moneyrecord, MoneyrecordDAL> dal = MoneyrecordDAL.GetInstance();
        public override int Create(Moneyrecord t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Moneyrecord> Show()
        {
            return dal.Show();
        }

        public override Moneyrecord ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Moneyrecord t)
        {
            return dal.Update(t);
        }
    }
}
