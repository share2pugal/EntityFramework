namespace CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres values(1,'Action')");
            Sql("Insert into Genres values(2,'Horror')");
        }
        
        public override void Down()
        {
            Sql("Delete From Genres");
        }
    }
}
