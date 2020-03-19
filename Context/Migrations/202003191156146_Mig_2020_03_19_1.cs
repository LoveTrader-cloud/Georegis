namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_2020_03_19_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeId = c.Int(nullable: false),
                        Title = c.String(maxLength: 150),
                        DepartmentCode = c.String(maxLength: 15),
                        DepartmentPrefix = c.String(maxLength: 15),
                        Description = c.String(maxLength: 250),
                        IsDeleted = c.Boolean(nullable: false),
                        IsIndependent = c.Boolean(nullable: false),
                        NotIndependent = c.Boolean(),
                        IsGroup = c.Boolean(),
                        IsLeaders = c.Boolean(nullable: false),
                        IsControllerBuro = c.Boolean(nullable: false),
                        IsSecretarBuro = c.Boolean(nullable: false),
                        ManagedBy = c.Int(nullable: false),
                        UserGroupManager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserGroupManager_Id)
                .Index(t => t.UserGroupManager_Id);
            
            CreateTable(
                "dbo.ExecDeps",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsCompleted = c.Boolean(nullable: false),
                        IsControl = c.Boolean(nullable: false),
                        IsApprove = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ParentId = c.Guid(),
                        Resolution = c.String(maxLength: 500),
                        RequestRouteId = c.Guid(nullable: false),
                        ControllerMessage = c.String(),
                        IsCurrent = c.Boolean(),
                        Department_Id = c.Int(),
                        Request_Id = c.Guid(),
                        ProcessSession_Id = c.Guid(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExecDeps", t => t.ParentId)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.DraftTasks", t => t.Request_Id)
                .ForeignKey("dbo.ProcessSessions", t => t.ProcessSession_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.ParentId)
                .Index(t => t.Department_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.ProcessSession_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsCompleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        Resolution = c.String(maxLength: 500),
                        NotId = c.Guid(),
                        ExecDep_Id = c.Guid(),
                        Request_Id = c.Guid(),
                        Status_Id = c.Int(),
                        User_Id = c.Int(),
                        UserAssign_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExecDeps", t => t.ExecDep_Id)
                .ForeignKey("dbo.DraftTasks", t => t.Request_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.UserAssign_Id)
                .Index(t => t.ExecDep_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.User_Id)
                .Index(t => t.UserAssign_Id);
            
            CreateTable(
                "dbo.DraftTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Theme = c.String(),
                        Text = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.ProcessSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsCompleted = c.Boolean(nullable: false),
                        IsCurrent = c.Boolean(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Request_Id = c.Guid(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DraftTasks", t => t.Request_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Request_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TabNumber = c.Int(nullable: false),
                        Login = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 150),
                        ShortName = c.String(maxLength: 100),
                        TelNo = c.String(maxLength: 15),
                        Email = c.String(maxLength: 150),
                        Company = c.String(maxLength: 100),
                        UserType = c.Int(nullable: false),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "UserGroupManager_Id", "dbo.Users");
            DropForeignKey("dbo.Executors", "UserAssign_Id", "dbo.Users");
            DropForeignKey("dbo.Executors", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.ProcessSessions", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Executors", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.ExecDeps", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.DraftTasks", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.ProcessSessions", "Request_Id", "dbo.DraftTasks");
            DropForeignKey("dbo.ExecDeps", "ProcessSession_Id", "dbo.ProcessSessions");
            DropForeignKey("dbo.Executors", "Request_Id", "dbo.DraftTasks");
            DropForeignKey("dbo.ExecDeps", "Request_Id", "dbo.DraftTasks");
            DropForeignKey("dbo.Executors", "ExecDep_Id", "dbo.ExecDeps");
            DropForeignKey("dbo.ExecDeps", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.ExecDeps", "ParentId", "dbo.ExecDeps");
            DropIndex("dbo.Users", new[] { "Department_Id" });
            DropIndex("dbo.ProcessSessions", new[] { "Status_Id" });
            DropIndex("dbo.ProcessSessions", new[] { "Request_Id" });
            DropIndex("dbo.DraftTasks", new[] { "Status_Id" });
            DropIndex("dbo.Executors", new[] { "UserAssign_Id" });
            DropIndex("dbo.Executors", new[] { "User_Id" });
            DropIndex("dbo.Executors", new[] { "Status_Id" });
            DropIndex("dbo.Executors", new[] { "Request_Id" });
            DropIndex("dbo.Executors", new[] { "ExecDep_Id" });
            DropIndex("dbo.ExecDeps", new[] { "Status_Id" });
            DropIndex("dbo.ExecDeps", new[] { "ProcessSession_Id" });
            DropIndex("dbo.ExecDeps", new[] { "Request_Id" });
            DropIndex("dbo.ExecDeps", new[] { "Department_Id" });
            DropIndex("dbo.ExecDeps", new[] { "ParentId" });
            DropIndex("dbo.Departments", new[] { "UserGroupManager_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.ProcessSessions");
            DropTable("dbo.DraftTasks");
            DropTable("dbo.Executors");
            DropTable("dbo.ExecDeps");
            DropTable("dbo.Departments");
        }
    }
}
