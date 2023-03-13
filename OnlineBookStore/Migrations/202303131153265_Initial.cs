namespace OnlineBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.String(nullable: false, maxLength: 128),
                        BookTitle = c.String(),
                        IsReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.ReserveDetails",
                c => new
                    {
                        ReserveId = c.String(nullable: false, maxLength: 128),
                        BookId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReserveId)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReserveDetails", "BookId", "dbo.Books");
            DropIndex("dbo.ReserveDetails", new[] { "BookId" });
            DropTable("dbo.ReserveDetails");
            DropTable("dbo.Books");
        }
    }
}
