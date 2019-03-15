using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJModel;
using YJCommon;

namespace YJDAL
{
    public class SessionidsDAL : IDataservices<Sessionids, SessionidsDAL>
    {
        public override int Create(Sessionids t)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Sessionids.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Sessionids.Remove(db.Sessionids.Where(c=>c.sessionid_Id==id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Sessionids> Show()
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Sessionids.ToList();
            }
        }

        public override Sessionids ShowById(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Sessionids.Where(c => c.sessionid_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Sessionids t)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Sessionids>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
