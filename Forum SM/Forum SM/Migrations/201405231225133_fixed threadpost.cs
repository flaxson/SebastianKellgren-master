namespace Forum_SM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedthreadpost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        Author_id = c.Int(),
                        ThreadPost_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_id)
                .ForeignKey("dbo.ThreadPosts", t => t.ThreadPost_id)
                .Index(t => t.Author_id)
                .Index(t => t.ThreadPost_id);
            
            CreateTable(
                "dbo.ThreadPosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ThreadText = c.String(),
                        AuthorThread_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.AuthorThread_id)
                .Index(t => t.AuthorThread_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ThreadPost_id", "dbo.ThreadPosts");
            DropForeignKey("dbo.ThreadPosts", "AuthorThread_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Author_id", "dbo.Users");
            DropIndex("dbo.ThreadPosts", new[] { "AuthorThread_id" });
            DropIndex("dbo.Comments", new[] { "ThreadPost_id" });
            DropIndex("dbo.Comments", new[] { "Author_id" });
            DropTable("dbo.ThreadPosts");
            DropTable("dbo.Comments");
        }
    }
}
