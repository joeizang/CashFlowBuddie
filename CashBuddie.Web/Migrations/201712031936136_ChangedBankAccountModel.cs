namespace CashBuddie.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBankAccountModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "InstitutionName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "InstitutionName");
        }
    }
}
