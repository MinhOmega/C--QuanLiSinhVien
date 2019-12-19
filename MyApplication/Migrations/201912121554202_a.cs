namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        IDKhoa = c.String(nullable: false, maxLength: 128),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.IDKhoa);
            
            CreateTable(
                "dbo.DiemKhoaVatLies",
                c => new
                    {
                        IDDiem = c.String(nullable: false, maxLength: 128),
                        DiemCoHoc = c.Single(nullable: false),
                        DiemQuangHoc = c.Single(nullable: false),
                        IDSinhVien = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDDiem)
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien)
                .Index(t => t.IDSinhVien);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IDSinhVien = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        GioiTinh = c.Int(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        IDKhoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDSinhVien)
                .ForeignKey("dbo.Khoas", t => t.IDKhoa)
                .Index(t => t.IDKhoa);
            
            CreateTable(
                "dbo.DiemKhoaCNTTs",
                c => new
                    {
                        IDDiem = c.String(nullable: false, maxLength: 128),
                        DiemC = c.Single(nullable: false),
                        DiemJava = c.Single(nullable: false),
                        IDSinhVien = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDDiem)
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien)
                .Index(t => t.IDSinhVien);
            
            CreateTable(
                "dbo.DiemKhoaVans",
                c => new
                    {
                        IDDiem = c.String(nullable: false, maxLength: 128),
                        DiemVHCD = c.Single(nullable: false),
                        DiemVHHD = c.Single(nullable: false),
                        IDSinhVien = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDDiem)
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien)
                .Index(t => t.IDSinhVien);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiemKhoaVans", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.DiemKhoaCNTTs", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.DiemKhoaVatLies", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.SinhViens", "IDKhoa", "dbo.Khoas");
            DropIndex("dbo.DiemKhoaVans", new[] { "IDSinhVien" });
            DropIndex("dbo.DiemKhoaCNTTs", new[] { "IDSinhVien" });
            DropIndex("dbo.SinhViens", new[] { "IDKhoa" });
            DropIndex("dbo.DiemKhoaVatLies", new[] { "IDSinhVien" });
            DropTable("dbo.DiemKhoaVans");
            DropTable("dbo.DiemKhoaCNTTs");
            DropTable("dbo.SinhViens");
            DropTable("dbo.DiemKhoaVatLies");
            DropTable("dbo.Khoas");
        }
    }
}
