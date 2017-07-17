namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moviees", "Title", c => c.String(maxLength: 60));
            AlterColumn("dbo.Moviees", "Genre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Moviees", "Rating", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moviees", "Rating", c => c.String());
            AlterColumn("dbo.Moviees", "Genre", c => c.String());
            AlterColumn("dbo.Moviees", "Title", c => c.String());
        }
    }
}
