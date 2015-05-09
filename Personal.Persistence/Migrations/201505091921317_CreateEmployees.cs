namespace Personal.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "HR.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommisionPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManagerId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Job_JobId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("HR.Department", t => t.DepartmentId)
                .ForeignKey("HR.Job", t => t.Job_JobId)
                .ForeignKey("HR.Employee", t => t.ManagerId)
                .Index(t => t.ManagerId)
                .Index(t => t.DepartmentId)
                .Index(t => t.Job_JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Employee", "ManagerId", "HR.Employee");
            DropForeignKey("HR.Employee", "Job_JobId", "HR.Job");
            DropForeignKey("HR.Employee", "DepartmentId", "HR.Department");
            DropIndex("HR.Employee", new[] { "Job_JobId" });
            DropIndex("HR.Employee", new[] { "DepartmentId" });
            DropIndex("HR.Employee", new[] { "ManagerId" });
            DropTable("HR.Employee");
        }
    }
}
