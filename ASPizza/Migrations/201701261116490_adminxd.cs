namespace ASPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminxd : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2caf0c8f-8ff7-4714-b6f5-90ee87e47431', N'a@a.pl', 0, N'AATRAhuVV25HRykhYuYG+YO2MBKK3W7mPrOS3bLMQprLEc2r1bzForPyGMTkTcvZiQ==', N'3679af02-17b7-40cf-b640-b3a1bf3300c9', NULL, 0, 0, NULL, 1, 0, N'a@a.pl')");
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'e5b51397-202d-4055-8191-88f00e11f094', N'admin@admin.pl', 0, N'AOI9MQSOAwCyCK9uNdRvhdVsMFiDEX9P/uWitAjsZZ9fuPgJSgQOTWYgAu8psROuyg==', N'6624de90-9fe4-4ff0-b6f4-ae65db4d1579', NULL, 0, 0, NULL, 1, 0, N'admin@admin.pl')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e5b51397-202d-4055-8191-88f00e11f094', N'cda45f82-5164-4668-a565-e1683df3188a')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cda45f82-5164-4668-a565-e1683df3188a', N'Admin')");
        }
        
        public override void Down()
        {
        }
    }
}
