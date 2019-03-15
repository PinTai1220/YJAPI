using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJModel;

namespace YJDAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=conn")
        { }
        public DbSet<Daycost> Daycosts { get; set; }
        public DbSet<Developers_apply_for> Developers_Apply_Fors { get; set; }
        public DbSet<HomeInfo> HomeInfos { get; set; }
        public DbSet<Infostate> Infostates { get; set; }
        public DbSet<Levelcost> Levelcosts { get; set; }
        public DbSet<Moneyrecord> Moneyrecords { get; set; }
        public DbSet<Sessionids> Sessionids { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
