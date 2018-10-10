namespace FIT5032_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookingConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingModels", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.BookingModels", "NutritionistId", c => c.String(nullable: false));
            AlterColumn("dbo.BookingModels", "CustomerId", c => c.String(nullable: false));
            AlterColumn("dbo.BookingModels", "BookingStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingModels", "BookingStatus", c => c.String());
            AlterColumn("dbo.BookingModels", "CustomerId", c => c.String());
            AlterColumn("dbo.BookingModels", "NutritionistId", c => c.String());
            AlterColumn("dbo.BookingModels", "Title", c => c.String());
        }
    }
}
