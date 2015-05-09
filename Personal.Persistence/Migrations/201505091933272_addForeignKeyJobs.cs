namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyJobs : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "HR.Employee", name: "Job_JobId", newName: "JobId");
            RenameIndex(table: "HR.Employee", name: "IX_Job_JobId", newName: "IX_JobId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "HR.Employee", name: "IX_JobId", newName: "IX_Job_JobId");
            RenameColumn(table: "HR.Employee", name: "JobId", newName: "Job_JobId");
        }
    }
}
