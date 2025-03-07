namespace WebAPICRUDCodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnPhoneNo1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "PhoneNo1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "PhoneNo1", c => c.String());
        }
    }
}
