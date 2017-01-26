namespace ASPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepizzaclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pizzas", "DodatekId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pizzas", "DodatekId");
            AddForeignKey("dbo.Pizzas", "DodatekId", "dbo.Dodateks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizzas", "DodatekId", "dbo.Dodateks");
            DropIndex("dbo.Pizzas", new[] { "DodatekId" });
            DropColumn("dbo.Pizzas", "DodatekId");
            DropColumn("dbo.Pizzas", "Price");
        }
    }
}
