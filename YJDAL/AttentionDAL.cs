using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJCommon;
using YJModel;

namespace YJDAL
{
    public class AttentionDAL: IDataservices<Attention, AttentionDAL>
    {
        DataContext db = new DataContext();

        public override int Create(Attention t)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Attention.Add(t);
                return db.SaveChanges();
            }
        }
        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public override List<Attention> Show()
        {
            throw new NotImplementedException();
        }

        public override Attention ShowById(int id)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                return db.Attention.Where(c => c.Attention_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Attention t)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Entry<Attention>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
