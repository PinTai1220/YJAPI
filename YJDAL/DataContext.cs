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
        public DbSet<Daycost> Daycost { get; set; }
        public DbSet<Developers_apply_for> Developers_Apply_For { get; set; }
        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<Infostate> Infostate { get; set; }
        public DbSet<Levelcost> Levelcost { get; set; }
        public DbSet<Moneyrecord> Moneyrecord { get; set; }
        public DbSet<Sessionids> Sessionid { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Attention> Attention { get; set; }
    }
}
