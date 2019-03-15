using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJCommon;
using YJModel;

namespace YJDAL
{
    public class DaycostDAL : IDataservices<Daycost, DaycostDAL>
    {
        public override int Create(Daycost t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Daycosts.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Daycosts.Remove(db.Daycosts.Where(s => s.daycost_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Daycost> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Daycosts.ToList();
            }
        }

        public override Daycost ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Daycosts.ToList().Where(c => c.daycost_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Daycost t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Daycost>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
