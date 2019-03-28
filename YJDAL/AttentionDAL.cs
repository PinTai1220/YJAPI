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

        public override int Create(Attention t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Attention.Add(t);
                return db.SaveChanges();
            }
        }
        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Attention.Remove(db.Attention.Where(c => c.Attention_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }
        public override List<Attention> Show()
        {
            using (DataContext db = new DataContext())
            {
              db.Database.CreateIfNotExists();
              return  db.Attention.Include("HomeInfo").ToList();
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
