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
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Attention.Remove(db.Attention.Where(c => c.Attention_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }
        public override List<Attention> Show()
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
              return  db.Attention.ToList();
            }
        }

        public override Attention ShowById(int id)
        {
            throw new NotImplementedException();
        }

        public override int Update(Attention t)
        {
            throw new NotImplementedException();
        }
    }
}
