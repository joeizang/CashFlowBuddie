namespace CashBuddie.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNamesToAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "OtherNames", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OtherNames");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
