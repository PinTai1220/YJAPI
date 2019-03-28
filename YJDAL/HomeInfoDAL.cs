using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJModel;
using YJCommon;
using System.Data.SqlClient;

namespace YJDAL
{
    public class HomeInfoDAL : IDataservices<HomeInfo, HomeInfoDAL>
    {
        public override int Create(HomeInfo t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.HomeInfo.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.HomeInfo.Remove(db.HomeInfo.Where(c => c.HomeInfo_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<HomeInfo> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.HomeInfo.Include("UserInfo").ToList();
            }
        }

        public override HomeInfo ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.HomeInfo.Include("UserInfo").Where(c => c.HomeInfo_Id == id).FirstOrDefault();
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
        public dynamic ShowBySome(int pageindex, int pagesize)
        {
            SqlParameter pindex = new SqlParameter("pageindex", System.Data.SqlDbType.Int);
            pindex.Value = pageindex;
            SqlParameter psize = new SqlParameter("pagesize", System.Data.SqlDbType.Int);
            psize.Value = pageindex;
            SqlParameter pcount = new SqlParameter("pagecount", System.Data.SqlDbType.Int);
            pcount.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] parameters = { pindex, psize, pcount };
            var data = DBHelper.GetList_Proc<HomeInfo>("p_homeinfopage", parameters);
            int pc = Convert.ToInt32(pcount.Value);
            return new { pagecount = pc, data };
        }
    }
}
