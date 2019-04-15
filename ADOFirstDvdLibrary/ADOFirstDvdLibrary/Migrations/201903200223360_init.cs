namespace ADOFirstDvdLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseYear = c.Int(),
                        Notes = c.String(),
                        DirectorName = c.String(),
                        DirectorId = c.Int(),
                        RatingValue = c.String(),
                        RatingId = c.Int(),
                    })
                .PrimaryKey(t => t.DvdId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
            DropTable("dbo.Directors");
        }
    }
}
