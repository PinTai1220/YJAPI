using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJModel;
using YJCommon;

namespace YJDAL
{
    public class UsersDAL : IDataservices<Users, UsersDAL>
    {
        public override int Create(Users t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Users.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Users.Remove(db.Users.Where(c => c.user_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Users> Show()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Users.ToList();
            }
        }

        public override Users ShowById(int id)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Users.ToList().Where(c => c.user_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Users t)
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Users>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
