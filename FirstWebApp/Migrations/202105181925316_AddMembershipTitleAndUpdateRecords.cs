namespace FirstWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTitleAndUpdateRecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTitle", c => c.String(nullable: false, maxLength: 255));

            Sql("UPDATE MembershipTypes SET MembershipTitle='Pay as You Go' WHERE Id=1;");
            Sql("UPDATE MembershipTypes SET MembershipTitle='Monthly' WHERE Id=2;");
            Sql("UPDATE MembershipTypes SET MembershipTitle='Quarterly' WHERE Id=3;");
            Sql("UPDATE MembershipTypes SET MembershipTitle='Annual' WHERE Id=4;");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTitle");
        }
    }
}
