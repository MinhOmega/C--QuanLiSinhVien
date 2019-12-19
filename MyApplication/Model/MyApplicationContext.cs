using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext() : base("Data Source=.;Initial Catalog=DB_G22;Persist Security Info=True;User ID=sa;Password=1234;")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyApplicationContext, MyApplication.Migrations.Configuration>());
        }
        public DbSet<SinhViens> SinhViensDbSet { get; set; }
        public DbSet<Khoa> KhoaDbSet { get; set; }
        public DbSet<DiemKhoaCNTT> KhoaTinDbSet { get; set; }
        public DbSet<DiemKhoaVan> KhoaVanDbSet { get; set; }
        public DbSet<DiemKhoaVatLy> KhoaLyDbSet { get; set; }
    }
}
