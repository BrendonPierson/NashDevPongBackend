namespace PingPong.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PingPong.Models.PingPongContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PingPong.Models.PingPongContext context)
        {
            //  This method will be called after migrating to the latest version.


            Player p1 = new Player { PlayerId = 1, Handle = "pongBaller", EloRating = 1300 };
            Player p2 = new Player { PlayerId = 2, Handle = "spinDoctor", EloRating = 1200 };

            List<SinglesMatch> sMatches = new List<SinglesMatch>
            {
                new SinglesMatch
                {
                    MatchId = 1,
                    MatchDate = DateTime.Now,
                    PlayerOne = p1,
                    PlayerOneElo = 1300,
                    PlayerOneScore = 21,
                    PlayerTwo = p2,
                    PlayerTwoElo = 1200,
                    PlayerTwoScore = 12
                }
            };
            context.SinglesMatches.AddRange(sMatches);


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
