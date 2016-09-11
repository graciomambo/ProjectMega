namespace Gamer.Migrations
{
    using Context;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gamer.Context.GamerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Gamer.Context.GamerContext context)
        {
            if (context.PostTypes.Count() == 0)
            {
                context.PostTypes.Add(new PostType() { Name = "Video" });                
                context.PostTypes.Add(new PostType() { Name = "Artigo" });
                context.PostTypes.Add(new PostType() { Name = "Galeria" });
                context.PostTypes.Add(new PostType() { Name = "Documento" });

                context.Categories.Add(new Category() { Name = "Jogos" });
                context.Categories.Add(new Category() { Name = "Novidade" });
                context.Categories.Add(new Category() { Name = "Comunidade" });
                context.Categories.Add(new Category() { Name = "Hardware" });
                context.SaveChanges();
            }
        }
       
    }
}