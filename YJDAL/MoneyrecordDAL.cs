using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJModel;
using YJCommon;

namespace YJDAL
{
    public class MoneyrecordDAL : IDataservices<Moneyrecord, MoneyrecordDAL>
    {
        public override int Create(Moneyrecord t)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Moneyrecords.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Moneyrecords.Remove(db.Moneyrecords.Where(c=>c.moneyrecord_Id==id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Moneyrecord> Show()
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Moneyrecords.ToList();
            }
        }

        public override Moneyrecord ShowById(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Moneyrecords.ToList().Where(c => c.moneyrecord_Id == id).FirstOrDefault();
                
            }
        }

        public override int Update(Moneyrecord t)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Moneyrecord>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
