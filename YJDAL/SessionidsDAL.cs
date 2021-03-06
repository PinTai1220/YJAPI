﻿using System;
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
                db.Sessionid.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                db.Sessionid.Remove(db.Sessionid.Where(c=>c.SessionId_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Sessionids> Show()
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Sessionid.Include("UserInfo").ToList();
            }
        }

        public override Sessionids ShowById(int id)
        {
            using (DataContext db=new DataContext())
            {
                db.Database.CreateIfNotExists();
                return db.Sessionid.Include("UserInfo").Where(c => c.SessionId_Id == id).FirstOrDefault();
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
