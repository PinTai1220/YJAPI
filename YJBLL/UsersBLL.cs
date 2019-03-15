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
    public class UsersBLL : IDataservices<Users, UsersBLL>
    {
        IDataservices<Users, UsersDAL> dal = UsersDAL.GetInstance();
        public override int Create(Users t)
        {
            return dal.Create(t);
        }

        public override int Delete(int id)
        {
            return dal.Delete(id);
        }

        public override List<Users> Show()
        {
            return dal.Show();
        }

        public override Users ShowById(int id)
        {
            return dal.ShowById(id);
        }

        public override int Update(Users t)
        {
            return dal.Update(t);
        }
    }
}
