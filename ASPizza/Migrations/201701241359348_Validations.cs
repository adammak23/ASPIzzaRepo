namespace ASPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pizzas", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizzas", "Name", c => c.String());
        }
    }
}
