namespace FirstWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Type = c.String(nullable: false, maxLength: 255)
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
