namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FAPIex2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        VideoId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoId, t.TagId })
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Videos");
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropTable("dbo.VideoTags");
        }
    }
}
