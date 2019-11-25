namespace DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPhoneLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entry", "PhoneNumber", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entry", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
