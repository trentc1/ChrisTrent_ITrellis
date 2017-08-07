namespace ChrisTrent_ITrellis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "toDo_Item", c => c.String(nullable: false));
            DropColumn("dbo.Todoes", "todo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "todo", c => c.String(nullable: false));
            DropColumn("dbo.Todoes", "toDo_Item");
        }
    }
}
