using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJModel;
using YJCommon;

namespace YJDAL
{
    
    public class LevelcostDAL : IDataservices<Levelcost, LevelcostDAL>
    {
        public override int Create(Levelcost t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Levelcost.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext()) {
                db.Database.CreateIfNotExists();
                db.Levelcost.Remove(db.Levelcost.Where(c => c.LeavelCost_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Levelcost> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Levelcost.ToList();
            }
        }

        public override Levelcost ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Levelcost.ToList().Where(c=>c.LeavelCost_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Levelcost t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Levelcost>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
