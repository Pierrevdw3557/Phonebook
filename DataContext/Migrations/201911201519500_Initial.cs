namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entry",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        PhoneBookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.PhoneBook", t => t.PhoneBookId, cascadeDelete: true)
                .Index(t => t.PhoneBookId);
            
            CreateTable(
                "dbo.PhoneBook",
                c => new
                    {
                        PhoneBookId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PhoneBookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entry", "PhoneBookId", "dbo.PhoneBook");
            DropIndex("dbo.Entry", new[] { "PhoneBookId" });
            DropTable("dbo.PhoneBook");
            DropTable("dbo.Entry");
        }
    }
}
