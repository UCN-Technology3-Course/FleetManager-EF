namespace DataAccessLayerEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Fuel = c.Int(nullable: false),
                        PassengerCapacity = c.Int(nullable: false),
                        KilometersDriven = c.Int(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Zip = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Cars", new[] { "Location_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.Cars");
        }
    }
}
