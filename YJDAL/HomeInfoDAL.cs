using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJModel;
using YJCommon;

namespace YJDAL
{
    public class HomeInfoDAL : IDataservices<HomeInfo, HomeInfoDAL>
    {
        public override int Create(HomeInfo t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.HomeInfos.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.HomeInfos.Remove(db.HomeInfos.Where(c => c.HomeInfo_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<HomeInfo> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.HomeInfos.Include("UserInfo").ToList();
            }
        }

        public override HomeInfo ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.HomeInfos.Include("UserInfo").Where(c => c.HomeInfo_Id == id).FirstOrDefault();
            }
        }

        public override int Update(HomeInfo t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<HomeInfo>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
