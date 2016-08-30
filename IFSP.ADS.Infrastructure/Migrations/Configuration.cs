using System.Data.Entity.Migrations;

namespace IFSP.ADS.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LusaContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LusaContext ctx)
        {

            Categories(ctx);
            ctx.SaveChanges();
        }


        public void Categories(LusaContext ctx)
        {
            ctx.Category.AddOrUpdate(x => x.Id, new Models.Category
            {
                Id = 1,
                Description = "Categoria de alto redimento masculino adulta Union",
                Gender = "Masculino",
                Name = "Alto redimento masculino adulta Union",
                Status = true
            }, new Models.Category
            {
                Id = 2,
                Description = "Categoria de alto redimento feminino adulta Sevens",
                Gender = "Feminino",
                Name = "Alto redimento feminino adulta Sevens",
                Status = true
            }
            );
        }
    }
}
