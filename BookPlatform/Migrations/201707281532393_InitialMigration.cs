namespace BookPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.String(nullable: false, maxLength: 255, unicode: false),
                        Title = c.String(nullable: false, maxLength: 255, unicode: false),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                        Pages = c.Short(nullable: false),
                        PublishingDate = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_Tag");
            
            CreateTable(
                "dbo.BookTags",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Tag_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.BookTags", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.BookTags", new[] { "Tag_Id" });
            DropIndex("dbo.BookTags", new[] { "Book_Id" });
            DropIndex("dbo.Tags", "IX_Tag");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropTable("dbo.BookTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
