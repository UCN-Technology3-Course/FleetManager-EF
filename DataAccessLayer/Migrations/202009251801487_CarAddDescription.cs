namespace DataAccessLayerEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarAddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Description");
        }
    }
}
