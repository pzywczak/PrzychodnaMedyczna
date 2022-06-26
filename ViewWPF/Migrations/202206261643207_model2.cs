namespace ViewWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model2 : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Lekarze",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImieINazwisko = c.String(),
                        Adres = c.String(),
                        Specjalizacja = c.String(),
                        USERID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uzytkownicy", t => t.USERID, cascadeDelete: true)
                .Index(t => t.USERID);
            
            CreateTable(
                "dbo.Uzytkownicy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Haslo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacjenci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImieINazwisko = c.String(),
                        Adres = c.String(),
                        Telefon = c.String(),
                        USERID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uzytkownicy", t => t.USERID, cascadeDelete: true)
                .Index(t => t.USERID);
            
            CreateTable(
                "dbo.Wizyty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        Godzina = c.String(),
                        TypWizyty = c.String(),
                        ImieINazwiskoPacjenta = c.String(),
                        USERID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uzytkownicy", t => t.USERID)
                .Index(t => t.USERID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wizyty", "USERID", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Pacjenci", "USERID", "dbo.Uzytkownicy");
            DropForeignKey("dbo.Lekarze", "USERID", "dbo.Uzytkownicy");
            DropIndex("dbo.Wizyty", new[] { "USERID" });
            DropIndex("dbo.Pacjenci", new[] { "USERID" });
            DropIndex("dbo.Lekarze", new[] { "USERID" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Wizyty");
            DropTable("dbo.Pacjenci");
            DropTable("dbo.Uzytkownicy");
            DropTable("dbo.Lekarze");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
