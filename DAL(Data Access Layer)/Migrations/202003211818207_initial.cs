namespace DAL_Data_Access_Layer_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Image = c.Binary(nullable: false),
                        NextControlDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Equipments");
        }
    }
}
