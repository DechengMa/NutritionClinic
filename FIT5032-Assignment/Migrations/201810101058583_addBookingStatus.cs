namespace FIT5032_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "BookingStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingModels", "BookingStatus");
        }
    }
}
