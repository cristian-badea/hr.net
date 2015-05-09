namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeesManagerNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("HR.Employee", new[] { "ManagerId" });
            AlterColumn("HR.Employee", "ManagerId", c => c.Int());
            CreateIndex("HR.Employee", "ManagerId");
        }
        
        public override void Down()
        {
            DropIndex("HR.Employee", new[] { "ManagerId" });
            AlterColumn("HR.Employee", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("HR.Employee", "ManagerId");
        }
    }
}
