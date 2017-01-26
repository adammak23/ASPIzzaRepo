namespace ASPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationsDodatek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dodateks", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dodateks", "Name", c => c.String());
        }
    }
}
