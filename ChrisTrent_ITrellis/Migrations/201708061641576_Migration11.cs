namespace ChrisTrent_ITrellis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "todo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "todo");
        }
    }
}
