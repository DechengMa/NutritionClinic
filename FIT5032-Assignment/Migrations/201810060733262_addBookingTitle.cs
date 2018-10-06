namespace FIT5032_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookingTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "Title");
        }
    }
}
