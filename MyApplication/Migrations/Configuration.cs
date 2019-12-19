namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyApplication.Model.MyApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyApplication.Model.MyApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.KhoaDbSet.AddOrUpdate(new Model.Khoa
            {
                IDKhoa = "1",
                TenKhoa = "CNTT",
            });
            context.KhoaDbSet.AddOrUpdate(new Model.Khoa
            {
                IDKhoa = "2",
                TenKhoa = "VatLy",
            });
            context.KhoaDbSet.AddOrUpdate(new Model.Khoa
            {
                IDKhoa = "3",
                TenKhoa = "VanHoc",
            });
            context.SinhViensDbSet.AddOrUpdate(new Model.SinhViens
            {
                IDSinhVien = "1",
                HoTen = "Võ Ngọc Quang Minh",
                NgaySinh = new DateTime(1998, 2, 5),
                IDKhoa = "1",
            });
            context.KhoaTinDbSet.AddOrUpdate(new Model.DiemKhoaCNTT
            {
                IDDiem = "1",
                DiemC = 8,
                DiemJava = 9,
                IDSinhVien = "1",
            });
            context.SaveChanges();
        }
    }
}
