﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YJCommon;
using YJModel;

namespace YJDAL
{
    public class InfostateDAL : IDataservices<Infostate, InfostateDAL>
    {
        DataContext db = new DataContext();
        public override int Create(Infostate t)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Infostate.Add(t);
                return db.SaveChanges();
            }
        }

        public override int Delete(int id)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Infostate.Remove(db.Infostate.Where(c => c.InfoState_Id == id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public override List<Infostate> Show()
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                return db.Infostate.Include("HomeInfo").ToList();
            }
        }

        public override Infostate ShowById(int id)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                return db.Infostate.Include("HomeInfo").Where(c => c.InfoState_Id == id).FirstOrDefault();
            }
        }

        public override int Update(Infostate t)
        {
            using (db)
            {
                db.Database.CreateIfNotExists();
                db.Entry<Infostate>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
