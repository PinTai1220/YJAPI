using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJCommon;
using YJModel;

namespace YJDAL
{
    public class Developers_apply_forDAL : IDataservices<Developers_apply_for, Developers_apply_forDAL>
    {
        public override int Create(Developers_apply_for t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Developers_Apply_For.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Developers_Apply_For.Remove(db.Developers_Apply_For.Where(s => s.Developers_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Developers_apply_for> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Developers_Apply_For.Include("UserInfo").ToList();
            }
        }

        public override Developers_apply_for ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Developers_Apply_For.Include("UserInfo").ToList().Where(c => c.Developers_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Developers_apply_for t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Developers_apply_for>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
