namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeWithRestrictions : DbMigration
    {
        public override void Up()
        {
            DropIndex("HR.Employee", new[] { "JobId" });
            AlterColumn("HR.Employee", "FirstName", c => c.String(nullable: false));
            AlterColumn("HR.Employee", "LastName", c => c.String(nullable: false));
            AlterColumn("HR.Employee", "JobId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("HR.Employee", "CommisionPercent", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("HR.Employee", "JobId");
        }
        
        public override void Down()
        {
            DropIndex("HR.Employee", new[] { "JobId" });
            AlterColumn("HR.Employee", "CommisionPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("HR.Employee", "JobId", c => c.String(maxLength: 128));
            AlterColumn("HR.Employee", "LastName", c => c.String());
            AlterColumn("HR.Employee", "FirstName", c => c.String());
            CreateIndex("HR.Employee", "JobId");
        }
    }
}
